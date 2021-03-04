using DependencyInjectionAutofacDemo.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionAutofacDemo.Services
{
    public class MyServiceV2 : IMyService
    {
        public MyNamedService NamedService { set; get; }
        public override void ShowCode()
        {
            Console.WriteLine($"MyServiceV2.ShowCode:{this.GetHashCode()},NamedService是否为空:{NamedService == null}");
        }
    }

    public class MyNamedService
    {

    }
}
