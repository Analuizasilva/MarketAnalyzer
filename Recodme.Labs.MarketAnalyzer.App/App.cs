using Microsoft.Ajax.Utilities;
using Recodme.Labs.MarketAnalyzer.Analysis;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer.Base;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.App
{
    public class App
    {
        public async Task Run()
        {
            var dao = new CompanyDataAccessObject();
            var result = dao.GetCompaniesInfo();
            var apple = result.FirstOrDefault(x => x.Company.Ticker == "AAPL");

            var financial = new FinancialAnalysis();
            var equity = financial.GetEquity(apple);

            var slopeinfo = new SlopeInfo(equity);
            var trendline = slopeinfo.NominalTrendline;
            var growth = slopeinfo.Growth;


            //var companyDAO = new BaseDataAccessObject<Company>();
            //var companyDB = companyDAO.ListAsync().Result;
            //var info = companyDAO.GetCompaniesInfo();

            //foreach (var company in companyDB)
            //{
            //    if (company.Ticker == "AAPL")
            //    {
            //        var companyId = company.Id;
            //        var slopeInfo = new SlopeInfo();
            //        slopeInfo.CalculateEquityGrowth(companyId);
            //        slopeInfo.CalculateEpsGrowth(companyId);
            //    }
            //}

        }
    }
}