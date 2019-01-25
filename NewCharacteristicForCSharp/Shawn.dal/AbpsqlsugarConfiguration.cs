using System;
using System.Collections.Generic;
using System.Text;

namespace Shawn.dal
{
    public class AbpsqlsugarConfiguration: IAbpsqlsugarConfiguration
    {
        public string ConnectString { get; set; }
        public int count { get; set; }

        public int addf(int i)
        {
            return i + count;
        }
        public AbpsqlsugarConfiguration()
        {
            ConnectString = string.Empty;
            count = 4;
        }
    }
}
