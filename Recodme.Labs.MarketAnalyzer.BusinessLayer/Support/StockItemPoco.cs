using Recodme.Labs.MarketAnalyzer.Analysis;
using Recodme.Labs.MarketAnalyzer.Analysis.Support;
using Recodme.Labs.MarketAnalyzer.DataLayer.Pocos;
using System.Collections.Generic;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.Support
{
    public class StockItemPoco
    {
        public StockItemPoco()
        {

        }

        public StockAnalysis StockAnalysis { get; set; }
        public List<ExtractedValue> Marketcap { get; set; }
        public StockFitness StockFitness { get; set; }
        public CompanyDataPoco CompanyDataPoco { get; set; }
        public SlopeInfo SlopeInfo { get; set; }
        public List<ExtractedValue> NominalValues { get; set; }
        public double? Fitness { get; set; }
        public decimal? StockPrice { get; set; }
        public int MarketAnalyzerRank { get; set; }
    }
}
