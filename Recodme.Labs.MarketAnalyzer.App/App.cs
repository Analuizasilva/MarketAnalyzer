using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.DataLayer.Context;
using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
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

            //var context = new MarketAnalyzerDBContext();
            //context.Database.EnsureCreated();
            //context.AddRange();

            //    var userTransaction = new List<UserTransaction>
            //    {
            //        new UserTransaction(22, 30, 2, 4),
            //        new UserTransaction(22, 30, 2, 4),


            //    };
            //    context.UserTransactions.AddRange(userTransaction);
            //    context.SaveChanges();




            //_____Scraping_____

            //var context = new MarketAnalyzerDBContext();
            //var companies = context.Companies.ToList();
            //var scraping = new MotleyFoolScraper();
            //foreach (var cmpny in companies)
            //{
            //    var ticker = cmpny.Ticker;
            //    //Random rnd = new Random();
            //    var company = scraping.ScrapeCAPSRating(ticker);
            //    if (company != null)
            //    {
            //        cmpny.StarRaking = company.StarRaking;
            //        cmpny.Outperform = company.Outperform;
            //        cmpny.Underperform = company.Underperform;
            //        context.Companies.UpdateRange(cmpny);
            //        context.SaveChanges();
            //    }
            //}



        }
    }
}