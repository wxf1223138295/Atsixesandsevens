using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;

namespace TestCastle.Castle
{
    public static class CoreServiceCollectionExtensions
    {
        public static IServiceProvider AddAbp(this IServiceCollection services)
        {
         

            ConfigureAspNetCore(services, IocManager.Instance);

            return WindsorRegistrationHelper.CreateServiceProvider(IocManager.Instance.IocContainer, services);
        }
        private static void ConfigureAspNetCore(IServiceCollection services, IIocResolver iocResolver)
        {
            //See https://github.com/aspnet/Mvc/issues/3936 to know why we added these services.
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

            //Use DI to create controllers
            services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());

            //Use DI to create view components
            services.Replace(ServiceDescriptor.Singleton<IViewComponentActivator, ServiceBasedViewComponentActivator>());

            ////Change anti forgery filters (to work proper with non-browser clients)
            //services.Replace(ServiceDescriptor.Transient<AutoValidateAntiforgeryTokenAuthorizationFilter, AbpAutoValidateAntiforgeryTokenAuthorizationFilter>());
            //services.Replace(ServiceDescriptor.Transient<ValidateAntiforgeryTokenAuthorizationFilter, AbpValidateAntiforgeryTokenAuthorizationFilter>());

            ////Add feature providers
            //var partManager = services.GetSingletonServiceOrNull<ApplicationPartManager>();
            //partManager?.FeatureProviders.Add(new AbpAppServiceControllerFeatureProvider(iocResolver));

            ////Configure JSON serializer
            //services.Configure<MvcJsonOptions>(jsonOptions =>
            //{
            //    jsonOptions.SerializerSettings.ContractResolver = new AbpMvcContractResolver(iocResolver)
            //    {
            //        NamingStrategy = new CamelCaseNamingStrategy()
            //    };
            //});

            ////Configure MVC
            //services.Configure<MvcOptions>(mvcOptions =>
            //{
            //    mvcOptions.AddAbp(services);
            //});

            //Configure Razor
            //services.Insert(0,
            //    ServiceDescriptor.Singleton<IConfigureOptions<RazorViewEngineOptions>>(
            //        new ConfigureOptions<RazorViewEngineOptions>(
            //            (options) =>
            //            {
            //                options.FileProviders.Add(new EmbeddedResourceViewFileProvider(iocResolver));
            //            }
            //        )
            //    )
            //);
        }
    }
}
