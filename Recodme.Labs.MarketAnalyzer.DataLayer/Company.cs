using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.DataLayer
{
    public class Company : NamedEntity
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

        public virtual Industry Industry { get; set; }
        public virtual ICollection<ExtractedBalanceSheet> ExtractedBalanceSheets { get; set; }
        public virtual ICollection<ExtractedCashFlowStatementTtm> ExtractedCashFlowStatementTtms { get; set; }
        public virtual ICollection<ExtractedCashFlowStatement> ExtractedCashFlowStatements { get; set; }
        public virtual ICollection<ExtractedIncomeStatementTtm> ExtractedIncomeStatementTtms { get; set; }
        public virtual ICollection<ExtractedIncomeStatement> ExtractedIncomeStatements { get; set; }
        public virtual ICollection<ExtractedKeyRatio> ExtractedKeyRatios { get; set; }

        public Company(string name, string ticker) : base(name)
        {
            Ticker = ticker;
        }

        public Company(string name) : base(name)
        {
            ExtractedBalanceSheets = new HashSet<ExtractedBalanceSheet>();
            ExtractedCashFlowStatementTtms = new HashSet<ExtractedCashFlowStatementTtm>();
            ExtractedCashFlowStatements = new HashSet<ExtractedCashFlowStatement>();
            ExtractedIncomeStatementTtms = new HashSet<ExtractedIncomeStatementTtm>();
            ExtractedIncomeStatements = new HashSet<ExtractedIncomeStatement>();
            ExtractedKeyRatios = new HashSet<ExtractedKeyRatio>();
        }

        public Company(Guid id, DateTime createdAt, DateTime updatedAt, string name) : base(id, createdAt, updatedAt, name)
        {
        }
    }
}
