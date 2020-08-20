
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
        public Trendline Trendline { get; set; }

        public Trendline GetTrendlineEquity(Guid companyId)
        {
            var bo = new DataBaseBusinessObject();
            var balanceSheets = bo.GetBalanceSheets().Result;
            var companies = bo.GetCompanies().Result;
            var equity = new List<ExtractedValue>();
            List<ExtractedValue> sortedList=null;
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

            List<ExtractedValue> sortedList = equity.OrderBy(o => o.Year).ToList();
            var equityGrowthRate = new List<ExtractedValue>();
            for (var i = 0; i < (sortedList.Count -1); i++ )
            {
                var result = new ExtractedValue();
                var beginningValue = sortedList[i].Value;
                var finalValue = sortedList[i + 1].Value;
                var division = (double)(finalValue / beginningValue);
                float years = sortedList.Count;
                float pow = 1 / years;
                var growth = Math.Pow(division, pow)-1;
                result.Value = growth;
                result.Year = sortedList[i].Year;
                result.CompanyId = companyId;
                equityGrowthRate.Add(result);
            }
            return equityGrowthRate;
        }

        public List<ExtractedValue> CalculateEpsGrowth(Guid companyId)
        {
            var bo = new DataBaseBusinessObject();
            var incomeStatements = bo.GetIncomeStatements().Result;
            var companies = bo.GetCompanies().Result;
            var eps = new List<ExtractedValue>();
            foreach (var item in companies)
            {
                if (item.Id == companyId)
                {
                    var financialAnalysis = new FinancialAnalysis();
                    eps = financialAnalysis.GetEPS(incomeStatements, item.Id);
                }
            }
            List<ExtractedValue> sortedList = eps.OrderBy(o => o.Year).ToList();
            var epsGrowthRate = new List<ExtractedValue>();
            for (var i = 0; i < (sortedList.Count - 1); i++)
            {
                var result = new ExtractedValue();
                var beginningValue = sortedList[i].Value;
                var finalValue = sortedList[i + 1].Value;
                var division = (double)(finalValue / beginningValue);
                float years = sortedList.Count;
                float pow = 1 / years;
                var growth = Math.Pow(division, pow) - 1;
                result.Value = growth;
                result.Year = sortedList[i].Year;
                result.CompanyId = companyId;
                epsGrowthRate.Add(result);
            }
            return epsGrowthRate;
        }

        public List<ExtractedValue> CalculateRevenueGrowth(Guid companyId)
        {
            var bo = new DataBaseBusinessObject();
            var incomeStatements = bo.GetIncomeStatements().Result;
            var companies = bo.GetCompanies().Result;
            var eps = new List<ExtractedValue>();
            foreach (var item in companies)
            {
                if (item.Id == companyId)
                {
                    var financialAnalysis = new FinancialAnalysis();
                    eps = financialAnalysis.GetRevenue(incomeStatements, item.Id);
                }
            }
            List<ExtractedValue> sortedList = eps.OrderBy(o => o.Year).ToList();
            var revenueGrowthRate = new List<ExtractedValue>();
            for (var i = 0; i < (sortedList.Count - 1); i++)
            {
                var result = new ExtractedValue();
                var beginningValue = sortedList[i].Value;
                var finalValue = sortedList[i + 1].Value;
                var division = (double)(finalValue / beginningValue);
                float years = sortedList.Count;
                float pow = 1 / years;
                var growth = Math.Pow(division, pow) - 1;
                result.Value = growth;
                result.Year = sortedList[i].Year;
                result.CompanyId = companyId;
                revenueGrowthRate.Add(result);
            }
            return revenueGrowthRate;
        }

    }
}
