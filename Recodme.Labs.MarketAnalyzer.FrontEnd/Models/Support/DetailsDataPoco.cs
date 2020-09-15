using Recodme.Labs.MarketAnalyzer.Analysis.Support;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Recodme.Labs.MarketAnalyzer.FrontEnd.Models.Support
{
    public class DetailsDataPoco
    {
        public string Ticker { get; set; }
        public string CompanyName { get; set; }
        public int? Forbes2000Rank { get; set; }
        public int MarketAnalyzerRank { get; set; }
        public decimal? StockPrice { get; set; }


        public double? MedianRoic { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? DeviationRoic { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]

        public double? SlopeEquity{ get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? MedianEquity{ get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? DeviationEquity { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? SlopeEquityGrowth { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? MedianEquityGrowth { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? DeviationEquityGrowth { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? SlopeEps { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? MedianEps { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? DeviationEps { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? SlopeEpsGrowth { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? MedianEpsGrowth { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? DeviationEpsGrowth { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? SlopeRevenue { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? MedianRevenue { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? DeviationRevenue { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? SlopeRevenueGrowth { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? MedianRevenueGrowth { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? DeviationRevenueGrowth { get; set; }

        public int? StarRaking { get; set; }
        public double? Outperform { get; set; }
        public double? Underperform { get; set; }


        #region Nominal Values
        public List<ExtractedValue> Roic { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? DebtToEquity { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? AssetsToLiabilities { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? PERatio { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? SlopeRoic { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        #endregion

        #region Marketcap
        public double? MarketCapLastFiveYearsGrowth { get; set; }      
        public double? MarketCapLastTenYearsGrowth { get; set; }
        public List<ExtractedValue> Marketcap { get; set; }
        public double? MedianMarketCapGrowth { get; set; }
        #endregion

        #region Growth
        public List<ExtractedValue> RevenueGrowth { get; set; }      
        public List<ExtractedValue> EpsGrowth { get; set; }       
        public List<ExtractedValue> EquityGrowth { get; set; }       
        #endregion      

        #region Fitness
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
        #endregion

        #region Weight Number
        public double? WeightNumberRoic { get; set; }
        public double? WeightNumberEquity { get; set; }
        public double? WeightNumberEPS { get; set; }
        public double? WeightNumberRevenue { get; set; }
        public double? WeightNumberPERatio { get; set; }
        public double? WeightNumberDebtToEquity { get; set; }
        public double? WeightNumberAssetsToLiabilities { get; set; }
        #endregion

        #region Nominal Values
        public List<ExtractedValue> EquityNominalValues { get; set; }
        public List<ExtractedValue> EPSNominalValues { get; set; }
        public List<ExtractedValue> RevenueNominalValues { get; set; }
        #endregion
    }
}
