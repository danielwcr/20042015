using ProvaSiteware.Domain.Entities;
using ProvaSiteware.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaSiteware.Infra.Data.NHibernate.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
    }
}
