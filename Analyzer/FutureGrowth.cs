using Recodme.Labs.MarketAnalyzer.Analysis.Support;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.Analysis
{
    public class FutureGrowth
    {
        private readonly CompanyDataAccessObject _dao;

        public  FutureGrowth()
        {
            this._dao = new CompanyDataAccessObject();
        }
        
        public double? GetFutureValues(Guid companyId)
        {
           var companyInfo = _dao.GetCompanyInfo(companyId);

            
            var valuesList = new List<ExtractedValue>();
            
            var incomeStatements = companyInfo.IncomeStatements.OrderBy(x=>x.Year);
            var cashFlowStatements = companyInfo.CashFlowStatements.OrderBy(x => x.Year);
            var balanceSheets = companyInfo.BalanceSheets.OrderBy(x => x.Year);
            var KeyRatios = companyInfo.KeyRatios.OrderBy(x => x.Year);

            //(Net Income -Dividends - Depreciation & Amortization) / (Shareholders' Equity + Long-Term Debt)

            foreach(var item in incomeStatements)
            {
               
                var values = new ExtractedValue();
                values.CompanyId = companyId;
                values.Year = item.Year;
                    var netIncome = item.NetIncome;

                    var dividends = KeyRatios.Where(x => x.Year == item.Year).SingleOrDefault().DividendsPerShare;
                    var depreciationAndAmortization = cashFlowStatements.Where(x => x.Year == item.Year).SingleOrDefault().DepreciationAmortization;
                    var shareholdersEquity = balanceSheets.Where(x => x.Year == item.Year).SingleOrDefault().ShareholdersEquity;
                    var longTermDebt = balanceSheets.Where(x => x.Year == item.Year).SingleOrDefault().LongTermDebt;

                    var growthValue = (netIncome - (decimal)dividends - depreciationAndAmortization) / (shareholdersEquity + longTermDebt);
                values.Value = (double)growthValue;

                valuesList.Add(values);
            }

           

            var trendline = new Trendline();
            var valuesTrendline = trendline.GetTrendline(valuesList);
            var slope = valuesTrendline.Slope;
            var intercept = valuesTrendline.Intercept;

            var estimatedValue = (DateTime.Now.Year + 1) * slope + intercept;

            return estimatedValue;

        }
    }
}
