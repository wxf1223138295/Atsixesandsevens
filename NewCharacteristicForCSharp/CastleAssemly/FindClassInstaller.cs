using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core;
using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace CastleAssemly
{
    public class FindClassInstaller: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //注册组件
            //container.Register(
            //    Component.For<IPerson, Person>()
            //        .ImplementedBy<Person>()
            //        .Interceptors(InterceptorReference.ForType<CustomIInterceptor>()).Last
            //        .LifestyleTransient(),
            //    Component.For<CustomIInterceptor>()
            //);
            //拦截器选择


            //container.Register(
            //    Component.For<IPerson, Person>()
            //        .ImplementedBy<Person>()
            //        .Proxy.Hook(p => p.Instance(new InterceptorShawnFilter()))
            //        .Interceptors(InterceptorReference.ForType<CustomIInterceptor>(), InterceptorReference.ForType<SecondInterceptor>())
            //        .SelectedWith(new ShawnInterceptorSelector())
            //        .Anywhere
            //        .LifestyleTransient(),
            //    Component.For<CustomIInterceptor>(),
            //    Component.For<SecondInterceptor>()
            //);
        }
    }
}
