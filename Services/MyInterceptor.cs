using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionAutofacDemo.Services
{
    // IInterceptor: 动态代理拦截接口
    public class MyInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"invocation before method:{invocation.Method.Name}");
            invocation.Proceed();   // 如果不执行这一行代码, 方法将被拦截器拦截
            Console.WriteLine($"invocation after method:{invocation.Method.Name}");
        }
    }
}
