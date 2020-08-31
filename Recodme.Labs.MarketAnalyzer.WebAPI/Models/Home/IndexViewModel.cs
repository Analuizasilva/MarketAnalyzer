using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.Pocos;
using Recodme.Labs.MarketAnalyzer.WebAPI.Models.Support;
using static Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.AnalysisBusinessObject;

namespace Recodme.Labs.MarketAnalyzer.WebAPI.Models.Home
{
    public class IndexViewModel
    {
        public List<HomeDataPoco> HomeDataPocos { get; set; }
        public IndexViewModel()
        {
            HomeDataPocos = new List<HomeDataPoco>();

        }

        public double? WeightNumberRoic { get; set; } = 2;
        public double? WeightNumberEquity { get; set; } = 1.7;
        public double? WeightNumberEPS { get; set; } = 1.5;
        public double? WeightNumberRevenue { get; set; } = 1.3;
        public double? WeightNumberPERatio { get; set; } = 2;
        public double? WeightNumberDebtToEquity { get; set; } = 0.8;
        public double? WeightNumberAssetsToLiabilities { get; set; } = 0.8;

    }
}
