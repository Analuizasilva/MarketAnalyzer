using Recodme.Labs.MarketAnalyzer.Analysis;
using Recodme.Labs.MarketAnalyzer.Analysis.Support;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Recodme.Labs.MarketAnalyzer.WebAPI.Models.Support
{
    public class DetailsDataPoco
    {
        public string Ticker { get; set; }
        public string CompanyName { get; set; }
        public int? Forbes2000Rank { get; set; }
        public int MarketAnalyzerRank { get; set; }
        public decimal? StockPrice { get; set; }

        public double? MarketCapLastFiveYearsGrowth { get; set; }
        public double? MarketCapLastTenYearsGrowth { get; set; }
        public List<ExtractedValue> Marketcap { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public List<ExtractedValue> RevenueGrowth { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public List<ExtractedValue> EpsGrowth { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public List<ExtractedValue> EquityGrowth { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public List<ExtractedValue> EquityNominalValues { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public List<ExtractedValue> EPSNominalValues { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public List<ExtractedValue> RevenueNominalValues { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? DebtToEquity { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? AssetsToLiabilities { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public List<ExtractedValue> Roic { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? Equity { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? EPS { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? Revenue { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? PERatio { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? DebtToEquityFitness { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? AssetsToLiabilitiesFitness { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? RoicFitness { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? EquityFitness { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? EPSFitness { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? RevenueFitness { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? PERatioFitness { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
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
