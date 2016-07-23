using Lab.Domain.Interfaces.Entities;
using System.ComponentModel.DataAnnotations;

namespace Lab.Domain.Entities
{
    public class EntityBase : IEntityBase<int>
    {
        [Key]
        public virtual int Codigo { get; set; }
    }
}
