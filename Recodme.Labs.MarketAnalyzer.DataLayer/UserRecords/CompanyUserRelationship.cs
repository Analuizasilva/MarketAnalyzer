using Microsoft.AspNetCore.Identity;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords
{
    public class CompanyUserRelationship
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public string AspNetUserId { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }

        public ICollection<UserTransaction> UserTransactions { get; set; }


    }
}
