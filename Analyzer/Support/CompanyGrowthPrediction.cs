using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.Analysis.Support
{
    public class CompanyGrowthPrediction
    {
        public Guid CompanyId { get; set; }
        public int Year { get; set; }
        public double? MinValue { get; set; }
        public double? EspectedValue { get; set; }
        public double? MaxValue { get; set; }

        public double? MinValueFiveYears { get; set; }
        public double? EspectedValueFiveYears { get; set; }
        public double? MaxValueFiveYears { get; set; }

        public double? MinValueThreeYears { get; set; }
        public double? EspectedValueThreeYears { get; set; }
        public double? MaxValueThreeYears { get; set; }
    }
}
