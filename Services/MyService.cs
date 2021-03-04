using DependencyInjectionAutofacDemo.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionAutofacDemo.Services
{
    public class MyService : IMyService
    {
        public override void ShowCode()
        {
            Console.WriteLine($"MyService.ShowCode:{this.GetHashCode()}");
        }
    }
}
