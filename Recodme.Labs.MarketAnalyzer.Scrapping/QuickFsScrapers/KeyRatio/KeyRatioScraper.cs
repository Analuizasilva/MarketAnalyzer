using HtmlAgilityPack;
using Recodme.Labs.MarketAnalyzer.Scrapping.QuickFsScrapers.KeyRatio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Recodme.Labs.MarketAnalyzer.Scraping.QuickFsScrapers.KeyRatio
{
    public class KeyRatioScraper
    {
        public async Task ScrapeKeyRatio()
        {
            var helper = new WebHelper();
            var request = await helper.ComposeWebRequestGet("https://api.quickfs.net/stocks/AAPL:US/ratios/Annual/grL0gNYoMoLUB1ZoAKLfhXkoMoLODiO1WoL9.grLtk3PoMoLmqFEsMasbNK9fkXudkNBtR2jpkr5dINZoAKLtRNZoMlG1MJR3PQP1PlxcOpEfqXGoMwcoqNWaka9tIKO6OlGnPiYsOosoIS1fySsoMoLiApW1hpffZFLaR29uhSDdkFZoAKLsRNWiq29rIKO6OpLcqSBQJ0ZrPCOcOwHryNIthXBwICO6PKsokpBwyS9dDFLtqoO6grLBDrO6PCsoZ0GoMlH9vN0.4clnWa197BohIJjcOe14FjaQaoJ9aGymU9SIOGqOFku");

            var result = await helper.CallWebRequest(request);
            result = result.Replace("<\\/td>", "");
            result = result.Replace("$", "");
            result = result.Replace("%", "");

            var html = new HtmlDocument();
            html.LoadHtml(result);


            //.............a 

            var htmlNodes = html.DocumentNode.Descendants("td").ToList();

            var htmlValue = html.DocumentNode.SelectNodes("//td[@data-value='0.22844054644452']");
            var htmlDataValues = html.DocumentNode.SelectNodes("/table[1]/tbody[1]/tr/td/@data-value").ToList();
            var htmlLabelCell = html.DocumentNode.SelectNodes("/table[1]/tbody[1]/tr/td[@class='labelCell']").ToList();


            string data = "";
            foreach (var item in htmlDataValues)
            {
                data = item.Attributes["data-value"].Value;
                Console.WriteLine(item.InnerText);
            }



            var keyRatioYear = html.DocumentNode.SelectNodes("//tr[@class='thead']").Descendants("td").ToList().Skip(1).Select(element => element.InnerText.Replace("<\\/td>", ""));

            var numberOfColumns = html.DocumentNode.SelectNodes("//tr[@class='thead']").Descendants("td").ToList().Count();

            var numberOfRows = htmlDataValues.Count / numberOfColumns;
            var listValues = new List<KeyRatioValues>();
            for (int i = 0; i < numberOfRows; i++)
            {
                var index = (numberOfColumns * i);
                var keyRatioValues = new KeyRatioValues { Key = htmlDataValues[index].InnerText };
                var list = new List<string>();

                for (int j = 1; j <= keyRatioYear.Count(); j++)
                {
                    if (htmlDataValues[index + j].InnerText.Replace("<\\/tr>", "") != string.Empty && keyRatioValues.Key != string.Empty)
                    {
                        list.Add(htmlDataValues[index + j].InnerText.Replace("<\\/tr>", ""));
                    }
                }
                if (list.Count > 0)
                {
                    keyRatioValues.Values = list;
                    listValues.Add(keyRatioValues);

                }
            }
        }








        //...............r





        //var htmlNodes = html.DocumentNode.Descendants("tr");
        //var map = new Dictionary<int, IEnumerable<HtmlNode>>(); //int para o nr da row
        //var count = 0;
        //foreach (var node in htmlNodes)
        //{
        //    count++;
        //    map.Add(count, node.Descendants("td").ToList());
        //}
        //foreach (var item in map)
        //{
        //    Console.WriteLine(item.Key);
        //    foreach (var itemItem in item.Value)
        //    {
        //        Console.WriteLine(itemItem.InnerText);
        //    }
        //}



        //...........M

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




        //return htmlNodes.ToList();


        //09/08

        //foreach (var item in map)
        //{
        //    var list = new List<string>();
        //    list.Add(item.ToString());
        //    keyRatioDictionary.Add(item.ToString(), list);
        //    Console.WriteLine(item.ToString());

        //}

    }
}
