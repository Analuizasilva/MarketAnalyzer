using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.Analysis.Support
{
    public class OtherTrendlines
    {
        public double? GetMaxGrowthValue(List<ExtractedValue> values, int year)
        {
            //            y(t) = a × ekt

            //Where y(t) = value at time "t"
            //a = value at the start
            //k = rate of growth(when > 0) or decay(when<0)
            //t = time
            var firstYear = values.Min(x => x.Year);
            var lastYear = values.Max(x => x.Year);
            var firstValue = values.Where(x => x.Year == values.Min(x => x.Year)).SingleOrDefault().Value;
            var lastValue = values.Where(x => x.Year == lastYear).SingleOrDefault().Value;
            var a = values.Where(x => x.Year == values.Min(x => x.Year)).SingleOrDefault().Value;

            var k = Math.Pow((double)(lastValue / firstValue), (1 / values.Count)) - 1;

            var futureValueForYear = a * Math.Exp(k * year);
            return futureValueForYear;
        }

        public double? GetMinGrowthValue(List<ExtractedValue> values, int year)
        {
            //y = a + bln(x)

            var firstYear = values.Min(x => x.Year);
            var lastYear = values.Max(x => x.Year);
            var firstValue = values.Where(x => x.Year == values.Min(x => x.Year)).SingleOrDefault().Value;
            var lastValue = values.Where(x => x.Year == lastYear).SingleOrDefault().Value;

            
            var b = (firstValue - lastValue) / (Math.Log(firstYear) - Math.Log(lastYear));
            var a = lastValue - b * Math.Log(lastYear);

            var futureMinValue = a + b * Math.Log(year);

            return futureMinValue;
        }
    }
}
