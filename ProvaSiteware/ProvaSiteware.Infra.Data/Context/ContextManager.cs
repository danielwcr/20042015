using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProvaSiteware.Infra.Data.Context
{
    public class ContextManager
    {
        const string ContextKey = "ContextManager.Context";

        public DbContext Context
        {
            get
            {
                if (HttpContext.Current.Items[ContextKey] == null)
                    HttpContext.Current.Items[ContextKey] = new ProvaSitewareContext();

                return (ProvaSitewareContext)HttpContext.Current.Items[ContextKey];

            }
        }


    }
}
