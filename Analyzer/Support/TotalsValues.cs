using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.Analysis.Support
{
    public class TotalsValues
    {
        public string CompanyName { get; set; }
        public double? SharesOwned { get; set; }
        public double? SharesBought { get; set; }
        public double? SharesSold { get; set; }


        public double? ShareValue { get; set; }

        public double? TotalInvested { get; set; } //shares bought * share value


        public double? TotalWithdrawn { get; set; } // shares sold * share value

        public double? TotalValue { get; set; } // shares owned * share value

        public double? TotalGainLoss { get; set; } //total withdrwan + total value - total invested

        public double? Balance { get; set; } //total withdrawn + total value



    }
}
