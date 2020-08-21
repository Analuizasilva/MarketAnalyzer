﻿using Recodme.Labs.MarketAnalyzer.Analysis.Support;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recodme.Labs.MarketAnalyzer.Analysis
{
    public class SlopeInfo
    {
        public Trendline NominalTrendline{ get; set; }
        public Trendline GrowthTrendline { get; set; }
        public List<ExtractedValue> Growth { get; set; }
        public double? NominalMedian { get; set; }
        public double? GrowthMedian { get; set; }
        public double? NominalDeviation { get; set; }
        public double? GrowthDeviation { get; set; }

        public SlopeInfo(List<ExtractedValue> extractedValues)
        {
            var calculus = new MathCalculus();
            var trendline = new Trendline();

            NominalTrendline = trendline.GetTrendline(extractedValues);
            Growth = calculus.CalculateGrowth(extractedValues);
            GrowthTrendline = trendline.GetTrendline(Growth);
            NominalMedian = calculus.CalculateMedian(extractedValues);
            GrowthMedian = calculus.CalculateMedian(Growth);
            NominalDeviation = calculus.CalculateDeviation(extractedValues);
            GrowthDeviation = calculus.CalculateDeviation(Growth);

        }
        //o que um slopeInfo recebe como parâmetro é a lista de extractedValues  
    }
}
