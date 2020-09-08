using Microsoft.AspNetCore.Identity;
using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords
{
    public class Note : Entity
    {
        public string Description { get; set; }

        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public string AspNetUserId { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }

        public double? WeightNumberRoic { get; set; } = 2;
        public double? WeightNumberEquity { get; set; } = 1.7;
        public double? WeightNumberEPS { get; set; } = 1.5;
        public double? WeightNumberRevenue { get; set; } = 1.3;
        public double? WeightNumberPERatio { get; set; } = 2;
        public double? WeightNumberDebtToEquity { get; set; } = 0.8;
        public double? WeightNumberAssetsToLiabilities { get; set; } = 0.8;


        public Note()
        {
        }

        public Note(Guid id, DateTime createdAt, DateTime updatedAd) : base(id, createdAt, updatedAd)
        {
        }

        public Note(Guid id, DateTime createdAt, DateTime updatedAd, double? weightNumberRoic, double? weightNumberEquity, double? weightNumberEPS, double? weightNumberRevenue, double? weightNumberPERatio, double? weightNumberDebtToEquity, double? weightNumberAssetsToLiabilities) : base(id, createdAt, updatedAd)
        {
            WeightNumberRoic = weightNumberRoic;
            WeightNumberEquity = weightNumberEquity;
            WeightNumberEPS = weightNumberEPS;
            WeightNumberRevenue = weightNumberRevenue;
            WeightNumberPERatio = weightNumberPERatio;
            WeightNumberDebtToEquity = weightNumberDebtToEquity;
            WeightNumberAssetsToLiabilities = weightNumberAssetsToLiabilities;
        }


    }
}
