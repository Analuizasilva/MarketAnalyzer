using Recodme.Labs.MarketAnalyzer.Scrapping.QuickFsScrapers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.Scraping.QuickFsScrapers.BalanceSheet
{
    public class BalanceSheetScraper
    {
        public async Task ScraperBalanceSheet()
        {
            var helper = new WebHelper();
            var request = await helper.ComposeWebRequestGet("https://api.quickfs.net/stocks/MSFT:US/bs/Annual/grL0gNYoMoLUB1ZoAKLfhXkoMoLODiO1WoL9.grLtk3PoMoLmqFEsMasbNK9fkXudkNBtR2jpkr5dINZoAKLtRNZoMlG1MJR3PQk0PiRcOpEfqXGoMwcoqNWaka9tIKO6OlGnPiYiOosoIS1fySsoMoLfAwWthFIfZFLaR29uhSDdkFZoAKLsRNWiq29rIKO6OlPrWQDrWlx4OosokFLtqpacISqaOlmsAKLrISqth25Zkpa2Olt7OaBJOlmnAKLQZCO6PF19vZ.4Cln1o9anX5WXxb47nHBsRfwL7J-rMp073IE-QEfpJZ");

            var result = await helper.CallWebRequest(request);
            result = result.Replace("<\\/td>", "");

            var html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(result);

            var htmlNodes = html.DocumentNode.Descendants("td").ToList();

            var balanceSheetYear = html.DocumentNode.SelectNodes("//tr[@class='thead']").Descendants("td").ToList().Skip(1).Select(element => element.InnerText.Replace("<\\/td>", "").Replace("<\\/tr>", ""));


            var balanceSheetYears = new List<int>();

            foreach (var year in balanceSheetYear)
            {
                bool success = int.TryParse(year, out int years);
                if (!success)
                {
                    years = 0;
                }
                balanceSheetYears.Add(years);            
            }

            var numberOfColumns = html.DocumentNode.SelectNodes("//tr[@class='thead']").Descendants("td").ToList().Count();

            var numberOfRows = htmlNodes.Count / numberOfColumns;

            var listValues = new List<BaseItem>();

            for (int i = 0; i < numberOfRows; i++)
            {
                var index = (numberOfColumns * i);

                var baseItem = new BaseItem { Name = htmlNodes[index].InnerText };            


                var list = new List<string>();
                for (int j = 1; j <= balanceSheetYear.Count(); j++)
                {
                    if (htmlNodes[index + j].InnerText.Replace("<\\/tr>", "") != string.Empty && baseItem.Name != string.Empty)
                    {
                        list.Add(htmlNodes[index + j].InnerText.Replace("<\\/tr>", ""));
                    }
                }

                var listFloats = new List<float>();

                foreach (var item in list)
                {                    
                    bool success = float.TryParse(item, out float number);
                    if (!success)
                    {
                        number = 0;
                    }
                    listFloats.Add(number);
                }

                foreach (var item in listFloats)
                {
                    if (list.Count > 0)
                    {
                        baseItem.Value = item;
                        listValues.Add(baseItem);
                    }
                }
              

              
            }
        }
    }
}


