using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaSiteware.Infra.Data.Context
{
    public class ProvaSitewareContext : DbContext
    {
        public ProvaSitewareContext()
            : base("ProvaSitewareDBConnection")
        {

        }
    }
}
