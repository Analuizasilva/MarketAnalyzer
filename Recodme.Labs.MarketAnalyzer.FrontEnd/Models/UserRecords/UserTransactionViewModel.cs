using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recodme.Labs.MarketAnalyzer.Analysis.Support;
using Recodme.Labs.MarketAnalyzer.DataLayer;

namespace Recodme.Labs.MarketAnalyzer.FrontEnd.Models.UserRecords
{
    public class UserTransactionViewModel
    {
        
        public enum IsPurchaseOrSale
        {
            Purchase,
                Sale
        }
        [Display(Name = "Type of Transaction")]
        public IsPurchaseOrSale IsAPurchaseOrSale { get; set; }


        [Display(Name = "Company")]
        public List<Company> Companies { get; set; }


        [Display(Name = "Company")]
        public Guid CompanyId { get; set; }


        [Display(Name = "Company")]
        public string Ticker { get; set; }

        public string AspNetUserId { get; set; }

        [Display(Name = "Number of Shares")]
        public double? NumberOfShares { get; set; }
        [Display(Name = "Value of Shares")]
        public decimal? ValueOfShares { get; set; }
        [Display(Name = "Number of Shares Withdrawn")]
        public double? NumberOfSharesWithdrawn { get; set; }
        [Display(Name = "Value of Shares Withdrawn")]
        public decimal? ValueOfSharesWithdrawn { get; set; }
        [Display(Name = "Date of Movement")]
        public DateTime DateOfMovement { get; set; }


        public TotalTransactions TotalTransactions { get; set; }
        public List<CompanyTransactions> CompaniesTransactions { get; set; }

        public UserTransactionViewModel()
        {
            Companies = new List<Company>();
            CompaniesTransactions = new List<CompanyTransactions>();
            IsAPurchaseOrSale = new IsPurchaseOrSale();
            
        }

        [Display(Name = "Roic Weight")]
        public double? WeightNumberRoic { get; set; } = 2;
        [Display(Name = "Equity Weight")]
        public double? WeightNumberEquity { get; set; } = 1.7;
        [Display(Name = "EPS Weight")]
        public double? WeightNumberEPS { get; set; } = 1.5;
        [Display(Name = "Revenue Weight")]
        public double? WeightNumberRevenue { get; set; } = 1.3;
        [Display(Name = "PERatio Weight")]
        public double? WeightNumberPERatio { get; set; } = 2;
        [Display(Name = "Debt to Equity Weight")]
        public double? WeightNumberDebtToEquity { get; set; } = 0.8;
        [Display(Name = "Assets to Liabilities Weight")]
        public double? WeightNumberAssetsToLiabilities { get; set; } = 0.8;

    }
}
