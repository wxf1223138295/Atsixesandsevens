using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestCastle.Common;

namespace TestCastle.Areas.Area.Controllers
{
    [Route("api/test/[controller]")]
    public class DIDSController : Controller
    {
        private IShopping _iShopping;

        public DIDSController(IShopping iShopping)
        {
            _iShopping = iShopping;
        }

        public IActionResult Index()
        {
            var er=_iShopping.shopshoes(334);
            return View();
        }
    }
}