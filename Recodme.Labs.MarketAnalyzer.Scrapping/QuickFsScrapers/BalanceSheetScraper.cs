using Recodme.Labs.MarketAnalyzer.Scraping.SlickChartsScrapers;
using Recodme.Labs.MarketAnalyzer.Scrapping.QuickFsScrapers.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.Scraping.QuickFsScrapers
{
    public class BalanceSheetScraper
    {
        //public async Task<List<List<ExtractedValues>>> ScrapeAllBalanceSheet()
        //{
        //    var slickChartsScraper = new SlickChartsScraper();
        //    var companies = slickChartsScraper.ScrapeCompanies();

        //    var balanceSheetTickers = new List<List<ExtractedValues>>();

        //    foreach (var company in companies)
        //    {
        //        var ticker = company.Ticker;
        //        var extractedValues = await ScraperBalanceSheet(ticker);
        //        balanceSheetTickers.Add(extractedValues);
        //    }
        //    return balanceSheetTickers;
        //}
        public async Task<List<ExtractedValues>> ScraperBalanceSheet(string ticker)
        {
            var url = $" https://api.quickfs.net/stocks/{ticker}:US/bs/Annual/grL0gNYoMoLUB1ZoAKLfhXkoMoLODiO1WoL9.grLtk3PoMoLmqFEsMasbNK9fkXudkNBtR2jpkr5dINZoAKLtRNZoMlG1MJkrWQP5WiYcOpEfqXGoMwcoqNWaka9tIKO6OlGnPiYiOosoIS1fySsoMoLfAwWthFIfZFLaR29uhSDdkFZoAKLsRNWiq29rIKO6OlPrWQDrWlx4OosokFLtqpacISqaOlmsAKLrISqth25Zkpa2Olt7OaBJOlmnAKLQZCO6PF19vZ.3h8OgqhBpUy12nFQO2sv6wXkzj1ac7dEOF7wlHJFrJG";

            var helper = new WebHelper();

            var request = await helper.ComposeWebRequestGet(url);

            var result = await helper.CallWebRequest(request);
            result = result.Replace("<\\/td>", "");

            var html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(result);

            var htmlNodes = html.DocumentNode.Descendants("td").ToList();

            #region WordRemover
            var word = "Liabilities & Equity";
            var isDeleted = false;
            foreach (var nodeItem in htmlNodes.ToList())
            {
                if (nodeItem.InnerHtml.Equals(word) && isDeleted == false)
                {
                    nodeItem.InnerHtml = "";
                    isDeleted = true;
                }
            }
            #endregion

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
                    foreach (var item in htmlNodes)
                    {
                        var htmlValue = item.GetAttributeValue("data-value", null);
                        valuesList.Add(htmlValue);
                    }

                    var valuesFromNodes = valuesList[(j * numberOfColumns) + count];
                    bool parsedFloat = float.TryParse(valuesFromNodes, NumberStyles.Float, CultureInfo.InvariantCulture, out float valuesFloat);
                    

                    if (yearNumber != 0 && name != "" && name != "Assets" )
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
