using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleAssemly
{
    public class Person: IPerson
    {
        public string MyName(string name)
        {
            return name;
        }

        public string yourname(string name)
        {
            return name;
        }

        public string dynamic(string name)
        {
            return name;
        }

        public virtual string classdynamic(string name)
        {
            return name;
        }
    }
}
