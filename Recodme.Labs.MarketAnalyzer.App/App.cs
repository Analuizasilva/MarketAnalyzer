using Recodme.Labs.MarketAnalyzer.Analysis;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.Context;
using Recodme.Labs.MarketAnalyzer.DataLayer.Pocos;
using Recodme.Labs.MarketAnalyzer.Scraping;
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
            //var business = new AnalysisBusinessObject();
            //var result = business.GetStockData();
            //var fitness = result.FirstOrDefault(x => x.CompanyDataPoco.Company.Ticker == "BRK.B");

            var scraping = new MotleyFoolScraper();
            scraping.ScrapeCAPSRating();

            //var context = new MarketAnalyzerDBContext();
            //context.Database.EnsureCreated();
            //var company = context.Companies.First(x => x.Name == "Air Canada");

            //company.Outperform = 30189;
            //company.Underperform = 2337;
            //company.StarRating = 4;

            //context.Companies.Update(company);
            //context.SaveChanges();


        }
    }
}