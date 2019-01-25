using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleDynamic.Common
{
    public class Shopping:IShopping
    {
        public virtual string shopshoes(decimal money)
        {
            return $"买好鞋子了,花了{money}元";
        }
    }
}
