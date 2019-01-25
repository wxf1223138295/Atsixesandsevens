using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using Abp.Dependency;
using Abp.Modules;
using Microsoft.AspNetCore.Mvc;
using TestAspCoreInit.Models;

namespace TestAspCoreInit.Controllers
{
    public class HomeController : AbpController
    {

        public IActionResult Index()
        {
            foreach (var abpModuleInfo in IocManager.Instance.Resolve<IAbpModuleManager>().Modules)
            {
                if (abpModuleInfo.IsLoadedAsPlugIn)
                {

                    abpModuleInfo.Instance.PreInitialize();

                    var type = abpModuleInfo.Assembly.GetType("Shawn.dal.TestRefClass", true, true);
                    var obj = Activator.CreateInstance(type);
                    var objo = type.InvokeMember("add", BindingFlags.InvokeMethod, null, obj, new object[] { 1 });
                }
            }


            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
