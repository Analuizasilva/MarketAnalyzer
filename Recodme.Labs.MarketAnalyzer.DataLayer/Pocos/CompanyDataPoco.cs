using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.DataLayer.Pocos
{
    public class CompanyDataPoco
    {



        public virtual List<ExtractedBalanceSheet> BalanceSheets { get; set; }
        public virtual ExtractedCashFlowStatementTtm CashFlowStatementTtm { get; set; }
        public virtual List<ExtractedCashFlowStatement> CashFlowStatements { get; set; }
        public virtual ExtractedIncomeStatementTtm IncomeStatementTtm { get; set; }
        public virtual List<ExtractedIncomeStatement> IncomeStatements { get; set; }
        public virtual List<ExtractedKeyRatio> KeyRatios { get; set; }

        public virtual Company Company { get; set; }


    }
}
