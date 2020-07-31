using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Base
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        protected void RegisterChange()
        {
            UpdatedAt = DateTime.UtcNow;
        }

        protected Entity() : this(Guid.NewGuid(), DateTime.UtcNow, DateTime.UtcNow)
        {

        }

        protected Entity(Guid id, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
