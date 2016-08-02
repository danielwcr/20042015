using Lab.Domain.Interfaces.Entities;
using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab.Domain.Entities
{
    public abstract class EntityBase<TId> : IEntityBase<TId> where TId : IEquatable<TId>
    {
        [Key]
        public virtual TId Codigo { get; set; }

        public virtual IEnumerable<ValidationResult> BrokenRules
        {
            get
            {
                var validationResults = new List<ValidationResult>();
                var validationContext = new ValidationContext(this);

                Validator.TryValidateObject(this, validationContext, validationResults, true);

                return validationResults;
            }
        }

        public virtual bool IsValid() => !BrokenRules.Any();

        public virtual IEnumerable<ValidationResult> Validate() => Enumerable.Empty<ValidationResult>();

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => Validate();

        protected virtual ValidationResult AddBrokenRule(string message, string member)
        {
            return new ValidationResult(message, new string[] { member });
        }
    }
}
