using System;

namespace Lab.Domain.Interfaces.Entities
{
    public interface IEntityBase<T> where T : IEquatable<T>
    {
        T Codigo { get; set; }
    }
}