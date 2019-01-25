using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.Core;
using Castle.Core.Logging;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.Windsor.Installer;
using CastleAssemly;
using CastleAssemly.Super;
using CastleDynamic.Castle;
using CastleDynamic.Common;
using CastleDynamic.function;

namespace CastleDynamic
{
    class Program
    {
        public static ILogger Logger { get; set; }
        static void Main(string[] args)
        {
            Logger = NullLogger.Instance;
            //Install
            IocManager.Instance.IocContainer.Install(
                //1.安装器
                new ShawnWongInstaller(),
                //方式二：顾名思义
                //1:反射需要注册的程序集
                FromAssembly.Instance(typeof(IPerson).Assembly)
                //2:按名字
                //3
            );


            //规约注册
            IocManager.Instance.IocContainer.Register(
                Classes.FromAssembly(typeof(IPerson).Assembly)                 
                .Where(p => p.Name.EndsWith("Repository"))
                .WithService.AllInterfaces().LifestyleTransient());


            ProxyGenerator generator = new ProxyGenerator();
            
            var options = new ProxyGenerationOptions(new InterceptorShawnFilter());
            options.Selector = new ShawnInterceptorSelector();
            
             var entity = generator.CreateClassProxy<Person>(
                options,
                new CustomIInterceptor(), new SecondInterceptor());

            


            var t = entity.yourname("sdsd");
            var yr = entity.MyName("dfdf");
            var ry = entity.dynamic("sdd");
            var tyr = entity.classdynamic("sdsd");

            //TODO 高级用法
            //没有目标的接口代理
            Func<string, int> func = ((a) =>
            {
                var rets=Convert.ToInt32(a);
                return rets;
            });

            var tre=DelegateWrapper.WrapAs<IAnsweringEngine>(func);
            var retAnswer = tre.GetAnswer("4545");


















                  var r = IocManager.Instance.Resolve<IShopping>().shopshoes(180);

            //var t = IocManager.Instance.Resolve<IPerson>().MyName("sss");

            //var e = IocManager.Instance.Resolve<IPerson>().yourname("rrr");

            //var u = IocManager.Instance.Resolve<IPerson>().dynamic("34");

            var y = IocManager.Instance.Resolve<ITestRepository>().testConservtion(6);


            Logger.Debug("CES");



            //ShoppingInterceptor inte=new ShoppingInterceptor(100);

            //ProxyGenerator getGenerator=new ProxyGenerator();

            //var t = getGenerator.CreateClassProxy<Shopping>(inte);
            //t.shopshoes(120);




            //IocManager.Instance.IocContainer.Register(
            //    Component.For(typeof(IShopping))
            //        .ImplementedBy(typeof(Shopping))

            //);

            //IocManager.Instance.Resolve<IShopping>().shopshoes(180);

            Console.ReadLine();

        }


    }
}
