using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace TestAspCoreInit
{
    [DependsOn(
        typeof(AbpAspNetCoreModule)
    )]
    public class TestAspCoreInitCoreModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public TestAspCoreInitCoreModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
        //    Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
        //        AbpProjectNameConsts.ConnectionStringName
        //    );

            // Use database for language management
            //Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            //Configuration.Modules.AbpAspNetCore()
            //    .CreateControllersForAppServices(
            //        typeof(AbpProjectNameApplicationModule).GetAssembly()
            //    );

            ConfigureTokenAuth();
        }

        private void ConfigureTokenAuth()
        {
            //IocManager.Register<TokenAuthConfiguration>();
            //var tokenAuthConfig = IocManager.Resolve<TokenAuthConfiguration>();

            //tokenAuthConfig.SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appConfiguration["Authentication:JwtBearer:SecurityKey"]));
            //tokenAuthConfig.Issuer = _appConfiguration["Authentication:JwtBearer:Issuer"];
            //tokenAuthConfig.Audience = _appConfiguration["Authentication:JwtBearer:Audience"];
            //tokenAuthConfig.SigningCredentials = new SigningCredentials(tokenAuthConfig.SecurityKey, SecurityAlgorithms.HmacSha256);
            //tokenAuthConfig.Expiration = TimeSpan.FromDays(1);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TestAspCoreInitCoreModule).GetAssembly());
        }
    }
}
