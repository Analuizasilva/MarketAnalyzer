using System;
using System.Collections.Generic;

namespace Recodme.Labs.MarketAnalyzer.DataLayerTemp.Models
{
    public partial class Companies
    {
        public Companies()
        {
            ExtractedBalanceSheets = new HashSet<ExtractedBalanceSheets>();
            ExtractedCashFlowStatementTtms = new HashSet<ExtractedCashFlowStatementTtms>();
            ExtractedCashFlowStatements = new HashSet<ExtractedCashFlowStatements>();
            ExtractedIncomeStatementTtms = new HashSet<ExtractedIncomeStatementTtms>();
            ExtractedIncomeStatements = new HashSet<ExtractedIncomeStatements>();
            ExtractedKeyRatios = new HashSet<ExtractedKeyRatios>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Ticker { get; set; }
        public decimal StockPrice { get; set; }
        public string Country { get; set; }
        public bool? BuyR { get; set; }
        public bool? BuyL { get; set; }
        public string Notes { get; set; }
        public int? SandPrank { get; set; }
        public int? Forbes2000Rank { get; set; }
        public Guid? IndustryId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual Industries Industry { get; set; }
        public virtual ICollection<ExtractedBalanceSheets> ExtractedBalanceSheets { get; set; }
        public virtual ICollection<ExtractedCashFlowStatementTtms> ExtractedCashFlowStatementTtms { get; set; }
        public virtual ICollection<ExtractedCashFlowStatements> ExtractedCashFlowStatements { get; set; }
        public virtual ICollection<ExtractedIncomeStatementTtms> ExtractedIncomeStatementTtms { get; set; }
        public virtual ICollection<ExtractedIncomeStatements> ExtractedIncomeStatements { get; set; }
        public virtual ICollection<ExtractedKeyRatios> ExtractedKeyRatios { get; set; }
    }
}
