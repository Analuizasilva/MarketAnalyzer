using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recodme.Labs.MarketAnalyzer.Analysis.Support
{
    public class Growth
    {
        public List<ExtractedValue> Values { get; set; }

        public Growth(List<ExtractedValue> values)
        {
            Values = CalculateGrowth(values);
        }

        public List<ExtractedValue> CalculateGrowth(List<ExtractedValue> values)
        {
            List<ExtractedValue> sortedList = values.OrderBy(o => o.Year).ToList();
            var growthRate = new List<ExtractedValue>();
            for (var i = 0; i < (sortedList.Count - 1); i++)
            {
                var result = new ExtractedValue();
                var beginningValue = sortedList[i].Value;
                var finalValue = sortedList[i + 1].Value;
                var division = (double)(finalValue / beginningValue);
                float years = sortedList.Count;
                float pow = 1 / years;
                var growth = Math.Pow(division, pow) - 1;
                result.Value = growth;
                result.Year = sortedList[i].Year;
                result.CompanyId = sortedList[i].CompanyId;
                growthRate.Add(result);
            }
            return growthRate;
        }
    }
}
