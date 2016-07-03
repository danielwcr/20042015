using ProvaSiteware.Application.Interfaces;
using ProvaSiteware.Domain.Entities;
using ProvaSiteware.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaSiteware.Application
{
    public class ProdutoAppService : AppEntityServiceBase<Produto>, IProdutoAppService
    {
        private readonly IProdutoService service;

        public ProdutoAppService(IProdutoService service)
            : base(service)
        {
            this.service = service;
        }
    }
}
