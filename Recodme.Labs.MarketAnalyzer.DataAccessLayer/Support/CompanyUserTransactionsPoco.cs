using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.DataAccessLayer.Support
{
    public class CompanyUserTransactionsPoco
    {
        public string UserId { get; set; }
        public Guid CompanyId { get; set; }
        public string Ticker { get; set; }
        public string CompanyName { get; set; }
        public decimal? StockPrice { get; set; }
        public List<UserTransaction> UserTransactions { get; set; }

        public CompanyUserTransactionsPoco()
        {
            UserTransactions = new List<UserTransaction>();
        }
    }
}
