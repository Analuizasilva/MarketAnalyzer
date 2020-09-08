using Microsoft.AspNetCore.Identity;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords
{
    public class CompanyUserRelationship:Entity
    {
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public string AspNetUserId { get; set; }


        public ICollection<UserTransaction> UserTransactions { get; set; }
        public CompanyUserRelationship()
        {
        }
        public CompanyUserRelationship(Guid companyId, string userId)
        {
            CompanyId = companyId;
            AspNetUserId =userId;
        }

        public CompanyUserRelationship(Guid id, DateTime createdAt, DateTime updatedAd) : base(id, createdAt, updatedAd)
        {
        }
    }
}
