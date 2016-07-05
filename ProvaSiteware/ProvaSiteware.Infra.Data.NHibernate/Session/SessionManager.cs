using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Lab.Infra.Data.NH.Session
{
    public class SessionManager
    {
        const string ContextKey = "SessionManager.Session";

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
