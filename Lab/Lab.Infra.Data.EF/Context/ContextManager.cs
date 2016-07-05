using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Lab.Infra.Data.EF.Context
{
    public class ContextManager
    {
        const string ContextKey = "ContextManager.Context";

        public DbContext Context
        {
            get
            {
                if (HttpContext.Current.Items[ContextKey] == null)
                    HttpContext.Current.Items[ContextKey] = new LabContext();

                return (LabContext)HttpContext.Current.Items[ContextKey];

            }
        }


    }
}
