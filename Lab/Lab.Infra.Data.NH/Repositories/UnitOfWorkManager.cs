using Lab.Infra.Data.NH.Session;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Lab.Infra.Data.NH.Repositories
{
    public class UnitOfWorkManager
    {
        const string ContextKey = "UnitOfWorkManager.Session";

        public ISession Session
        {
            get
            {
                if (HttpContext.Current.Items[ContextKey] == null)
                    HttpContext.Current.Items[ContextKey] = SessionFactory.CreateSessionFactory().OpenSession();

                return (ISession)HttpContext.Current.Items[ContextKey];
            }
        }
    }
}
