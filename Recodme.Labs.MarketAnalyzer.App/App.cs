using DataAccessLayer.Contexts;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.Scrapping;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.App
{
    public class App
    {
        public async Task Run()
        {
            var slickChartsBO = new SlickChartsBO();
           await slickChartsBO.ScrapeAndStoreData();

            //var ctx = new Context();
            //ctx.Database.EnsureCreated();

            //var scrap = new SlickChartsScrapper();

            //var bo = new BusinessObject<Company>();
            //bo.AddAndUpdateCompanies(scrap.ScrapeCompanies());
        }
    }
}