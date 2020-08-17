using System;
using System.Collections.Generic;

namespace Recodme.Labs.MarketAnalyzer.DataLayerTemp.Models
{
    public partial class DataSources
    {
        public DataSources()
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

        public virtual ICollection<ExtractedBalanceSheets> ExtractedBalanceSheets { get; set; }
        public virtual ICollection<ExtractedCashFlowStatementTtms> ExtractedCashFlowStatementTtms { get; set; }
        public virtual ICollection<ExtractedCashFlowStatements> ExtractedCashFlowStatements { get; set; }
        public virtual ICollection<ExtractedIncomeStatementTtms> ExtractedIncomeStatementTtms { get; set; }
        public virtual ICollection<ExtractedIncomeStatements> ExtractedIncomeStatements { get; set; }
        public virtual ICollection<ExtractedKeyRatios> ExtractedKeyRatios { get; set; }
    }
}
