using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.WebAPI.Models.Support
{
    public class HomeDataPoco
    {
        public string Ticker { get; set; }
        public string CompanyName { get; set; }
        public int MarketAnalyzerRank { get; set; }
        public int? Forbes2000Rank { get; set; }
        public double? Fitness { get; set; }
    }
}
