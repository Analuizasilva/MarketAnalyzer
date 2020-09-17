using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.Analysis.Support
{
    public class PerYearResults
    {
        public int Year { get; set; }
        public decimal? Result { get; set; }
        public decimal? Invested { get; set; }
    }
}
