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

            var context = new MarketAnalyzerDBContext();
            context.Database.EnsureCreated();
            context.AddRange();

            var _people = new List<Profile>
            {
                new Profile("Maria", "Sousa", "ana@la8al", DateTime.Now),
                new Profile("José", "Manel", "ana@lal5al", DateTime.Now),
                new Profile("Justina", "Silva", "ana@lal3l", DateTime.Now),
                new Profile("Miguel", "António", "ana@lalalpo", DateTime.Now),
                new Profile("Ana", "Nunes", "ana@lalalfgf", DateTime.Now)

            };
            context.Profiles.AddRange(_people);
            context.SaveChanges();


        }
    }
}