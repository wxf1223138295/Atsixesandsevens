using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace CastleAssemly.Super
{
    public class MethodInterceptor:IInterceptor
    {
        public readonly Delegate _imp;
        

        public MethodInterceptor(Delegate imp)
        {
            _imp = imp;
        }

        public void Intercept(IInvocation invocation)
        {
           var result= this._imp.DynamicInvoke(invocation.Arguments);
            invocation.ReturnValue = result;
        }
    }      
}

