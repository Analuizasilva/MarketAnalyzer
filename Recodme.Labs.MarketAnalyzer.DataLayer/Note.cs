using Microsoft.AspNetCore.Identity;
using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.DataLayer
{
    public class Note:Entity
    {
        public string Description { get; set; }

        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public Guid AspNetUserId { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }

        public Note()
        {
        }

        public Note(Guid id, DateTime createdAt, DateTime updatedAd) : base(id, createdAt, updatedAd)
        {
        }

        
    }
}
