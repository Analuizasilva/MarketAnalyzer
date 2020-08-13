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
        //public async Task<List<List<ExtractedValues>>> ScrapeAllCashFlowStatements()
        //{
        //    var slickChartsScraper = new SlickChartsScraper();
        //    var companies = slickChartsScraper.ScrapeCompanies();

        //    var cashFlowStatement = new List<List<ExtractedValues>>();

        //    foreach (var company in companies)
        //    {
        //        var ticker = company.Ticker;
        //        var extractedValues = await ScrapeCashFlowStatement(ticker);
        //        cashFlowStatement.Add(extractedValues);
        //        Console.WriteLine(ticker);
        //    }

        //    return cashFlowStatement;
        //}
        public async Task<List<CashFlowStatement>> ScrapeCashFlowStatement(string ticker)
        {
            string url = "https://api.quickfs.net/stocks/" + ticker + ":US/cf/Annual/grL0gNYoMoLUB1ZoAKLfhXkoMoLODiO1WoL9.grLtk3PoMoLmqFEsMasbNK9fkXudkNBtR2jpkr5dINZoAKLtRNZoMlG1MJR3PQP1PlxcOpEfqXGoMwcoqNWaka9tIKO6OlGnPiYsOosoIS1fySsoMoLiApW1hpffZFLaR29uhSDdkFZoAKLsRNWiq29rIKO6OpLcqSBQJ0ZrPCOcOwHryNIthXBwICO6PKsokpBwyS9dDFLtqoO6grLBDrO6PCsoZ0GoMlH9vN0.4clnWa197BohIJjcOe14FjaQaoJ9aGymU9SIOGqOFku";

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

            var namesList = new List<string>();

            var cashFlowStatementForCompanyList = new List<CashFlowStatement>();

            for (var i = 1; i < numberOfColumns; i++)
            {

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

                var cashFlowStatement = new CashFlowStatement();

                var props = cashFlowStatement.GetType().GetProperties();
                foreach (var prop in props)
                {
                    var list = new List<DisplayAttribute>();
                    var attribute = prop.GetCustomAttributes<DisplayAttribute>();
                    foreach (var at in attribute)
                    {
                        list.Add(at);

                    }
                    foreach (var l in list)
                    {
                        foreach (var ev in extractedValuesList)
                        {
                            cashFlowStatement.Year = ev.Year;
                            foreach (var item in ev.Items)
                            {
                                var name = item.Name;
                                if (l.Name == name)
                                {

                                    prop.SetValue(cashFlowStatement, item.Value);
                                }
                            }
                        }
                    }
                }
                if (cashFlowStatement.Year != 0) cashFlowStatementForCompanyList.Add(cashFlowStatement);

            }
            await Task.Delay(TimeSpan.FromSeconds(2));
            return cashFlowStatementForCompanyList;
        }

    }
}
