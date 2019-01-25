using System.Reflection;
using Abp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace TestAspCoreInit
{
    [DependsOn(typeof(TestAspCoreInitCoreModule))]
    //[DependsOn(typeof(MysqlsugarModule))]
    public class TestWebMvcModule:AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public TestWebMvcModule(IHostingEnvironment env)
        {
            _env = env;           
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath,env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            //Configuration.Localization.Sources
            //Configuration.Navigation.Providers.Add<AbpProjectNameNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TestWebMvcModule).GetAssembly());
            
        }
    
        public override void PostInitialize()
        {
            //IocManager.IocContainer.

            //var bootstrapper = AbpBootstrapper.Create<TestWebMvcModule>();
            //var modules = bootstrapper.IocManager.Resolve<IAbpModuleManager>().Modules;
            //foreach (var abpModuleInfo in modules)
            //{
            //    if (abpModuleInfo.IsLoadedAsPlugIn)
            //    {
            //        abpModuleInfo.Assembly
            //    }

            //}
        }
    }
}
