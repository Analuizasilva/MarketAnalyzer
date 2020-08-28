using Recodme.Labs.MarketAnalyzer.Analysis;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.App
{
    public class App
    {
        public async Task Run()
        {
            var business = new AnalysisBusinessObject();
            var result = business.GetStockData();
            var fitness = result.FirstOrDefault(x => x.CompanyDataPoco.Company.Ticker == "BRK.B");
        }
    }
}