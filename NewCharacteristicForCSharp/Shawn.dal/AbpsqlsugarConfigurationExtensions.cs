using System;
using System.Collections.Generic;
using System.Text;
using Abp.Configuration.Startup;

namespace Shawn.dal
{
    public static class AbpsqlsugarConfigurationExtensions
    {
        public static IAbpsqlsugarConfiguration AbpWebApi(this IModuleConfigurations configurations)
        {
            return configurations.AbpConfiguration.Get<IAbpsqlsugarConfiguration>();
        }
    }
}
