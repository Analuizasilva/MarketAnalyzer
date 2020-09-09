using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords
{
    public class WeightMultiplier : Entity
    {

        public string AspNetUserId { get; set; }

        public double? WeightNumberRoic { get; set; } = 2;
        public double? WeightNumberEquity { get; set; } = 1.7;
        public double? WeightNumberEPS { get; set; } = 1.5;
        public double? WeightNumberRevenue { get; set; } = 1.3;
        public double? WeightNumberPERatio { get; set; } = 2;
        public double? WeightNumberDebtToEquity { get; set; } = 0.8;
        public double? WeightNumberAssetsToLiabilities { get; set; } = 0.8;

        
    }
}
