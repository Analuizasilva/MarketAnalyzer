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

        public List<ExtractedValue> Roic { get; set; }
        public double? DebtToEquity { get; set; }
        public double? AssetsToLiabilities { get; set; }
        public double? PERatio { get; set; }

        public double? SlopeRoic { get; set; }
        public double? MedianRoic { get; set; }
        public double? DeviationRoic { get; set; }

        public double? SlopeEquity{ get; set; }
        public double? MedianEquity{ get; set; }
        public double? DeviationEquity { get; set; }

        public double? SlopeEquityGrowth { get; set; }
        public double? MedianEquityGrowth { get; set; }
        public double? DeviationEquityGrowth { get; set; }

        public double? SlopeEps { get; set; }
        public double? MedianEps { get; set; }
        public double? DeviationEps { get; set; }

        public double? SlopeEpsGrowth { get; set; }
        public double? MedianEpsGrowth { get; set; }
        public double? DeviationEpsGrowth { get; set; }

        public double? SlopeRevenue { get; set; }
        public double? MedianRevenue { get; set; }
        public double? DeviationRevenue { get; set; }

        public double? SlopeRevenueGrowth { get; set; }
        public double? MedianRevenueGrowth { get; set; }
        public double? DeviationRevenueGrowth { get; set; }


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
