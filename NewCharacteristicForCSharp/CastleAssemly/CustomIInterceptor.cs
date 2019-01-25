using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core;
using Castle.Core.Interceptor;
using Castle.DynamicProxy;

namespace CastleAssemly
{
    public  class CustomIInterceptor:IInterceptor, IOnBehalfAware
    {
        public void Intercept(IInvocation invocation)
        {
            //拦截前
            if ((string)invocation.GetArgumentValue(0) == "sss")
            {
                Console.WriteLine("拦截前拦截到到了");
            }
            invocation.Proceed();
            //拦截后
            if ((string)invocation.ReturnValue == "sss")
            {
                Console.WriteLine("拦截后拦截到了");
            }
        }

        public void SetInterceptedComponentModel(ComponentModel target)
        {
            var t = target.ComponentName;
        }
    }
}
