using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Recodme.Labs.MarketAnalyzer.Scraping.QuickFsScrapers
{
    public class KeyRatioScraper
    {
        public async Task<List<HtmlNode>> ScrapeKeyRatio()
        {
            var helper = new WebHelper();
            var request = await helper.ComposeWebRequestGet("https://api.quickfs.net/stocks/AAPL:US/ratios/Annual/grL0gNYoMoLUB1ZoAKLfhXkoMoLODiO1WoL9.grLtk3PoMoLmqFEsMasbNK9fkXudkNBtR2jpkr5dINZoAKLtRNZoMlG1MJR3PQP1PlxcOpEfqXGoMwcoqNWaka9tIKO6OlGnPiYsOosoIS1fySsoMoLiApW1hpffZFLaR29uhSDdkFZoAKLsRNWiq29rIKO6OpLcqSBQJ0ZrPCOcOwHryNIthXBwICO6PKsokpBwyS9dDFLtqoO6grLBDrO6PCsoZ0GoMlH9vN0.4clnWa197BohIJjcOe14FjaQaoJ9aGymU9SIOGqOFku");
            var result = await helper.CallWebRequest(request);

            result = result.Replace("<\\/td>", "</td>");
            result = result.Replace("$", "");

            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(result);


            var htmlNodes = html.DocumentNode.Descendants("tr");
            var map = new Dictionary<int, IEnumerable<HtmlNode>>(); //int para o nr da row
            var count = 0;
            foreach (var node in htmlNodes)
            {
                count++;
                map.Add(count, node.Descendants("td").ToList());
            }
            foreach (var item in map)
            {
                Console.WriteLine(item.Key);
                foreach (var itemItem in item.Value)
                {
                    Console.WriteLine(itemItem.InnerText);
                }
            }

            

            //...........

            //var keyRatioYears = new Dictionary<int, IEnumerable<HtmlNode>>();
            //var newMap = map;
            //var count2 = 0;

            //for (var i = 1; i < 63; i++)
            //{
            //    foreach (var node in newMap[i])
            //    {
            //        count2++;
            //        keyRatioYears.Add(count2, node.Descendants("td").ToList());

            //        for (var x = 1; x < 11; x++)
            //        {
            //            foreach (var item in keyRatioYears[x])
            //            {
            //                newMap.Add(count2, node.Descendants("td").ToList());
            //            }
            //        }

            //    }

            //    foreach (var item in keyRatioYears)
            //    {
            //        Console.WriteLine(item.Key);
            //        foreach (var key in item.Value)
            //        {
            //            Console.WriteLine(key.InnerText);
            //        }
            //    }
            //}




            return htmlNodes.ToList();

            
        }


    }
}