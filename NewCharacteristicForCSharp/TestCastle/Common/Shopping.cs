using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCastle.Common
{
    public class Shopping:IShopping
    {
        public string shopshoes(decimal money)
        {
            return $"买好鞋子了,花了{money}元";
        }
    }
}
