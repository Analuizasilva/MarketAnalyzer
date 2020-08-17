using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.DataLayer
{
    public class DataSources : NamedEntity
    {
        public virtual ICollection<ExtractedBalanceSheets> ExtractedBalanceSheets { get; set; }
        public virtual ICollection<ExtractedCashFlowStatementTtms> ExtractedCashFlowStatementTtms { get; set; }
        public virtual ICollection<ExtractedCashFlowStatements> ExtractedCashFlowStatements { get; set; }
        public virtual ICollection<ExtractedIncomeStatementTtms> ExtractedIncomeStatementTtms { get; set; }
        public virtual ICollection<ExtractedIncomeStatements> ExtractedIncomeStatements { get; set; }
        public virtual ICollection<ExtractedKeyRatios> ExtractedKeyRatios { get; set; }

        public DataSources(string name) : base(name)
        {
        }

        public DataSources(Guid id, DateTime createdAt, DateTime updatedAt, string name) : base(id, createdAt, updatedAt, name)
        {
        }
        public DataSources()
        {
            ExtractedBalanceSheets = new HashSet<ExtractedBalanceSheets>();
            ExtractedCashFlowStatementTtms = new HashSet<ExtractedCashFlowStatementTtms>();
            ExtractedCashFlowStatements = new HashSet<ExtractedCashFlowStatements>();
            ExtractedIncomeStatementTtms = new HashSet<ExtractedIncomeStatementTtms>();
            ExtractedIncomeStatements = new HashSet<ExtractedIncomeStatements>();
            ExtractedKeyRatios = new HashSet<ExtractedKeyRatios>();
        }
    }
}
