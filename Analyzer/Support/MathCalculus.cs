using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recodme.Labs.MarketAnalyzer.Analysis.Support
{
    public class MathCalculus
    {
        public List<ExtractedValue> Values { get; set; }

        public MathCalculus(){ }

        #region  CalculateGrowth
        public List<ExtractedValue> CalculateGrowth(List<ExtractedValue> values)
        {
            if (values == null) return null;
            if (values.Any(x => x.Value == null)) return null;
            List<ExtractedValue> sortedList = values.OrderBy(o => o.Year).ToList();
            var growthRate = new List<ExtractedValue>();
            for (var i = 0; i < (sortedList.Count - 1); i++)
            {
                var result = new ExtractedValue();
                var pastValue = sortedList[i].Value;
                var presentValue = sortedList[i + 1].Value;

                var growth = (presentValue - pastValue) / pastValue;
                result.Value = growth;
                result.Year = sortedList[i].Year + 1;
                result.CompanyId = sortedList[i].CompanyId;
                growthRate.Add(result);
            }
            return growthRate;
        }
        #endregion

        #region  CalculateLastThreeYearsGrowth
        public List<ExtractedValue> CalculateLastThreeYearsGrowth(List<ExtractedValue> values)
        {
            if (values == null) return null;
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
        #endregion

        #region  CalculateLastFiveYearsGrowth
        public double? CalculateLastFiveYearsGrowth(List<ExtractedValue> values)
        {
            if (values == null) return null;
            if (values.Any(x => x.Value == null)) return null;

            var lastFiveYearsValues = values.Skip(values.Count - 5).Take(5).ToList();

            var lastFiveYearsGrowth = Math.Pow((double)(lastFiveYearsValues[lastFiveYearsValues.Count - 1].Value / lastFiveYearsValues[0].Value), (1/lastFiveYearsValues.Count))-1;
            return lastFiveYearsGrowth;
        }
        #endregion

        #region  CalculateLastTenYearsGrowth
        public double? CalculateLastTenYearsGrowth(List<ExtractedValue> values)
        {
            if (values == null) return null;
            if (values.Any(x => x.Value == null)) return null;

            var lastTenYearsGrowth = Math.Pow((double)(values[values.Count-1].Value / values[0].Value), (1 / values.Count) - 1);
            return lastTenYearsGrowth;
        }
        #endregion

        #region CalculateMedian
        public double? CalculateMedian(List<ExtractedValue> values)
        {
            if (values == null) return null;
            if (values.Any(x => x.Value == null)) return null;
            double? median = 0;
            var middle = (int)Math.Ceiling((double)values.Count / 2);

            if (values.Count % 2 == 0 && values.Count > 1 && values.Count > 2 && values.Count != 0) median = ((values[middle].Value) + (values[middle + 1].Value)) / 2;
            if (values.Count == 1) median = values[0].Value;
            else median = values[middle].Value;
            return median;
        }
        #endregion

        #region CalculateDeviation
        public double? CalculateDeviation(List<ExtractedValue> values)
        {
            if (values == null) return null;
            if (values.Any(x => x.Value == null)) return null;
            double? nominalDeviation = 0;
            var median = CalculateMedian(values);
            double count = 0;
            double average = 0;

            foreach (var item in values)
            {
                var result = Math.Pow((double)(item.Value - median), 2);
                count += result;
            }

            average = count / values.Count;
            nominalDeviation = Math.Sqrt(average);

            var minimumValue = median - nominalDeviation;
            var maximumValue = median + nominalDeviation;
            var inValues = new List<ExtractedValue>();
            foreach(var value in values)
            {
                if(value.Value>=minimumValue && value.Value <= maximumValue)
                {
                    inValues.Add(value);
                }
            }
            var division = ((double?)inValues.Count / (double?)values.Count);
            var deviation =  division * 100;
            return deviation;
        }
        #endregion
    }
}
