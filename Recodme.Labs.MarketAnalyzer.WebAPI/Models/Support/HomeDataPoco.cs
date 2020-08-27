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

        [Display(Name = "Stock Price (USD)")]
        public decimal StockPrice { get; set; }

        public double? Fitness { get; set; }
    }
}
