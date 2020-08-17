using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.Scraping.SlickChartsScrapers;
using Recodme.Labs.MarketAnalyzer.Scrapping.QuickFsScrapers.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace Recodme.Labs.MarketAnalyzer.Scraping.QuickFsScrapers
{
    public class CashFlowStatementScraper
    {
        public async Task<List<CashFlowStatement>> ScrapeCashFlowStatement(string ticker, string apiKey)
        {
            #region Data From QuickFS

            string url = "https://api.quickfs.net/stocks/" + ticker + ":US/cf/Annual/" + apiKey;

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

            #endregion

            #region Data Organization

            
            var namesList = new List<string>();
            var cashFlowStatements = new List<CashFlowStatement>();
            var cashFlowStatementForCompanyList = new List<CashFlowStatement>();

            for (var i = 1; i < numberOfColumns; i++)
            {
                var extractedValuesList = new List<ExtractedValues>();

                for (var h = 1; h < numberOfRows; h++)
                {
                    var name = htmlNodes[h * numberOfColumns].InnerText;
                    
                    if(name == "Other")
                    {
                       name = name + h;
                    }
                    
                    namesList.Add(name);
                }

                var parsedYear = int.TryParse(htmlNodes[i].InnerText, out int yearNumber);
                //if (!parsedYear) return; lançar exceção

                for (var j = 1; j < numberOfRows; j++)
                {
                    var extractedValues = new ExtractedValues();
                    var baseItems = new BaseItem();

                    var name = namesList[j-1];
                    baseItems.Name = name;

                    var valuesList = new List<string>();
                    foreach (var item in htmlNodes)
                    {
                        var htmlValue = item.GetAttributeValue("data-value", null);
                        valuesList.Add(htmlValue);
                    }

                    var valuesFromNodes = valuesList[(j * numberOfColumns) + count];
                    bool parsedFloat = float.TryParse(valuesFromNodes, NumberStyles.Float, CultureInfo.InvariantCulture, out float valuesFloat);
                    

                    if (yearNumber != 0 && name != "" && name != "Operating Expenses")
                    {
                        extractedValues.Year = yearNumber;
                        baseItems.Name = name;
                        baseItems.Value = valuesFloat;
                        extractedValues.Items.Add(baseItems);
                        extractedValuesList.Add(extractedValues);
                    }
                }
                count++;
                #endregion

                #region Add to CashFlowStatement

                foreach (var extractedItem in extractedValuesList)
                {
                    var cashFlowStatement = new CashFlowStatement();
                    var props = cashFlowStatement.GetType().GetProperties();

                    cashFlowStatement.Year = extractedItem.Year;

                    foreach (var prop in props)
                    {
                        var displayAttribute = prop.GetCustomAttributes<DisplayAttribute>().SingleOrDefault();
                        if (displayAttribute != null)
                        {
                            var item = extractedItem.Items.SingleOrDefault(i => i.Name == displayAttribute.Name);

                            if (item != null)
                            {
                                prop.SetValue(cashFlowStatement, item.Value);
                            }
                        }
                    }
                    cashFlowStatements.Add(cashFlowStatement);

                }

                //if (cashFlowStatement.Year != 0) cashFlowStatementForCompanyList.Add(cashFlowStatement);

                #endregion
            }
            await Task.Delay(TimeSpan.FromSeconds(2));
            return cashFlowStatements;
        }

    }
}
