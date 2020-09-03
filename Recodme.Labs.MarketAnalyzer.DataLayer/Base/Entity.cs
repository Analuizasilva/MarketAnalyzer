using System;
using System.ComponentModel.DataAnnotations;

namespace Recodme.Labs.MarketAnalyzer.DataLayer.Base
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; protected set; }
    

        protected virtual void RegisterChange()
        {
            UpdatedAt = DateTime.UtcNow;
        }

        protected Entity()
        {
            Id = Guid.NewGuid();
            UpdatedAt = DateTime.UtcNow;
            CreatedAt = CreatedAt;          
        }

        protected Entity(Guid id, DateTime createdAt, DateTime updatedAd)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAd;        
        }
    }
}
