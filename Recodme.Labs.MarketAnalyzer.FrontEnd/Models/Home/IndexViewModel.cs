using Recodme.Labs.MarketAnalyzer.FrontEnd.Models.Support;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Recodme.Labs.MarketAnalyzer.FrontEnd.Models.Home
{
    public class IndexViewModel
    {
        public List<HomeDataPoco> HomeDataPocos { get; set; }
        public IndexViewModel()
        {
            HomeDataPocos = new List<HomeDataPoco>();
        }
        [Display(Name = "Roic Weight")]
        public double? WeightNumberRoic { get; set; } = 2;
        [Display(Name = "Equity Weight")]
        public double? WeightNumberEquity { get; set; } = 1.7;
        [Display(Name = "EPS Weight")]
        public double? WeightNumberEPS { get; set; } = 1.5;
        [Display(Name = "Revenue Weight")]
        public double? WeightNumberRevenue { get; set; } = 1.3;
        [Display(Name = "PERatio Weight")]
        public double? WeightNumberPERatio { get; set; } = 2;
        [Display(Name = "Debt to Equity Weight")]
        public double? WeightNumberDebtToEquity { get; set; } = 0.8;
        [Display(Name = "Assets to Liabilities Weight")]
        public double? WeightNumberAssetsToLiabilities { get; set; } = 0.8;
        public string Ticker { get; set; }

    }
}
