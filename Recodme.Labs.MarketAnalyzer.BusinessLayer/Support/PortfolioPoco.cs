using Recodme.Labs.MarketAnalyzer.Analysis.Support;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.Support
{
    public class PortfolioPoco
    {
        public string UserId { get; set; }
        public TotalTransactions TotalTransactions { get; set; }
        public List<CompanyTransactions> CompaniesTransactions { get; set; }
    }
}
