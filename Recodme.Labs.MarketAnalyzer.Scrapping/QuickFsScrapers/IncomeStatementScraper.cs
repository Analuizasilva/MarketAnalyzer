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

            var incomeStatementForCompany = new List<IncomeStatement>();
            var valuesFinalList = new List<float>();

            for (var i = 1; i < numberOfColumns; i++)
            {
                var extractedValuesList = new List<ExtractedValues>();
                var incomeStatement = new IncomeStatement();

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
                
                var props = incomeStatement.GetType().GetProperties();
                foreach(var prop in props)
                {
                    var list = new List<DisplayAttribute>();
                    var attribute = prop.GetCustomAttributes<DisplayAttribute>();
                    foreach (var at in attribute)
                    {
                        list.Add(at);
                        
                    }
                    foreach (var l in list)
                    {
                       foreach(var ev in extractedValuesList)
                        {
                            incomeStatement.Year = ev.Year;
                            foreach (var item in ev.Items)
                            {
                                var name = item.Name;
                                if (l.Name == name)
                                {
                                    prop.SetValue(incomeStatement, item.Value);
                                }
                            }
                        }
                    }
                }
                if(incomeStatement.Year!=0) incomeStatementForCompany.Add(incomeStatement);
                
                #endregion
            }
            await Task.Delay(TimeSpan.FromSeconds(2.4));
            return incomeStatementForCompany;
        }
    }
}
