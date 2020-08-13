using HtmlAgilityPack;
using Recodme.Labs.MarketAnalyzer.Scrapping.QuickFsScrapers.Base;
using Recodme.Labs.MarketAnalyzer.Scrapping.QuickFsScrapers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Globalization;
using Recodme.Labs.MarketAnalyzer.Scraping.SlickChartsScrapers;

namespace Recodme.Labs.MarketAnalyzer.Scraping.QuickFsScrapers.KeyRatio
{
    public class KeyRatioScraper
    {

        public async Task<List<List<ExtractedValues>>> ScrapeAllKeyRatios()
        {
            var slickChartsScraper = new SlickChartsScraper();
            var companies = slickChartsScraper.ScrapeCompanies();

            var keyRatio = new List<List<ExtractedValues>>();

            foreach (var company in companies)
            {
                var ticker = company.Ticker;
                var extractedValues = await ScrapeKeyRatio(ticker);
                keyRatio.Add(extractedValues);
                Console.WriteLine(ticker);
            }

            return keyRatio;
        }

        public async Task<List<ExtractedValues>> ScrapeKeyRatio(string ticker)
        {
            string url = "https://api.quickfs.net/stocks/" + ticker + ":US/ratios/Annual/grL0gNYoMoLUB1ZoAKLfhXkoMoLODiO1WoL9.grLtk3PoMoLmqFEsMasbNK9fkXudkNBtR2jpkr5dINZoAKLtRNZoMlG1MJR3PQP1PlxcOpEfqXGoMwcoqNWaka9tIKO6OlGnPiYsOosoIS1fySsoMoLiApW1hpffZFLaR29uhSDdkFZoAKLsRNWiq29rIKO6OpLcqSBQJ0ZrPCOcOwHryNIthXBwICO6PKsokpBwyS9dDFLtqoO6grLBDrO6PCsoZ0GoMlH9vN0.4clnWa197BohIJjcOe14FjaQaoJ9aGymU9SIOGqOFku";

            var helper = new WebHelper();
            var request = await helper.ComposeWebRequestGet(url);
            var result = await helper.CallWebRequest(request);
            result = result.Replace("<\\/td>", "");
            result = result.Replace("<\\/tr>", "");
            result = result.Replace("$", "");
            result = result.Replace(",", ".");
            var html = new HtmlDocument();
            html.LoadHtml(result);

            var htmlNodes = html.DocumentNode.Descendants("td").ToList();

            var numberOfColumns = html.DocumentNode.SelectNodes("//tr[@class='thead']").Descendants("td").ToList().Count();

            var numberOfRows = htmlNodes.Count / numberOfColumns;
            var count = 1;

            var extractedValuesList = new List<ExtractedValues>();
            var countNum = 1; // identifica o numero de registos
            for (var i = 1; i < numberOfColumns; i++)
            {
                var parsedYear = int.TryParse(htmlNodes[i].InnerText, out int yearNumber);
                //if (!parsedYear) return; lançar exceção

                for (var j = 1; j < numberOfRows; j++)
                {
                    var extractedValues = new ExtractedValues();
                    var baseItems = new BaseItem();

                    var name = htmlNodes[j * numberOfColumns].InnerText;
                    baseItems.Name = name;

                    var valuesList = new List<string>();
                    foreach (var item in htmlNodes)
                    {
                        var htmlValue = item.GetAttributeValue("data-value", null);
                        valuesList.Add(htmlValue);
                    }

                    var valuesFromNodes = valuesList[(j * numberOfColumns) + count];
                    bool parsedFloat = float.TryParse(valuesFromNodes, NumberStyles.Float, CultureInfo.InvariantCulture, out float valuesFloat);

                    if (yearNumber != 0 && name != "" && name != "Returns")
                    {
                        
                        extractedValues.Year = yearNumber;
                        baseItems.Name = name;
                        baseItems.Value = valuesFloat;
                        extractedValues.Items.Add(baseItems);
                        extractedValuesList.Add(extractedValues);

                        Console.WriteLine(countNum + " " + extractedValues.Year + " " + baseItems.Name + " " + baseItems.Value);
                        countNum++;
                    }
                }
                count++;
            }
            return extractedValuesList;
        }














        //...................m

        //    public async Task ScrapeKeyRatio(string ticker)
        //    {
        //        var extractedValuesList = new List<ExtractedValues>();
        //        var baseItems = new BaseItem();

