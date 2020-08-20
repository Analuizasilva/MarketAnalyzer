using Recodme.Labs.MarketAnalyzer.Analysis.Support;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recodme.Labs.MarketAnalyzer.Analysis
{
    public class SlopeInfo
    {
        public Trendline Trendline { get; set; }
        public List<ExtractedValue> Growth { get; set; }

        public SlopeInfo(List<ExtractedValue> extractedValues)
        {
        }

        //o que um slopeInfo recebe como parâmetro é a lista de extractedValues
       
        public Trendline GetTrendlineEquity(Guid companyId)
        {
            var bo = new DataBaseBusinessObject();
            var balanceSheets = bo.GetBalanceSheets().Result;
            var companies = bo.GetCompanies().Result;
            var equity = new List<ExtractedValue>();
            List<ExtractedValue> sortedList = null;
            foreach (var item in companies)
            {
                if (item.Id == companyId)
                {
                    var financialAnalysis = new FinancialAnalysis();
                    equity = financialAnalysis.GetEquity(balanceSheets, item.Id);

                }
                sortedList = equity.OrderBy(o => o.Year).ToList();
            }
            var xValues = new List<int>();
            var yValues = new List<double>();

            foreach (var item in sortedList)
            {
                xValues.Add(item.Year);
                yValues.Add((double)item.Value);
            }
            return new Trendline(yValues, xValues);
        }

      

    }
}
