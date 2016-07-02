using ProvaSiteware.Infra.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProvaSiteware.MVC.App_Start
{
    public class IoCConfig
    {
        public static void RegisterResolver()
        {
            IoC.Init();
            DependencyResolver.SetResolver(new IoCDependencyResolver());
        }
    }
}