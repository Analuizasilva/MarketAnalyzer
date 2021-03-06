﻿using Recodme.Labs.MarketAnalyzer.Analysis.Support;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Recodme.Labs.MarketAnalyzer.Analysis
{
    public class SlopeInfo
    {        
        public Trendline NominalTrendline{ get; set; }
        public Trendline GrowthTrendline { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public List<ExtractedValue> Growth { get; set; }
        public List<ExtractedValue> LastThreeYearsGrowth { get; set; }
        public double? NominalMedian { get; set; }
        public double? GrowthMedian { get; set; }
        public double? NominalDeviation { get; set; }
        public double? GrowthDeviation { get; set; }
        public  List<ExtractedValue> NominalValues { get; set; }
        public Trendline LastThreeYearsTrendLine{ get; set; }
        public double? LastFiveYearsGrowth { get; set; }
        public double? LastTenYearsGrowth { get; set; }

        public SlopeInfo(List<ExtractedValue> extractedValues)
        {
            var calculus = new MathCalculus();
            var trendline = new Trendline();

            if (extractedValues.Count != 0)
            {
                NominalValues = extractedValues;
                NominalTrendline = trendline.GetTrendline(extractedValues);
                Growth = calculus.CalculateGrowth(extractedValues);
                GrowthTrendline = trendline.GetTrendline(Growth);
                NominalMedian = calculus.CalculateMedian(extractedValues);
                GrowthMedian = calculus.CalculateMedian(Growth);
                NominalDeviation = calculus.CalculateDeviation(extractedValues);
                GrowthDeviation = calculus.CalculateDeviation(Growth);
                LastThreeYearsGrowth = calculus.CalculateLastThreeYearsGrowth(Growth);
                LastThreeYearsTrendLine = trendline.GetTrendline(LastThreeYearsGrowth);
                LastFiveYearsGrowth = calculus.CalculateLastFiveYearsGrowth(extractedValues);
                LastTenYearsGrowth = calculus.CalculateLastTenYearsGrowth(extractedValues);
            }          
        }
    }
}
