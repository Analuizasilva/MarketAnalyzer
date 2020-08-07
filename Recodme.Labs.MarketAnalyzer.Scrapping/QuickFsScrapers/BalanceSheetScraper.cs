using HtmlAgilityPack;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.Scraping.QuickFsScrapers
{
    public class BalanceSheetScraper
    {
        public async Task ScrapeBalanceSheet()
        {
            var helper = new WebHelper();
            var request = await helper.ComposeWebRequestGet("https://api.quickfs.net/stocks/MSFT:US/bs/Annual/grL0gNYoMoLUB1ZoAKLfhXkoMoLODiO1WoL9.grLtk3PoMoLmqFEsMasbNK9fkXudkNBtR2jpkr5dINZoAKLtRNZoMlG1MJR3PQk0PiRcOpEfqXGoMwcoqNWaka9tIKO6OlGnPiYiOosoIS1fySsoMoLfAwWthFIfZFLaR29uhSDdkFZoAKLsRNWiq29rIKO6OlPrWQDrWlx4OosokFLtqpacISqaOlmsAKLrISqth25Zkpa2Olt7OaBJOlmnAKLQZCO6PF19vZ.4Cln1o9anX5WXxb47nHBsRfwL7J-rMp073IE-QEfpJZ");

            var result = await helper.CallWebRequest(request);
            result = result.Replace("<\\/td>", "</td>");

            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(result);
           
            var htmlNodes = html.DocumentNode.Descendants("td").ToList();

            foreach (var item in htmlNodes)
            {
                Console.WriteLine(item.InnerText);
            }
            //for (int i = 0; i < htmlNodes.Count / 12; i++)
            //{
            //    var count = i * 12;

            //    var years = htmlNodes[count + 1].InnerHtml;
            //    var cashEEquivalents = htmlNodes[count + 2].InnerHtml;
            //    var shortTermInvestments = htmlNodes[count + 4].InnerHtml;
            //    var accountsReceivable = htmlNodes[count + 6].InnerHtml;
            //    var inventories = htmlNodes[count + 8].InnerHtml;
            //    var otherCurrentAssets = htmlNodes[count + 10].InnerHtml;
            //    var totalCurrentAssets = htmlNodes[count + 12].InnerHtml;

            //    var investments = htmlNodes[count + 8].InnerHtml;
            //    var propertyPlantEEquipmentNet = htmlNodes[count + 9].InnerHtml;
            //    var goodwill = htmlNodes[count + 10].InnerHtml;
            //    var otherIntangibleAssets = htmlNodes[count + 11].InnerHtml;
            //    var otherAssets = htmlNodes[count + 12].InnerHtml;
              

         
            //    Console.WriteLine($"{years} {cashEEquivalents} {shortTermInvestments} {accountsReceivable} {inventories} {otherCurrentAssets} {totalCurrentAssets} {investments} {propertyPlantEEquipmentNet} {goodwill} {otherIntangibleAssets} {otherAssets} {totalCurrentAssets}");
            //}
    
        }
    }
}
