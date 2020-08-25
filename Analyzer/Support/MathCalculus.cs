using System;
using System.Collections.Generic;
using System.Linq;

namespace Recodme.Labs.MarketAnalyzer.Analysis.Support
{
    public class MathCalculus
    { 
        public List<ExtractedValue> Values { get; set; }

        public MathCalculus()
        {

        }

        public List<ExtractedValue> CalculateGrowth(List<ExtractedValue> values)
        {
            if (values.Any(x => x.Value == null)) return null;
            List<ExtractedValue> sortedList = values.OrderBy(o => o.Year).ToList();
            var growthRate = new List<ExtractedValue>();
            for (var i = 0; i < (sortedList.Count - 1); i++)
            {
                var result = new ExtractedValue();
                var beginningValue = sortedList[i].Value;
                var finalValue = sortedList[i + 1].Value;
                var division = (finalValue / beginningValue);
                float years = sortedList.Count;
                float pow = 1 / years;
                var growth = Math.Pow((double)division, pow) - 1;
                result.Value = growth;
                result.Year = sortedList[i].Year;
                result.CompanyId = sortedList[i].CompanyId;
                growthRate.Add(result);
            }
            return growthRate;
        }

        public List<ExtractedValue> CalculateLastThreeYearsGrowth(List<ExtractedValue> values)
        {
            if (values.Any(x => x.Value == null)) return null;

            var lastThreeYearsGrowth = new List<ExtractedValue>();
            if (values.Count < 4)
            {
                lastThreeYearsGrowth = values;
                return lastThreeYearsGrowth;
            }

            lastThreeYearsGrowth = values.Skip(values.Count - 3).Take(3).ToList();
            return lastThreeYearsGrowth;
        }

        public double? CalculateMedian(List<ExtractedValue> values)
        {
            double? median = 0;
            var middle = (int)Math.Ceiling((double)values.Count / 2);

            if (values.Count % 2 == 0 && values.Count > 1 && values.Count > 2 && values.Count != 0) median = ((values[middle].Value) + (values[middle + 1].Value)) / 2;
            if (values.Count == 1) median = values[0].Value;
            else median = values[middle].Value;
            return median;
        }

        public double? CalculateDeviation(List<ExtractedValue> values)
        {
            double? deviation = 0;
            var median = CalculateMedian(values);
            double count = 0;
            double average = 0;

            foreach (var item in values)
            {
                var result = Math.Pow((double)(item.Value - median), 2);
                count += result;
            }

            average = count / values.Count;
            deviation = Math.Sqrt(average);
            return deviation;
        }
    }
}
