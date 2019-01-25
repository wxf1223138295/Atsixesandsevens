using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace CastleAssemly
{
    public class ShawnInterceptorSelector: IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            //什么样的方法返回什么样的拦截器
            if (method.Name.StartsWith("yourname"))
            {
                return interceptors.Where(p => p is SecondInterceptor).ToArray();
            }
            else
            {
                return interceptors.Where(p => p is CustomIInterceptor).ToArray();
            }
        }
    }
}
