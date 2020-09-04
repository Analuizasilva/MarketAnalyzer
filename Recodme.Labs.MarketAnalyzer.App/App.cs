using Recodme.Labs.MarketAnalyzer.Analysis;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.Context;
using Recodme.Labs.MarketAnalyzer.DataLayer.Pocos;
using Recodme.RD.FullStoQReborn.DataLayer.UserRecords;
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

            //var context = new MarketAnalyzerDBContext();
            //context.Database.EnsureCreated();
            //context.AddRange();

            //var profile = new List<Profile>
            //{
            //    new Profile("Maria", "Sousa", "ana@la8al", DateTime.Now),
            //    new Profile("José", "Manel", "ana@lal5al", DateTime.Now),
            //    new Profile("Marco", "Antonio", "antoniona@lal5al", DateTime.Now)

            //};
            //context.Profiles.AddRange(profile);
            //context.SaveChanges();
        }
    }
}