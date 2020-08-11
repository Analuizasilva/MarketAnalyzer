using HtmlAgilityPack;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualBasic;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.Scraping.SlickChartsScrapers;
using Recodme.Labs.MarketAnalyzer.Scrapping.QuickFsScrapers.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.Scraping.QuickFsScrapers
{
    public class IncomeStatementScraper
    {
        public async Task<List<ExtractedValues>> ScrapeIncomeStatement(string ticker)
        {
            string url = "https://api.quickfs.net/stocks/" + ticker + ":US/is/Annual/grL0gNYoMoLUB1ZoAKLfhXkoMoLODiO1WoL9.grLtk3PoMoLmqFEsMasbNK9fkXudkNBtR2jpkr5dINZoAKLtRNZoMlG1MJR3PQP1PlxcOpEfqXGoMwcoqNWaka9tIKO6OlGnPiYsOosoIS1fySsoMoLiApW1hpffZFLaR29uhSDdkFZoAKLsRNWiq29rIKO6OpLcqSBQJ0ZrPCOcOwHryNIthXBwICO6PKsokpBwyS9dDFLtqoO6grLBDrO6PCsoZ0GoMlH9vN0.4clnWa197BohIJjcOe14FjaQaoJ9aGymU9SIOGqOFku";

            var helper = new WebHelper();
            var request = await helper.ComposeWebRequestGet(url);

            var result = await helper.CallWebRequest(request);
            result = result.Replace("<\\/td>", "");
            result = result.Replace("$", "");
            result = result.Replace(",", ".");

            var html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(result);

            var htmlNodes = html.DocumentNode.Descendants("td").ToList();

            var numberOfColumns = html.DocumentNode.SelectNodes("//tr[@class='thead']").Descendants("td").ToList().Count();
            var numberOfRows = htmlNodes.Count / numberOfColumns;
            var count = 1;

            var extractedValuesList = new List<ExtractedValues>();

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
                    foreach(var item in htmlNodes)
                    {
                        var htmlValue = item.GetAttributeValue("data-value", null);
                        valuesList.Add(htmlValue);
                    }

                    var valuesFromNodes = valuesList[(j * numberOfColumns) + count];
                    bool parsedFloat = float.TryParse(valuesFromNodes, NumberStyles.Float, CultureInfo.InvariantCulture, out float valuesFloat);

                    if (yearNumber != 0 && name != "" && name!="Operating Expenses")
                    {
                        extractedValues.Year = yearNumber;
                        baseItems.Name = name;
                        baseItems.Value = valuesFloat;
                        extractedValues.Items.Add(baseItems);
                        extractedValuesList.Add(extractedValues);
                        Console.WriteLine(extractedValues.Year + " " + baseItems.Name + " " + baseItems.Value);
                    }
                }
                count++;
                
            }
            return extractedValuesList;
        }
    }
}
