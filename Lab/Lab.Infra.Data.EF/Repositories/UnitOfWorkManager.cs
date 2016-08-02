using Lab.Infra.Data.EF.Context;
using System.Data.Entity;
using System.Web;

namespace Lab.Infra.Data.EF.Repositories
{
    public class UnitOfWorkManager
    {
        const string ContextKey = "UnitOfWorkManager.Context";

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
