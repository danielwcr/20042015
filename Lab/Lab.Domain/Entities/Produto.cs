using Lab.Domain.Common;
using Lab.Resources;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Lab.Domain.Entities
{
    public class Produto : EntityBase<int>
    {
        private Promocao promocao;

        [Required]
        [MaxLength(200)]
        [Display(Name = nameof(Nome), ResourceType = typeof(Resource))]
        public virtual string Nome { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0.01, 99999999)]
        [Display(Name = nameof(Preco), ResourceType = typeof(Resource))]
        public virtual decimal Preco { get; set; }

        [Display(Name = nameof(Promocao), ResourceType = typeof(Resource))]
        public virtual TipoPromocao TipoPromocao { get; set; }

        [Display(Name = nameof(Promocao), ResourceType = typeof(Resource))]
        public virtual Promocao Promocao
        {
            get
            {
                if (promocao == null)
                    promocao = Promocao.Obter(TipoPromocao);

                return promocao;
            }
        }

        public override IEnumerable<ValidationResult> Validate()
        {
            if (Preco == 123456)
                yield return AddBrokenRule(Resource.PrecoNaoPodeSer123456, nameof(Preco));
        }
    }
}
