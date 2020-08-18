using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.Analysis.Support
{
    public class ExtractedValue
    {
        public int Year { get; set; }

        public double? Value { get; set; }

        public Guid CompanyId { get; set; }
    }
}
