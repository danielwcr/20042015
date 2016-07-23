using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Lab.Resources;
using Lab.Presentation.MVC.ViewModels;
using Lab.Presentation.MVC.Helpers;

namespace Lab.Presentation.MVC.Controllers
{
    public class CultureController : Controller
    {
        public ActionResult Index()
        {
            var options = CultureHelper.Cultures
                .ConvertAll(p => new CultureOptionVM()
                {
                    Culture = p,
                    Current = CultureHelper.GetCurrentCulture().Equals(p)
                }
            );

            return PartialView(options);
        }

        public ActionResult Change(string culture)
        {
            culture = CultureHelper.GetImplementedCulture(culture);

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            var cookie = new HttpCookie("Culture");
            cookie.Value = culture;
            Response.Cookies.Add(cookie);

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }
    }
}