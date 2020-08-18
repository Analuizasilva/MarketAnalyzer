using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.DataLayer
{
    public class DataSource : NamedEntity
    {
        public virtual ICollection<ExtractedBalanceSheet> ExtractedBalanceSheets { get; set; }
        public virtual ICollection<ExtractedCashFlowStatementTtm> ExtractedCashFlowStatementTtms { get; set; }
        public virtual ICollection<ExtractedCashFlowStatement> ExtractedCashFlowStatements { get; set; }
        public virtual ICollection<ExtractedIncomeStatementTtm> ExtractedIncomeStatementTtms { get; set; }
        public virtual ICollection<ExtractedIncomeStatement> ExtractedIncomeStatements { get; set; }
        public virtual ICollection<ExtractedKeyRatio> ExtractedKeyRatios { get; set; }

        public DataSource(string name) : base(name)
        {
            ExtractedBalanceSheets = new HashSet<ExtractedBalanceSheet>();
            ExtractedCashFlowStatementTtms = new HashSet<ExtractedCashFlowStatementTtm>();
            ExtractedCashFlowStatements = new HashSet<ExtractedCashFlowStatement>();
            ExtractedIncomeStatementTtms = new HashSet<ExtractedIncomeStatementTtm>();
            ExtractedIncomeStatements = new HashSet<ExtractedIncomeStatement>();
            ExtractedKeyRatios = new HashSet<ExtractedKeyRatio>();
        }

        public DataSource(Guid id, DateTime createdAt, DateTime updatedAt, string name) : base(id, createdAt, updatedAt, name)
        {
        }
    }
}
