using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.Context;
using System;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.App
{
    public class App
    {
        public async Task Run()
        {
            
            var context = new MarketAnalyzerDBContext();
            context.Database.EnsureCreated();
            var company = new Company("Recodme", "AMST");
            context.Companies.AddRange(company);
        }
    }
}