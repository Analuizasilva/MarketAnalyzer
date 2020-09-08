using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.Analysis.Support
{
    public class TotalTransactions
    {
        public decimal? TotalInvested { get; set; } //shares bought * share value

        public decimal? TotalWithdrawn { get; set; } // shares sold * share value

        public decimal? TotalValue { get; set; } // shares owned * share value

        public decimal? TotalGainLoss { get; set; } //total withdrwan + total value - total invested

        public decimal? Balance { get; set; } //total withdrawn + total value
    }
}
