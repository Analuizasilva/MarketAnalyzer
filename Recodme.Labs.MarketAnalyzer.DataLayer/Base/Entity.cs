﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Recodme.Labs.MarketAnalyzer.DataLayer.Base
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateUpdated { get; protected set; }

        private bool _isDeleted;
        public bool IsDeleted
        {
            get
            {
                return _isDeleted;
            }
            set
            {
                _isDeleted = value;
                RegisterChange();
            }
        }


        protected virtual void RegisterChange()
        {
            DateUpdated = DateTime.UtcNow;
        }

        protected Entity()
        {
            Id = Guid.NewGuid();
            DateUpdated = DateTime.UtcNow;
            DateCreated = DateCreated;  
        }

        protected Entity(Guid id, DateTime createdAt, DateTime updatedAd)
        {
            Id = id;
            DateCreated = createdAt;
            DateUpdated = updatedAd;        
        }

        protected Entity(Guid id, DateTime createdAt, DateTime updatedAd, bool isDeleted)
        {
            Id = id;
            DateCreated = createdAt;
            DateUpdated = updatedAd;
            IsDeleted = isDeleted;
        }
    }
}
