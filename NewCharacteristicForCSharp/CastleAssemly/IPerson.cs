using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleAssemly
{
    public interface IPerson
    {
        string MyName(string name);
        string yourname(string name);
        string dynamic(string name);
        string classdynamic(string name);
    }
}
