using Recodme.Labs.MarketAnalyzer.DataLayer.Context;
using Recodme.Labs.MarketAnalyzer.Scraping;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.App
{
    public class App
    {
        public async Task Run()
        {
            var context = new MarketAnalyzerDBContext();
            var companies = context.Companies.ToList();
            var scraping = new MotleyFoolScraper();
            foreach (var cmpny in companies)
            {
                var ticker = cmpny.Ticker;
                Random rnd = new Random();
                await Task.Delay(TimeSpan.FromSeconds(rnd.Next(1, 10)));
                var company = scraping.ScrapeCAPSRating(ticker);
                if (company != null)
                {
                    cmpny.StarRaking = company.StarRaking;
                    cmpny.Outperform = company.Outperform;
                    cmpny.Underperform = company.Underperform;
                    context.Companies.UpdateRange(cmpny);
                    context.SaveChanges();
                }
            }
        }
    }
}