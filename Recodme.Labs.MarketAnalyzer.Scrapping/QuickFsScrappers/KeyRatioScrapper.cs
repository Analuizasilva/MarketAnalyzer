using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.Scrapping.QuickFsScrappers
{
    public class KeyRatioScrapper
    {
        public async Task<HtmlNode> ScrapeKeyRatio()
        {
            var helper = new WebHelper();
            var request = await helper.ComposeWebRequestGet("https://api.quickfs.net/stocks/MSFT:US/ratios/Annual/grL0gNYoMoLUB1ZoAKLfhXkoMoLODiO1WoL9.grLtk3PoMoLmqFEsMasbNK9fkXudkNBtR2jpkr5dINZoAKLtRNZoMlG1MJR3PQk0PiRcOpEfqXGoMwcoqNWaka9tIKO6OlGnPiYiOosoIS1fySsoMoLfAwWthFIfZFLaR29uhSDdkFZoAKLsRNWiq29rIKO6OlPrWQDrWlx4OosokFLtqpacISqaOlmsAKLrISqth25Zkpa2Olt7OaBJOlmnAKLQZCO6PF19vZ.4Cln1o9anX5WXxb47nHBsRfwL7J-rMp073IE-QEfpJZ");
            var result = await helper.CallWebRequest(request);
            result = result.Replace("<\\/td>", "</td>");

            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(result);

            var htmlNodes = html.DocumentNode.Descendants().Where(x => x.Name == "tbody").SingleOrDefault();
            Console.WriteLine(htmlNodes.InnerText);
            return htmlNodes;
        }

        public async Task OrderKeyRatioInfo(HtmlNode node)
        {

        }

    }
}