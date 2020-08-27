using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.WebAPI.Models.Support
{
    public class HomeDataPoco
    {

        public string Ticker { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Market Analyzer Rank")]
        public int MarketAnalyzerRank { get; set; }

        [Display(Name = "Forbes 2000 Rank")]
        public int? Forbes2000Rank { get; set; }

        public double? Fitness { get; set; }
    }
}
