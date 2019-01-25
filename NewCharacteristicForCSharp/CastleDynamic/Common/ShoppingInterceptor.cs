using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace CastleDynamic.Common
{
    public class ShoppingInterceptor: IProxyGenerationHook,IInterceptor
    {
        private decimal _arg;

        public ShoppingInterceptor(decimal arg)
        {
            _arg = arg;
        }

        public void Intercept(IInvocation invocation)
        {
            if (_arg > 100)
            {
                Console.WriteLine("钱不够");
            }
            else
            {
                invocation.Proceed();
            }
        }

        public void MethodsInspected()
        {
            throw new NotImplementedException();
        }

        public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
        {
            throw new NotImplementedException();
        }

        public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
        {
            throw new NotImplementedException();
        }
    }
}
