using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using DependencyInjectionAutofacDemo.IServices;
using DependencyInjectionAutofacDemo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionAutofacDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        // add register services
        public void ConfigureContainer(ContainerBuilder builder)
        {
            //builder.RegisterType<MyService>().As<IMyService>();
            #region ÃüÃû×¢²á
            //builder.RegisterType<MyServiceV2>().Named<IMyService>("service2");
            #endregion

            #region ÊôÐÔ×¢²á
            //builder.RegisterType<MyNamedService>();
            //builder.RegisterType<MyServiceV2>().As<IMyService>().PropertiesAutowired();
            #endregion

            #region AOP
            //builder.RegisterType<MyInterceptor>();
            //builder.RegisterType<MyServiceV2>().As<IMyService>().PropertiesAutowired().InterceptedBy(typeof(MyInterceptor)).EnableClassInterceptors();
            //builder.RegisterType<MyServiceV2>().As<IMyService>().PropertiesAutowired().InterceptedBy(typeof(MyInterceptor)).EnableInterfaceInterceptors();
            #endregion

            #region ×ÓÈÝÆ÷
            builder.RegisterType<MyService>().As<IMyService>().InstancePerMatchingLifetimeScope("myscope");
            #endregion
        }

        // ¸ùÈÝÆ÷
        public ILifetimeScope AutoContainer { get; private set; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoContainer = app.ApplicationServices.GetAutofacRoot();

            //var service1 = AutoContainer.Resolve<IMyService>();
            //service1.ShowCode();

            #region ÃüÃû×¢²á
            //var service2 = AutoContainer.ResolveNamed<IMyService>("service2");
            //service2.ShowCode();
            #endregion

            #region ÊôÐÔ×¢²á
            //var service3 = AutoContainer.Resolve<IMyService>();
            //service3.ShowCode();
            #endregion

            #region AOP
            //var service4 = AutoContainer.Resolve<IMyService>();
            //service4.ShowCode();
            #endregion

            #region ×ÓÈÝÆ÷
            using (var myscope = AutoContainer.BeginLifetimeScope("myscope"))
            {
                var service = myscope.Resolve<IMyService>();
                service.ShowCode();
            }
            #endregion

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
