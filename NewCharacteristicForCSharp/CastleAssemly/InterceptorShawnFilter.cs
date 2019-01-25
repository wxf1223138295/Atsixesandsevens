using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace CastleAssemly
{
    //决定整个方法是否运用拦截器
    public class InterceptorShawnFilter: IProxyGenerationHook
    {
        public void MethodsInspected()
        {
            
        }

        public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
        {
            Console.WriteLine($"无法代理的类 : {memberInfo.Name}");
        }

        public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
        {
            return methodInfo.Name.StartsWith("dynamic") || methodInfo.Name.StartsWith("classdynamic");
            //什么样的方法可以被拦截?
        }
    }
}
