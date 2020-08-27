using Recodme.Labs.MarketAnalyzer.Analysis;
using Recodme.Labs.MarketAnalyzer.DataLayer.Pocos;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.Support
{
    public class StockItemPoco
    {
        public StockItemPoco()
        {

        }
        public StockFitness StockFitness { get; set; }
        public CompanyDataPoco CompanyDataPoco { get; set; }
        public SlopeInfo SlopeInfo { get; set; }
        public StockAnalysis NominalValues { get; set; }
        public double? Fitness { get; set; }
        public decimal? StockPrice { get; set; }
        public int MarketAnalyzerRank { get; set; }
    }
}
