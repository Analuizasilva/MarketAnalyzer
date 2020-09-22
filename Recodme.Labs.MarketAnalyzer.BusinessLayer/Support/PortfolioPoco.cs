using Recodme.Labs.MarketAnalyzer.Analysis.Support;
using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
using System;
using System.Collections.Generic;
using System.Text;
using static Recodme.Labs.MarketAnalyzer.Analysis.TransactionAnalysis;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.Support
{
    public class PortfolioPoco
    {
        public string UserId { get; set; }
        public TotalTransactions TotalTransactions { get; set; }
        public List<CompanyTransactions> CompaniesTransactions { get; set; }

        public List<UserTransaction> UserTransactions{ get; set; }

        public List<GraphTotal> PortfolioGraphInfo { get; set; }
    }
}
