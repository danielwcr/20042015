using Lab.Domain.Common;
using Lab.Resources;
using System.ComponentModel.DataAnnotations;

namespace Lab.Domain.Entities
{
    public class Produto : EntityBase
    {
        private Promocao promocao;

        [Required]
        [MaxLength(200)]
        public virtual string Nome { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0, 9999999.99)]
        public virtual decimal Preco { get; set; }

        public virtual TipoPromocao TipoPromocao { get; set; }

        public virtual Promocao Promocao
        {
            get
            {
                if (promocao == null)
                    promocao = Promocao.Obter(TipoPromocao);

                return promocao;
            }
        }

        public virtual void Validate()
        {
            Validator.ValidateObject(this, new ValidationContext(this), true);
        }
    }
}
