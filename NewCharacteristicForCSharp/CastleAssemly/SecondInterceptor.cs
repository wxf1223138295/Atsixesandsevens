using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace CastleAssemly
{
    public class SecondInterceptor: IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("SecondInterceptor");
            invocation.Proceed();
        }
    }
}
