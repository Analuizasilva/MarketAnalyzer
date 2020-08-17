using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.Scrapping.QuickFsScrapers.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.Scraping.QuickFsScrapers
{
    public class IncomeStatementScraper
    {
        public async Task<List<IncomeStatement>> ScrapeIncomeStatement(string ticker, string apiKey)
        {
            #region Data from QuickFS
            string url = "https://api.quickfs.net/stocks/"+ticker+":US/is/Annual/" + apiKey;

            var helper = new WebHelper();
            var request = await helper.ComposeWebRequestGet(url);

            var result = await helper.CallWebRequest(request);
            result = result.Replace("<\\/td>", "");
            result = result.Replace("$", "");
            result = result.Replace(",", ".");

            var html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(result);

            var htmlNodes = html.DocumentNode.Descendants("td").ToList();
            if (htmlNodes.Count == 0)
            {
                return null;
            }
            var numberOfColumns = html.DocumentNode.SelectNodes("//tr[@class='thead']").Descendants("td").ToList().Count();
            var numberOfRows = htmlNodes.Count / numberOfColumns;
            var count = 1;
            #endregion

            #region DataOrganization
            var valuesFinalList = new List<float>();
            var incomeStatements = new List<IncomeStatement>();
            for (var i = 1; i < numberOfColumns; i++)
            {
                var extractedValuesList = new List<ExtractedValues>();

                var parsedYear = int.TryParse(htmlNodes[i].InnerText, out int yearNumber);
                //if (!parsedYear) return; lançar exceção

                for (var j = 1; j < numberOfRows; j++)
                {
                    var name = htmlNodes[j * numberOfColumns].InnerText;
                    
                    var valuesList = new List<string>();
                    foreach(var item in htmlNodes)
                    {
                        var htmlValue = item.GetAttributeValue("data-value", null);
                        valuesList.Add(htmlValue);
                    }

                    var valuesFromNodes = valuesList[(j * numberOfColumns) + count];
                    bool parsedFloat = float.TryParse(valuesFromNodes, NumberStyles.Float, CultureInfo.InvariantCulture, out float valuesFloat);
                    valuesFinalList.Add(valuesFloat);
                    
                    if (yearNumber != 0 && name != "" && name != "Operating Expenses")
                    {
                        var baseItems = new BaseItem();
                        var extractedValues = new ExtractedValues();
                        extractedValues.Year = yearNumber;
                        baseItems.Name = name;
                        baseItems.Value = valuesFloat;
                        extractedValues.Items.Add(baseItems);
                        extractedValuesList.Add(extractedValues);
                    }
                }
                count++;
                #endregion

                #region Add to IncomeStatement
                var incomeStatement = new IncomeStatement();
                foreach (var extractedItem in extractedValuesList)
                {
                    var props = incomeStatement.GetType().GetProperties();

                    incomeStatement.Year = extractedItem.Year;

                    foreach (var prop in props)
                    {
                        var displayAttribute = prop.GetCustomAttributes<DisplayAttribute>().SingleOrDefault();
                        if (displayAttribute != null)
                        {
                            var item = extractedItem.Items.SingleOrDefault(i => i.Name == displayAttribute.Name);

                            if (item != null)
                            {
                                prop.SetValue(incomeStatement, item.Value);
                            }
                        } 
                    }
                }
                if (incomeStatement.Year!=0)incomeStatements.Add(incomeStatement);
                #endregion
            }
            Random rnd = new Random();
            await Task.Delay(TimeSpan.FromSeconds(rnd.Next(1, 10)));
            return incomeStatements;
        }
    }
}
