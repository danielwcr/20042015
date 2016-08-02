using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab.Domain.Interfaces.Entities
{
    public interface IEntityBase<TId> : IValidatableObject where TId : IEquatable<TId>
    {
        TId Codigo { get; set; }

        bool IsValid();

        IEnumerable<ValidationResult> BrokenRules { get; }

        IEnumerable<ValidationResult> Validate();
    }
}