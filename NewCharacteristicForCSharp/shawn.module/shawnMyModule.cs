using System;
using System.Collections.Generic;
using System.Text;
using Abp;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace shawn.module
{
    [DependsOn(typeof(AbpKernelModule))]
    public class shawnMyModule:AbpModule
    {
        public override void PreInitialize()
        {
            

        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(shawnMyModule).GetAssembly());
        }

        public override void PostInitialize()
        {

        }

        public student getbyid(int id)
        {
            student st = new student { id=id,Address = "南通海门",age = 24,Name = "ShawnWong",Tel="17652423359"};

            return st;
        }
    }
}

