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
        public async Task ScrapeIncomeStatement(string ticker)
        {
            
            var extractedValuesList = new List<ExtractedValues>();

            string url = "https://api.quickfs.net/stocks/" + ticker + ":US/is/Annual/grL0gNYoMoLUB1ZoAKLfhXkoMoLODiO1WoL9.grLtk3PoMoLmqFEsMasbNK9fkXudkNBtR2jpkr5dINZoAKLtRNZoMlG1MJR3PQP1PlxcOpEfqXGoMwcoqNWaka9tIKO6OlGnPiYsOosoIS1fySsoMoLiApW1hpffZFLaR29uhSDdkFZoAKLsRNWiq29rIKO6OpLcqSBQJ0ZrPCOcOwHryNIthXBwICO6PKsokpBwyS9dDFLtqoO6grLBDrO6PCsoZ0GoMlH9vN0.4clnWa197BohIJjcOe14FjaQaoJ9aGymU9SIOGqOFku";

            var helper = new WebHelper();
            var request = await helper.ComposeWebRequestGet(url);

            var result = await helper.CallWebRequest(request);
            result = result.Replace("<\\/td>", "");

            var html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(result);

            var htmlNodes = html.DocumentNode.Descendants("td").ToList();

            var numberOfColumns = html.DocumentNode.SelectNodes("//tr[@class='thead']").Descendants("td").ToList().Count();
            var numberOfRows = htmlNodes.Count / numberOfColumns;

            for (var i = 1; i < numberOfColumns; i++)
            {
   
                var extractedValues = new ExtractedValues();
                var baseItems = new BaseItem();

                var parsedYear = int.TryParse(htmlNodes[i].InnerText, out int yearNumber);
                if (!parsedYear) return;

                if (!(yearNumber == 0))
                {
                    extractedValues.Year = yearNumber;
                }
                var count = 1;
                for (var j = 1; j < numberOfRows; j++)
                {
                    var name = htmlNodes[j * numberOfColumns].InnerText;
                    baseItems.Name = name;
                    
                    //var valuesPerYear = htmlNodes[(j * numberOfColumns)+count].InnerText;

                    Console.WriteLine(yearNumber+ " "+ name /*+ " " + valuesPerYear*/);
                    count++;
                }
               
                if (!(yearNumber == 0)) extractedValuesList.Add(extractedValues);
            }

        }
    }
}
