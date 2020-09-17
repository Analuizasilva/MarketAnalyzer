using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.Analysis.Support
{
    public class CompanyTransactions
    {
        
        public string CompanyName { get; set; }
        public string Ticker { get; set; }


        public double? SharesBought { get; set; }
        public double? SharesSold { get; set; }
        public double? SharesOwned { get; set; }

        public decimal? CurrentShareValue { get; set; }


        [Display(Name = "Total Invested")]
        public decimal? TotalInvested { get; set; }



        [Display(Name = "Total Withdrawn")]
        public decimal? TotalWithdrawn { get; set; }

        [Display(Name = "Total Value")]
        public decimal? TotalCurrentSharesValue { get; set; }
        public decimal? TotalGainLoss { get; set; }
        public double? TotalGainLossPercentage { get; set; }


        [Display(Name = "Last Investment")]
        public DateTime DateofLastInvestment { get; set; }


        public Company Company { get; set; }
        public List<UserTransaction> UserTransactions { get; set; }
        public CompanyTransactions(){
            UserTransactions = new List<UserTransaction>();
            }

    }
}
