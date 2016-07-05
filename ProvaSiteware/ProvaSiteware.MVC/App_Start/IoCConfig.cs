using Lab.Infra.CrossCutting.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.Presentation.MVC.App_Start
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