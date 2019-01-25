using System;
using System.Collections.Generic;
using System.Text;
using Abp.Configuration.Startup;

namespace shawn.module
{
    public static class shawnMyModuleConfigurationExtensions
    {
        public static IshawnMyModuleConfiguration AbpWebApi(this IModuleConfigurations configurations)
        {
            return configurations.AbpConfiguration.Get<IshawnMyModuleConfiguration>();
        }
    }
}
