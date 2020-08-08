using HtmlAgilityPack;
using System;
using System.Collections.Generic;
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


            var balaceSheetYear = html.DocumentNode.SelectNodes("//tr[@class='thead']").Descendants("td").ToList().Skip(1)
                .Select(element => element.InnerText.Replace("<\\/td>", ""));

            var numberOfColumns = html.DocumentNode.SelectNodes("//tr[@class='thead']").Descendants("td").ToList().Count();

            var numberOfRows = htmlNodes.Count / numberOfColumns;

            Dictionary<string, List<string>> dictionaryOfBalaceSheet = new Dictionary<string, List<string>>();
            var count = 0;
            for (int i = 2; i < numberOfRows; i++)
            {
                count++;
                var index = (numberOfColumns * i);
                var list = new List<string>();

                for (int j = 1; j <= balaceSheetYear.Count(); j++)
                {
                    list.Add(htmlNodes[index + j].InnerText);
                }

                if (!dictionaryOfBalaceSheet.ContainsKey(htmlNodes[index].InnerText))
                {
                    dictionaryOfBalaceSheet.Add(htmlNodes[index].InnerText, list);
                }
            }
        }
    }
}


