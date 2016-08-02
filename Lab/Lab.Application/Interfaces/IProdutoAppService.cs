using Lab.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Application.Interfaces
{
    public interface IProdutoAppService : IAppServiceBase<Produto, int>
    {
        
    }
}
