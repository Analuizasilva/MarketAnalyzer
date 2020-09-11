using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.Analysis.Support
{
    public class CompanyTransactions
    {
        public Company Company { get; set; }
        public string CompanyName { get; set; }
        public string Ticker { get; set; }
        public List<UserTransaction> UserTransactions { get; set; }

        public double? SharesBought { get; set; }
        public double? SharesSold { get; set; }
        public double? SharesOwned { get; set; }

        public decimal? ShareValue { get; set; }

        public decimal? Invested { get; set; }
        public decimal? Withdrawn { get; set; }
        public decimal? TotalSharesValue { get; set; }
        public decimal? TotalGainLoss { get; set; }


    }
}
