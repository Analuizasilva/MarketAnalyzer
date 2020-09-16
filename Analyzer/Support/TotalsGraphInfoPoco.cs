using System.Collections.Generic;

namespace Recodme.Labs.MarketAnalyzer.Analysis.Support
{
    public class TotalsGraphInfoPoco
    {
        public int Year { get; set; }
        public decimal? TotalInvested { get; set; }
        public decimal? TotalWithdrawn { get; set; }
        public double? GrowthPercentage { get; set; }
        public double? TotalGainLossPercentage { get; set; }
        public decimal? CurrentValue { get; set; }
    }
}
