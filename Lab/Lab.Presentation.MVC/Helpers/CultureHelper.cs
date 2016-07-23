using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Lab.Presentation.MVC.Helpers
{
    public static class CultureHelper
    {
        public static readonly List<string> Cultures = new List<string> { "pt", "en" };

        public static string GetImplementedCulture(string name)
        {
            if (string.IsNullOrEmpty(name))
                return GetDefaultCulture(); 
            
            if (Cultures.Any(c => c.Equals(name, StringComparison.InvariantCultureIgnoreCase)))
                return name; 

            return GetDefaultCulture(); 
        }

        public static string GetDefaultCulture()
        {
            return Cultures[0]; 
        }
        public static string GetCurrentCulture()
        {
            return Thread.CurrentThread.CurrentCulture.Name;
        }

    }
}