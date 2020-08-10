using DataAccessLayer.Contexts;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.SlickCharts;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.Scraping.QuickFsScrapers;
using Recodme.Labs.MarketAnalyzer.Scraping.QuickFsScrapers.CashFlowStatements;
using Recodme.Labs.MarketAnalyzer.Scraping.SlickChartsScrapers;
using System;
using System.Collections.Generic;
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

           // var keyRatioScraper = new KeyRatioScraper();
           // var result = await keyRatioScraper.ScrapeKeyRatio();

           // var balanceSheetScraper = new BalanceSheetScraper();
           //await  balanceSheetScraper.ScraperBalanceSheet();
           // var slickChartsBO = new SlickChartsBO();
           // await slickChartsBO.ScrapeAndStoreData();

           // var ctx = new Context();
           // ctx.Database.EnsureCreated();

           // var scrap = new SlickChartsScraper();

            var cashFlowStatementsScraper = new CashFlowStatementsScraper();
            await cashFlowStatementsScraper.ScraperCashFlowStatements();

        }
    }
}