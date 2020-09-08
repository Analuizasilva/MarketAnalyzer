using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.Support
{
    public class PortfolioPoco
    {
        public string UserId { get; set; }
        public Guid CompanyId { get; set; }
        public List<UserTransaction> UserTransactions { get; set; }

        public PortfolioPoco()
        {
            UserTransactions = new List<UserTransaction>();
        }
    }
}
