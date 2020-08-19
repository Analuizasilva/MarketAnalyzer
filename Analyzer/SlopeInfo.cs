using Recodme.Labs.MarketAnalyzer.Analysis.Support;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.Analysis
{
    public class SlopeInfo
    {
        //o que um slopeInfo recebe como parâmetro é a lista de extractedValues

        public List<double> CalculateEquityGrowth(Guid companyId)
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

            List<ExtractedValue> sortedList = equity.OrderBy(o => o.Year).ToList();
            var equityGrowthRate = new List<double>();
            for (var i = 0; i < (sortedList.Count -1); i++ )
            {
                var beginningValue = sortedList[i].Value;
                var finalValue = sortedList[i + 1].Value;
                var result = (double)(finalValue / beginningValue);
                float years = sortedList.Count;
                float pow = 1 / years;
                var growth = Math.Pow(result, pow)-1;

                equityGrowthRate.Add(growth);
            }
            return equityGrowthRate;
        }


    }
}
