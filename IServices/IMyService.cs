using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionAutofacDemo.IServices
{
    public abstract class IMyService
    {
        /// <summary>
        /// 打印代码
        /// </summary>
        public virtual void ShowCode() { }
    }
}
