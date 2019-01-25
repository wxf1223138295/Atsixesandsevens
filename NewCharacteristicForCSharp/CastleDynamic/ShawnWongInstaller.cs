using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Services.Logging.Log4netIntegration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using CastleDynamic.Common;

namespace CastleDynamic
{
    //安装器1
    internal class ShawnWongInstaller:IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<LoggingFacility>(f => f.LogUsing<Log4netFactory>().WithConfig("log4net.config"));
            //注册组件
            container.Register(
                Component.For<IShopping,Shopping>().
                    ImplementedBy<Shopping>().LifestyleTransient()
            );
        }
    }
}
