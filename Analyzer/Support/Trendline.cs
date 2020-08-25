using System;
using System.Collections.Generic;
using System.Linq;

namespace Recodme.Labs.MarketAnalyzer.Analysis.Support
{
    public class Trendline
    {
        private readonly IList<int> xAxisValues;
        private readonly IList<double?> yAxisValues;
        private int count;
        private int xAxisValuesSum;
        private int xxSum;
        private double? xySum;
        private double? yAxisValuesSum;

        public Trendline(IList<double?> yAxisValues, IList<int> xAxisValues)
        {
            this.yAxisValues = yAxisValues;
            this.xAxisValues = xAxisValues;

            this.Initialize();
        }

        public double? Slope { get; private set; }
        public double? Intercept { get; private set; }
        public double? Start { get; private set; }
        public double? End { get; private set; }

        private void Initialize()
        {
            this.count = this.yAxisValues.Count;
            this.yAxisValuesSum = this.yAxisValues.Sum();
            this.xAxisValuesSum = this.xAxisValues.Sum();
            this.xxSum = 0;
            this.xySum = 0;

            for (int i = 0; i < this.count; i++)
            {
                this.xySum += (this.xAxisValues[i] * this.yAxisValues[i]);
                this.xxSum += (this.xAxisValues[i] * this.xAxisValues[i]);
            }

            this.Slope = this.CalculateSlope();
            this.Intercept = this.CalculateIntercept();
            this.Start = this.CalculateStart();
            this.End = this.CalculateEnd();
        }

        private double? CalculateSlope()
        {
            try
            {
                return ((this.count * this.xySum) - (this.xAxisValuesSum * this.yAxisValuesSum)) / ((this.count * this.xxSum) - (this.xAxisValuesSum * this.xAxisValuesSum));
            }
            catch (DivideByZeroException)
            {
                return 0;
            }
        }

        private double? CalculateIntercept()
        {
            return (this.yAxisValuesSum - (this.Slope * this.xAxisValuesSum)) / this.count;
        }

        private double? CalculateStart()
        {
            return (this.Slope * this.xAxisValues.First()) + this.Intercept;
        }

        private double? CalculateEnd()
        {
            return (this.Slope * this.xAxisValues.Last()) + this.Intercept;
        }

        public Trendline GetTrendline(List<ExtractedValue> values)
        {
            if (values == null) return null;
            var sortedList = new List<ExtractedValue>();
            sortedList = values.OrderBy(o => o.Year).ToList();

            var xValues = new List<int>();
            var yValues = new List<double?>();

            foreach (var item in sortedList)
            {
                xValues.Add(item.Year);
                yValues.Add((double?)item.Value);
            }
            return new Trendline(yValues, xValues);
        }

        public Trendline()
        {
        }
    }
}
