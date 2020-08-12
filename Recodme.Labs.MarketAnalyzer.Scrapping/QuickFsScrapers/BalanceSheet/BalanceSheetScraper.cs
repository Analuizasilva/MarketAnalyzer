//using Recodme.Labs.MarketAnalyzer.Scrapping.QuickFsScrapers;
//using Recodme.Labs.MarketAnalyzer.Scrapping.QuickFsScrapers.Base;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Recodme.Labs.MarketAnalyzer.Scraping.QuickFsScrapers
//{
//    public class BalanceSheetScraper
//    {
//        public async Task ScraperBalanceSheet(string ticker)
//        {
//            var helper = new WebHelper();
//            var request = await helper.ComposeWebRequestGet($"https://api.quickfs.net/stocks/{ticker}:US/bs/Annual/grL0gNYoMoLUB1ZoAKLfhXkoMoLODiO1WoL9.grLtk3PoMoLmqFEsMasbNK9fkXudkNBtR2jpkr5dINZoAKLtRNZoMlG1MJR3PQk0PiRcOpEfqXGoMwcoqNWaka9tIKO6OlGnPiYiOosoIS1fySsoMoLfAwWthFIfZFLaR29uhSDdkFZoAKLsRNWiq29rIKO6OlPrWQDrWlx4OosokFLtqpacISqaOlmsAKLrISqth25Zkpa2Olt7OaBJOlmnAKLQZCO6PF19vZ.4Cln1o9anX5WXxb47nHBsRfwL7J-rMp073IE-QEfpJZ");

//            var result = await helper.CallWebRequest(request);
//            result = result.Replace("<\\/td>", "");

//            var html = new HtmlAgilityPack.HtmlDocument();
//            html.LoadHtml(result);


//            var htmlNodes = html.DocumentNode.Descendants("td").ToList();

//            var balanceSheetYearsString = html.DocumentNode.SelectNodes("//tr[@class='thead']").Descendants("td").ToList().Skip(1).Select(element => element.InnerText.Replace("<\\/td>", "").Replace("<\\/tr>", ""));

//            var balanceSheetYears = new List<int>();

//            foreach (var year in balanceSheetYearsString)
//            {
//                bool success = int.TryParse(year, out int years);
//                if (!success)
//                {
//                    years = 0;
//                }
//                balanceSheetYears.Add(years);
//            }

//            var numberOfColumns = html.DocumentNode.SelectNodes("//tr[@class='thead']").Descendants("td").ToList().Count();

//            var numberOfRows = htmlNodes.Count / numberOfColumns;

//            var listValues = new List<BaseItem>();

//            for (int i = 2; i < numberOfRows; i++)
//            {
//                var index = (numberOfColumns * i);
//                var baseItem = new BaseItem { Name = htmlNodes[index].InnerText };

//                var list = new List<string>();
//                for (int j = 1; j <= balanceSheetYears.Count(); j++)
//                {
//                    if (htmlNodes[index + j].InnerText.Replace("<\\/tr>", "") != string.Empty)
//                    {
//                        list.Add(htmlNodes[index + j].InnerText.Replace("<\\/tr>", ""));
//                    }
//                }
//                foreach (var item in list)
//                {

//                }

//                if (list.Count > 0)
//                {
//                    baseItem.Value = list;
//                    listValues.Add(baseItem);
//                }
//            }
//        }
//    }
//}