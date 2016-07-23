using Lab.Application.Interfaces;
using Lab.Domain.Entities;
using Lab.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Application
{
    public class ProdutoAppService : AppServiceBase<Produto>, IProdutoAppService
    {
        private readonly IProdutoService service;

        public ProdutoAppService(IProdutoService service)
            : base(service)
        {
            this.service = service;
        }
    }
}
