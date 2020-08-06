using DataAccessLayer.Contexts;
using Microsoft.Ajax.Utilities;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.Scraping;
using Recodme.Labs.MarketAnalyzer.Scraping.QuickFsScrapers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

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

            var balanceSheetScraper = new BalanceSheetScraper();
            await balanceSheetScraper.ScrapeBalanceSheet();

            // var slickChartsBO = new SlickChartsBO();
            //await slickChartsBO.ScrapeAndStoreData();

            //var ctx = new Context();
            //ctx.Database.EnsureCreated();

            //var scrap = new SlickChartsScrapper();

            //var bo = new BusinessObject<Company>();
            //bo.AddAndUpdateCompanies(scrap.ScrapeCompanies());
        }
    }
}