        //        var helper = new WebHelper();
        //        var request = await helper.ComposeWebRequestGet("https://api.quickfs.net/stocks/AAPL:US/ratios/Annual/grL0gNYoMoLUB1ZoAKLfhXkoMoLODiO1WoL9.grLtk3PoMoLmqFEsMasbNK9fkXudkNBtR2jpkr5dINZoAKLtRNZoMlG1MJR3PQP1PlxcOpEfqXGoMwcoqNWaka9tIKO6OlGnPiYsOosoIS1fySsoMoLiApW1hpffZFLaR29uhSDdkFZoAKLsRNWiq29rIKO6OpLcqSBQJ0ZrPCOcOwHryNIthXBwICO6PKsokpBwyS9dDFLtqoO6grLBDrO6PCsoZ0GoMlH9vN0.4clnWa197BohIJjcOe14FjaQaoJ9aGymU9SIOGqOFku");


        //        var result = await helper.CallWebRequest(request);
        //        var html = new HtmlDocument();
        //        html.LoadHtml(result);

        //        result = result.Replace("<\\/td>", "");
        //        result = result.Replace("$", "");
        //        result = result.Replace("%", "");


        //        //.............S
        //        var htmlNodes = html.DocumentNode.Descendants("td").ToList();
        //        var numberOfColumns = html.DocumentNode.SelectNodes("//tr[@class='thead']").Descendants("td").ToList().Count();
        //        var numberOfRows = htmlNodes.Count / numberOfColumns;

        //        for (var i = 1; i < numberOfColumns; i++)
        //        {
        //            var extractedValues = new ExtractedValues();
        //            var parsedYear = htmlNodes[i].InnerText.Replace("<\\/td>", "");
        //            if (parsedYear == null) return;
        //            if (!(parsedYear == "0"))
        //            {
        //                extractedValues.Year = parsedYear;
        //            }
        //            for (var j = 0; j < numberOfRows; j++)
        //            {
        //                Console.WriteLine(htmlNodes[j + numberOfColumns].InnerText);
        //            }
        //            if (!(parsedYear == "0")) extractedValuesList.Add(extractedValues);
        //        }
        //    }
    }




    //.............Print Name and data-value 

    //var htmlDataValues = html.DocumentNode.SelectNodes("/table[1]/tbody[1]/tr/td/@data-value").ToList();
    //        var htmlLabelCell = html.DocumentNode.SelectNodes("/table[1]/tbody[1]/tr/td[@class='labelCell']").ToList();


    //        var campCount = 0;
    //        var index = 0;
    //        foreach (var item in htmlLabelCell)
    //        {
    //            var count = 10;
    //            Console.WriteLine(htmlLabelCell[campCount].InnerText);
    //            campCount++;
                
    //            for(var i = 0; i < count; i++)
    //            {
    //                Console.WriteLine(htmlDataValues[index].Attributes["data-value"].Value);
    //                index++;
    //            }
    //        }





            // ........................

        //    var keyRatioYear = html.DocumentNode.SelectNodes("//tr[@class='thead']").Descendants("td").ToList().Skip(1).Select(element => element.InnerText.Replace("<\\/td>", ""));

        //    var numberOfColumns = html.DocumentNode.SelectNodes("//tr[@class='thead']").Descendants("td").ToList().Count();

        //    var numberOfRows = htmlDataValues.Count / numberOfColumns;
        //    var listValues = new List<KeyRatioValues>();
        //    for (int i = 0; i < numberOfRows; i++)
        //    {
        //        var index = (numberOfColumns * i);
        //        var keyRatioValues = new KeyRatioValues { Key = htmlDataValues[index].InnerText };
        //        var list = new List<string>();

        //        for (int j = 1; j <= keyRatioYear.Count(); j++)
        //        {
        //            if (htmlDataValues[index + j].InnerText.Replace("<\\/tr>", "") != string.Empty && keyRatioValues.Key != string.Empty)
        //            {
        //                list.Add(htmlDataValues[index + j].InnerText.Replace("<\\/tr>", ""));
        //            }
        //        }
        //        if (list.Count > 0)
        //        {
        //            keyRatioValues.Values = list;
        //            listValues.Add(keyRatioValues);

        //        }
        //    }
        //}








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
