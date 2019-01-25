using System;
using System.Collections.Generic;
using System.Text;
using Abp.Dependency;

namespace Shawn.dal
{
    public class TestRefClass
    {
        public int add(int i)
        {
            //return i + IocManager.Instance.Resolve<IAbpsqlsugarConfiguration>().count;
            return i + 1;
        }
    }
}
