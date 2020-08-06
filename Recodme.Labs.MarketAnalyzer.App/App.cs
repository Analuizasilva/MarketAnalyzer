using DataAccessLayer.Contexts;
using Microsoft.Ajax.Utilities;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.Scrapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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




            var wc = new WebClient();
            string page = wc.DownloadString("https://api.quickfs.net/stocks/MSFT:US/bs/Annual/grL0gNYoMoLUB1ZoAKLfhXkoMoLODiO1WoL9.grLtk3PoMoLmqFEsMasbNK9fkXudkNBtR2jpkr5dINZoAKLtRNZoMlG1MJR3PQk0PiRcOpEfqXGoMwcoqNWaka9tIKO6OlGnPiYiOosoIS1fySsoMoLfAwWthFIfZFLaR29uhSDdkFZoAKLsRNWiq29rIKO6OlPrWQDrWlx4OosokFLtqpacISqaOlmsAKLrISqth25Zkpa2Olt7OaBJOlmnAKLQZCO6PF19vZ.4Cln1o9anX5WXxb47nHBsRfwL7J-rMp073IE-QEfpJZ");

            JObject objectJson = JObject.Parse(page);
            JValue ob = (JValue)objectJson["datasets"]["bs"];

            string htmlDoc = ob.ToString();

            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(htmlDoc);
            var htmlNodes = html.DocumentNode.SelectNodes("//table[@class=fs-table]").Descendants("td").ToList();
            
            foreach(var node in htmlNodes)
            {
                Console.WriteLine(node.InnerText);
            }



            
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