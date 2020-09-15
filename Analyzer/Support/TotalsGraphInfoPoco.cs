using System.Collections.Generic;

namespace Recodme.Labs.MarketAnalyzer.Analysis.Support
{
    public class TotalsGraphInfoPoco
    {
        public List<int> Years { get; set; }
        public List<double?> GrowthPercentages { get; set; }
        public List<double> TotalGainLossPercentages { get; set; }
        public List<decimal> CurrentValues { get; set; }
    }
}
