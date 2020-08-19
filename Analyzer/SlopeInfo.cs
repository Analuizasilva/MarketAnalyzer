using Recodme.Labs.MarketAnalyzer.Analysis.Support;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.Analysis
{
    public class SlopeInfo
    {
        //o que um slopeInfo recebe como parâmetro é a lista de extractedValues

        public List<ExtractedValue> CalculateEquityGrowth(Guid companyId)
        {
            var bo = new DataBaseBusinessObject();
            var balanceSheets = bo.GetBalanceSheets().Result;
            var companies = bo.GetCompanies().Result;
            var equity = new List<ExtractedValue>();
            foreach (var item in companies)
            {
                if (item.Id == companyId)
                {
                    var financialAnalysis = new FinancialAnalysis();
                    equity = financialAnalysis.GetEquity(balanceSheets, item.Id);
                }
            }



            return equity;
        }


    }
}
