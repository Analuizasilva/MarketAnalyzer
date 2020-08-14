using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.Scrapping.QuickFsScrapers.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System;

//namespace Recodme.Labs.MarketAnalyzer.Scraping.QuickFsScrapers
//{
//    public class BalanceSheetScraper
//    {
//        #region Scrape Balance Sheet
//        public async Task<List<BalanceSheet>> ScrapeBalanceSheet(string ticker, string apiKey)
//        {
//            #region Data from QuickFS
//            var url = $" https://api.quickfs.net/stocks/{ticker}:US/bs/Annual/{apiKey}";

//            var helper = new WebHelper();

//            var request = await helper.ComposeWebRequestGet(url);

//            var result = await helper.CallWebRequest(request);
//            result = result.Replace("<\\/td>", "");

//            var html = new HtmlAgilityPack.HtmlDocument();
//            html.LoadHtml(result);

//            var htmlNodes = html.DocumentNode.Descendants("td").ToList();
//            #endregion

//            #region DataOrganization

//            #region WordRemover
//            var word = "Liabilities & Equity";
//            var isDeleted = false;
//            foreach (var nodeItem in htmlNodes.ToList())
//            {
//                if (nodeItem.InnerHtml.Equals(word) && isDeleted == false)
//                {
//                    nodeItem.InnerHtml = "";
//                    isDeleted = true;
//                }
//            }
//            #endregion

//            var numberOfColumns = html.DocumentNode.SelectNodes("//tr[@class='thead']").Descendants("td").ToList().Count();

//            var numberOfRows = htmlNodes.Count / numberOfColumns;
//            var count = 1;

//            var extractedValuesList = new List<ExtractedValues>();

//            var valuesFinalList = new List<float>();

//            var balanceSheets = new List<BalanceSheet>();           

//            for (var i = 1; i < numberOfColumns; i++)
//            {
//                var parsedYear = int.TryParse(htmlNodes[i].InnerText, out int yearNumber);
//                //if (!parsedYear) return; lançar exceção

//                for (var j = 1; j < numberOfRows; j++)
//                {
//                    var extractedValues = new ExtractedValues();
//                    var baseItems = new BaseItem();

//                    var name = htmlNodes[j * numberOfColumns].InnerText;
//                    baseItems.Name = name;

//                    var valuesList = new List<string>();
//                    foreach (var item in htmlNodes)
//                    {
//                        var htmlValue = item.GetAttributeValue("data-value", null);
//                        valuesList.Add(htmlValue);
//                    }

//                    var valuesFromNodes = valuesList[(j * numberOfColumns) + count];
//                    bool parsedFloat = float.TryParse(valuesFromNodes, NumberStyles.Float, CultureInfo.InvariantCulture, out float valuesFloat);
//                    valuesFinalList.Add(valuesFloat);

//                    if (yearNumber != 0 && name != "" && name != "Assets")
//                    {
//                        extractedValues.Year = yearNumber;
//                        baseItems.Name = name;
//                        baseItems.Value = valuesFloat;
//                        extractedValues.Items.Add(baseItems);
//                        extractedValuesList.Add(extractedValues);
//                    }
//                }
//                #endregion

//                #region Add to BalanceSheet
//                var balanceSheet = new BalanceSheet();

//                var props = balanceSheet.GetType().GetProperties();

//                foreach (var extractedItem in extractedValuesList)
//                {
//                    foreach (var prop in props)
//                    {
//                        var list = new List<DisplayAttribute>();
//                        var attribute = prop.GetCustomAttributes<DisplayAttribute>();
//                        foreach (var at in attribute)
//                        {
//                            list.Add(at);

//                        }
//                        foreach (var l in list)
//                        {
//                            foreach (var ev in extractedValuesList)
//                            {
//                                balanceSheet.Year = ev.Year;
//                                foreach (var item in ev.Items)
//                                {
//                                    var name = item.Name;
//                                    if (l.Name == name)
//                                    {
//                                        prop.SetValue(balanceSheet, item.Value);
//                                    }
//                                }
//                            }
//                        }
//                        if (balanceSheet.Year != 0) balanceSheets.Add(balanceSheet);
//                        #endregion
//                    }
//                    await Task.Delay(TimeSpan.FromSeconds(2.4));
//                    return balanceSheets;
//                }
//            }
//            #endregion
//        }
//    }
//}



