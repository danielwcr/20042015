using Lab.Domain.Entities;
using Lab.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Infra.Data.NH.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto, int>, IProdutoRepository
    {
    }
}
