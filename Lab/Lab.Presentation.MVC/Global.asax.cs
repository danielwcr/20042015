using Lab.Presentation.MVC.App_Start;
using Lab.Presentation.MVC.AutoMapper;
using Lab.Presentation.MVC.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Lab.Presentation.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();
            IoCConfig.RegisterResolver();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var cookie = HttpContext.Current.Request.Cookies["Culture"];

            var culture = cookie?.Value ?? CultureHelper.GetDefaultCulture();

            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
        }
    }
}