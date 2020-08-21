using Recodme.Labs.MarketAnalyzer.Analysis.Support;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recodme.Labs.MarketAnalyzer.Analysis
{
    public class SlopeInfo
    {
        public Trendline Trendline { get; set; }
        public List<ExtractedValue> Growth { get; set; }
        public double? Median { get; set; }
        public double? Deviation { get; set; }

        public SlopeInfo(List<ExtractedValue> extractedValues)
        {
            var calculus = new MathCalculus();
            var trendline = new Trendline();

            Trendline = trendline.GetTrendline(extractedValues);
            Growth = calculus.CalculateGrowth(extractedValues);
            Median = calculus.CalculateMedian(extractedValues);
            Deviation = calculus.CalculateDeviation(extractedValues);

        }
        //o que um slopeInfo recebe como parâmetro é a lista de extractedValues  
    }
}
