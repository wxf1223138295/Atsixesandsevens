using System;
using System.Collections.Generic;
using System.Text;

namespace Shawn.dal
{
    public interface IAbpsqlsugarConfiguration
    {
        string ConnectString { get; set; }
        int count { get; set; }
    }
}
