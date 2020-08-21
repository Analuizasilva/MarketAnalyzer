﻿using System;
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

        public double? CalculateMedian(List<ExtractedValue> values)
        {
            double? median = 0;
            var middle = (int)Math.Ceiling((double)values.Count / 2);

            if (values.Count % 2 == 0)
            {
                median = ((values[middle].Value) + (values[middle + 1].Value)) / 2;
            }
            else
            {
                median = values[middle].Value;

            }
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