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
        public class CompanyGrowth
        {
            public Guid CompanyId { get; set; }
            public List<DataPoco> YearsGrowthList { get; set; }

            public CompanyGrowth()
            {
                YearsGrowthList = new List<DataPoco>();
            }

        }
        public class DataPoco
        { 
            public int Year { get; set; }
            public decimal? Growth { get; set; }
        }
        public CompanyGrowth GetFutureValues(Guid companyId)
        {
           var companyInfo = _dao.GetCompanyInfo(companyId);
            
            var dataPocoList = new List<DataPoco>();
            var companyGrowth = new CompanyGrowth();
            companyGrowth.CompanyId = companyId;
            var incomeStatements = companyInfo.IncomeStatements.OrderBy(x=>x.Year);
            var cashFlowStatements = companyInfo.CashFlowStatements.OrderBy(x => x.Year);
            var balanceSheets = companyInfo.BalanceSheets.OrderBy(x => x.Year);
            var KeyRatios = companyInfo.KeyRatios.OrderBy(x => x.Year);

            //(Net Income -Dividends - Depreciation & Amortization) / (Shareholders' Equity + Long-Term Debt)

            foreach(var item in incomeStatements)
            {
                var dataPoco = new DataPoco();
                
                    dataPoco.Year = item.Year;
                    var netIncome = item.NetIncome;

                    var dividends = KeyRatios.Where(x => x.Year == item.Year).SingleOrDefault().DividendsPerShare;
                    var depreciationAndAmortization = cashFlowStatements.Where(x => x.Year == item.Year).SingleOrDefault().DepreciationAmortization;
                    var shareholdersEquity = balanceSheets.Where(x => x.Year == item.Year).SingleOrDefault().ShareholdersEquity;
                    var longTermDebt = balanceSheets.Where(x => x.Year == item.Year).SingleOrDefault().LongTermDebt;

                    var growthValue = (netIncome - (decimal)dividends - depreciationAndAmortization) / (shareholdersEquity + longTermDebt);
                    dataPoco.Growth = growthValue;
                    dataPocoList.Add(dataPoco);
                
                
               
                
            }
            companyGrowth.YearsGrowthList = dataPocoList;

            return companyGrowth;
        }
    }
}
