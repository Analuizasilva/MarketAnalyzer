using Microsoft.Ajax.Utilities;
using Recodme.Labs.MarketAnalyzer.Analysis;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer.Base;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.App
{
    public class App
    {
        public async Task Run()
        {
       

            var companyDAO = new BaseDataAccessObject<Company>();
            var companyDB = companyDAO.ListAsync().Result;
            var info = companyDAO.GetCompaniesInfo();
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