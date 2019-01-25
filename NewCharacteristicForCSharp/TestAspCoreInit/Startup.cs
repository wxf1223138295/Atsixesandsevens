using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Abp.AspNetCore;
using Abp.PlugIns;
using Castle.Facilities.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TestAspCoreInit
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);



            //return services.AddAbp<TestWebMvcModule>();

            return services.AddAbp<TestWebMvcModule>(options =>
                {
                    options.PlugInSources.Add(
                        new FolderPlugInSource(@"F:\NewCSharp\NewCharacteristicForCSharp\Shawn.dal\bin\Debug\netcoreapp2.1"));
                    
                    //var temp1=options.PlugInSources.GetAllAssemblies();

                    //var temp2 = options.PlugInSources.GetAllModules();
                });
        }
        //public void ConfigureServices(IServiceCollection services)
        //{
           
           

        //    services.AddAbp<TestWebMvcModule>(
        //        // Configure Log4Net logging
        //        options => options.IocManager.IocContainer.AddFacility<LoggingFacility>(
        //            f => f.UseAbpLog4Net().WithConfig("log4net.config")
        //        )
        //    );

        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAbp(); // Initializes ABP framework.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
