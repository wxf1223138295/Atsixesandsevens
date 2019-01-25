using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CastleDynamic.Common;

namespace CastleDynamic
{
    public class CallFunctionClass
    {
        private IShopping _shopping;

        public CallFunctionClass(IShopping shopping)
        {
            _shopping = shopping;
        }

        public string GetFunc()
        {
            return _shopping.shopshoes(344);
        }
    }
}
