using HtmlAgilityPack;
using Microsoft.Extensions.Caching.Memory;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.Scraping.SlickChartsScrapers;
using Recodme.Labs.MarketAnalyzer.Scrapping.QuickFsScrapers.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.Scraping.QuickFsScrapers
{
    public class IncomeStatementScraper
    {
        public async Task<ExtractedStatement> ScrapeIncomeStatement(string ticker)
        {
            var extractedStatement = new ExtractedStatement();

            string url = "https://api.quickfs.net/stocks/" + ticker + ":US/is/Annual/grL0gNYoMoLUB1ZoAKLfhXkoMoLODiO1WoL9.grLtk3PoMoLmqFEsMasbNK9fkXudkNBtR2jpkr5dINZoAKLtRNZoMlG1MJR3PQP1PlxcOpEfqXGoMwcoqNWaka9tIKO6OlGnPiYsOosoIS1fySsoMoLiApW1hpffZFLaR29uhSDdkFZoAKLsRNWiq29rIKO6OpLcqSBQJ0ZrPCOcOwHryNIthXBwICO6PKsokpBwyS9dDFLtqoO6grLBDrO6PCsoZ0GoMlH9vN0.4clnWa197BohIJjcOe14FjaQaoJ9aGymU9SIOGqOFku";
            var helper = new WebHelper();
            var request = await helper.ComposeWebRequestGet(url);

            var result = await helper.CallWebRequest(request);
            result = result.Replace("<\\/td>", "");

            var html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(result);

            var htmlNodes = html.DocumentNode.Descendants("td").ToList();

            #region years
            var incomeStatementYear = html.DocumentNode.SelectNodes("//tr[@class='thead']").Descendants("td").ToList().Skip(1).Select(element => element.InnerText.Replace("<\\/td>", "").Replace("<\\/tr>", ""));


            var incomeStatementYears = new List<int>();

            foreach (var year in incomeStatementYear)
            {
                bool success = int.TryParse(year, out int years);
                if (!success)
                {
                    years = 0;
                }
                incomeStatementYears.Add(years);
            }
            #endregion


            #region data

            var numberOfColumns = html.DocumentNode.SelectNodes("//tr[@class='thead']").Descendants("td").ToList().Count();

            var numberOfRows = htmlNodes.Count / numberOfColumns;
          
            for (int i = 0; i < numberOfRows; i++)
            {
                var index = (numberOfColumns * i);

                var baseItem = new BaseItem { Name = htmlNodes[index].InnerText };

                var list = new List<string>();

                for (int j = 1; j <= incomeStatementYear.Count(); j++)
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
                var lista = extractedStatement.Items;
                foreach (var item in listFloats)
                {
                    if (list.Count > 0)
                    {
                        baseItem.Value = item;
                        lista.Add(baseItem);

                    }
                }
            }
            #endregion
            return extractedStatement;
        }
    }
}
