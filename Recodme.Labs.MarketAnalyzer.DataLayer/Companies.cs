using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.DataLayer
{
    public class Companies : NamedEntity
    {
        public string Ticker { get; set; }
        public decimal StockPrice { get; set; }
        public string Country { get; set; }
        public bool? BuyR { get; set; }
        public bool? BuyL { get; set; }
        public string Notes { get; set; }
        public int? SandPrank { get; set; }
        public int? Forbes2000Rank { get; set; }
        public Guid? IndustryId { get; set; }

        public virtual Industries Industry { get; set; }
        public virtual ICollection<ExtractedBalanceSheets> ExtractedBalanceSheets { get; set; }
        public virtual ICollection<ExtractedCashFlowStatementTtms> ExtractedCashFlowStatementTtms { get; set; }
        public virtual ICollection<ExtractedCashFlowStatements> ExtractedCashFlowStatements { get; set; }
        public virtual ICollection<ExtractedIncomeStatementTtms> ExtractedIncomeStatementTtms { get; set; }
        public virtual ICollection<ExtractedIncomeStatements> ExtractedIncomeStatements { get; set; }
        public virtual ICollection<ExtractedKeyRatios> ExtractedKeyRatios { get; set; }

        public Companies(string name) : base(name)
        {
            ExtractedBalanceSheets = new HashSet<ExtractedBalanceSheets>();
            ExtractedCashFlowStatementTtms = new HashSet<ExtractedCashFlowStatementTtms>();
            ExtractedCashFlowStatements = new HashSet<ExtractedCashFlowStatements>();
            ExtractedIncomeStatementTtms = new HashSet<ExtractedIncomeStatementTtms>();
            ExtractedIncomeStatements = new HashSet<ExtractedIncomeStatements>();
            ExtractedKeyRatios = new HashSet<ExtractedKeyRatios>();
        }

        public Companies(Guid id, DateTime createdAt, DateTime updatedAt, string name) : base(id, createdAt, updatedAt, name)
        {
        }
    }
}
