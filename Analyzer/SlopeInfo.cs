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

        public SlopeInfo(List<ExtractedValue> extractedValues)
        {
        }

        //o que um slopeInfo recebe como parâmetro é a lista de extractedValues
       
        public Trendline GetTrendline(List<ExtractedValue> values)
        {
            
            List<ExtractedValue> sortedList = null;
            sortedList = values.OrderBy(o => o.Year).ToList();
           
            var xValues = new List<int>();
            var yValues = new List<double>();

            foreach (var item in sortedList)
            {
                xValues.Add(item.Year);
                yValues.Add((double)item.Value);
            }
            return new Trendline(yValues, xValues);
        }
    }
}
