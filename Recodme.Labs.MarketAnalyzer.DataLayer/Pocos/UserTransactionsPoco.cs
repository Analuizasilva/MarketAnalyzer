using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.DataLayer.Pocos
{
    public class UserTransactionsPoco
    {
        public int Year { get; set; }
        public List<UserTransaction> UserTransactions { get; set; }
    }
}
