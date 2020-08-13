using Recodme.Labs.MarketAnalyzer.Scraping.QuickFsScrapers;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.App
{
    public class App
    {
        public async Task Run()
        {
            /* Instanciar um web client
             * fazer request para o URL com o webclient
             * converter a string resultado num objecto JSON
             * fazer parse ao JSON para extrair o HTML que está na propriedade
             * Instanciar o HTML document passando como parametro de entrada a string que contem o HTML
             *extrair a informação direitinha */

            //var keyRatioScraper = new KeyRatioScraper();
            //await keyRatioScraper.ScrapeKeyRatio();


            //var keyRatioScraper = new KeyRatioScraper();
            //await keyRatioScraper.ScrapeKeyRatio("AAPL");

            //var incomeStatementScraper = new IncomeStatementScraper();
            //await incomeStatementScraper.ScrapeIncomeStatement("MSFT");

            //var slickChartsBO = new SlickChartsBO();
            //await slickChartsBO.ScrapeAndStoreData();

            //var ctx = new Context();
            //ctx.Database.EnsureCreated();

            //var scrap = new SlickChartsScraper();

            var keyRatioScraper = new KeyRatioScraper();
            await keyRatioScraper.ScrapeKeyRatio("AAPL");


        }
    }
}