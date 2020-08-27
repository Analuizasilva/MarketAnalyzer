using Recodme.Labs.MarketAnalyzer.Analysis;
using Recodme.Labs.MarketAnalyzer.Analysis.Support;
using System.Collections.Generic;

namespace Recodme.Labs.MarketAnalyzer.WebAPI.Models.Support
{
    public class DetailsDataPoco
    {
        public string Ticker { get; set; }
        public string CompanyName { get; set; }
        public int? Forbes2000Rank { get; set; }
        public int MarketAnalyzerRank { get; set; }
        public decimal? StockPrice { get; set; }

        public List<ExtractedValue> Marketcap{ get; set; }
        public List<ExtractedValue> RevenueGrowth { get; set; }
        public List<ExtractedValue> EpsGrowth { get; set; }
        public List<ExtractedValue> EquityGrowth { get; set; }

        public double? DebtToEquity { get; set; }
        public double? AssetsToLiabilities { get; set; }
        public double? Roic { get; set; }
        public double? Equity{ get; set; }
        public double? EPS { get; set; }
        public double? Revenue { get; set; }
        public double? PERatio { get; set; }


        public double? DebtToEquityFitness { get; set; }
        public double? AssetsToLiabilitiesFitness { get; set; }
        public double? RoicFitness { get; set; }
        public double? EquityFitness { get; set; }
        public double? EPSFitness { get; set; }
        public double? RevenueFitness { get; set; }
        public double? PERatioFitness { get; set; }
        public double? TotalFitness { get; set; }

        public double? WeightNumberRoic { get; set; }
        public double? WeightNumberEquity { get; set; }
        public double? WeightNumberEPS { get; set; }
        public double? WeightNumberRevenue { get; set; }
        public double? WeightNumberPERatio { get; set; }
        public double? WeightNumberDebtToEquity { get; set; }
        public double? WeightNumberAssetsToLiabilities { get; set; }
    }
}
