using System;
using System.Collections.Generic;
using System.Text;
using Abp;
using Abp.Dependency;
using Abp.Modules;
using Abp.Orm;
using Abp.Reflection.Extensions;
using shawn.module;

namespace Shawn.dal
{
    [DependsOn(typeof(AbpKernelModule),
        typeof(shawnMyModule))]
    public class MysqlsugarModule: AbpModule
    {
        private readonly shawnMyModule _myModule1;

        public MysqlsugarModule(shawnMyModule myModule1)
        {
            _myModule1 = myModule1;
        }
        public override void PreInitialize()
        {
            var r= _myModule1.getbyid(4);
            Configuration.UnitOfWork.IsTransactionScopeAvailable = false;
           // IocManager.AddConventionalRegistrar(new BasicConventionalRegistrar());
            //IocManager.Register<IAbpsqlsugarConfiguration, AbpsqlsugarConfiguration>();
            //Configuration.Get<AbpsqlsugarConfiguration>().ConnectString          
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MysqlsugarModule).GetAssembly());
        }

        public override void PostInitialize()
        {
             
        }
    }
}
