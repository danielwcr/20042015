using Lab.Domain.Entities;
using Lab.Domain.Interfaces.Repositories;
using Lab.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab.Domain.Services
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        private readonly IProdutoRepository repository;

        public ProdutoService(IProdutoRepository repository)
            : base(repository)
        {
            this.repository = repository;
        }

        public override void Insert(Produto obj)
        {
            //obj.Nome = null;
            //obj.Preco = -1;

            //var context = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            //var validations = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            //var isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(obj, context, validations, true);

            //var aa = new System.ComponentModel.DataAnnotations.ValidationResult("teste", new List<string> { "Preco" });

            base.Insert(obj);
        }
    }
}
