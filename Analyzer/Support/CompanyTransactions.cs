using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.Analysis.Support
{
    public class CompanyTransactions
    {
        public List<UserTransaction> UserTransactions { get; set; }
        public string CompanyName { get; set; }
        public string Ticker { get; set; }
        public double? SharesOwned { get; set; }
        public double? SharesBought { get; set; }
        public double? SharesSold { get; set; }


        public decimal? ShareValue { get; set; }

        public decimal? Invested { get; set; } //shares bought * share value


        public decimal? Withdrawn { get; set; } // shares sold * share value

        public decimal? TotalSharesValue { get; set; } // shares owned * share value

        public decimal? TotalGainLoss { get; set; } //total withdrwan + total value - total invested

    }
}
