using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.Scraping.SlickChartsScrapers;
using Recodme.Labs.MarketAnalyzer.Scrapping.QuickFsScrapers.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.Scraping.QuickFsScrapers
{
    public class IncomeStatementScraper
    {
        public async Task<List<List<IncomeStatement>>> ScrapeAllIncomeStatements()
        {
            var slickChartsScraper = new SlickChartsScraper();
            var companies = slickChartsScraper.ScrapeCompanies();

            var allIncomeStatements = new List<List<IncomeStatement>>();

            foreach (var company in companies)
            {
                if (company.Ticker != "OXY.WT")
                {
                    var ticker = company.Ticker;

                    var incomeStatement = await ScrapeIncomeStatement(ticker);
                    foreach(var incs in incomeStatement)
                    {
                        incs.CompanyId = company.Id;
                        Console.WriteLine(ticker + " " + incs.Year + " " + incs.Revenue);
                    }
                    allIncomeStatements.Add(incomeStatement);
                    
                }
            }

            return allIncomeStatements;
        }
        public async Task<List<IncomeStatement>> ScrapeIncomeStatement(string ticker)
        {
            #region Data from QuickFS
            string url = "https://api.quickfs.net/stocks/"+ticker+":US/is/Annual/grL0gNYoMoLUB1ZoAKLfhXkoMoLODiO1WoL9.grLtk3PoMoLmqFEsMasbNK9fkXudkNBtR2jpkr5dINZoAKLtRNZoMlG1MJkrWQk2WJxcOpEfqXGoMwcoqNWaka9tIKO6OlGnPiYsOosoIS1fySsoMoLiApW1hpffZFLaR29uhSDdkFZoAKLsRNWiq29rIKO6OpLcqSBQJ0ZrPCOcOwHryNIthXBwICO6PKsokpBwyS9dDFLtqoO6grLBDrO6PCsoZ0GoMlH9vN0.-y1_CVwm6YA_76wZ_xliluZP2j0x-RxMhn6ds1qIeam";

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

            #region DataOrganization

            var extractedValuesList = new List<ExtractedValues>();
            var incomeStatementForCompany = new List<IncomeStatement>();
            var valuesFinalList = new List<float>();

            for (var i = 1; i < numberOfColumns; i++)
            {
                var incomeStatement = new IncomeStatement();
                var baseItems = new BaseItem();
                

                var parsedYear = int.TryParse(htmlNodes[i].InnerText, out int yearNumber);
                //if (!parsedYear) return; lançar exceção
                

                for (var j = 1; j < numberOfRows; j++)
                {
                    var extractedValues = new ExtractedValues();
                    

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
                    valuesFinalList.Add(valuesFloat);
                }

                count++;
                #endregion

                #region Add to IncomeStatement
                if (incomeStatement.Year != 0 && numberOfRows==22)
                {
                    incomeStatement.Year = yearNumber;
                    incomeStatement.Revenue = valuesFinalList[0 + 21 * (i-1)];
                    incomeStatement.CostOfGoodsSold = valuesFinalList[1 + 21 * (i - 1)];
                    incomeStatement.GrossProfit = valuesFinalList[2 + 21 * (i - 1)];
                    incomeStatement.SalesGeneralAdministrative = valuesFinalList[5 + 21 * (i - 1)];
                    incomeStatement.ResearchDevelopment = valuesFinalList[6 + 21 * (i - 1)];
                    incomeStatement.TotalOperatingExpenses = valuesFinalList[7 + 21 * (i - 1)];
                    incomeStatement.OperatingProfit = valuesFinalList[8 + 21 * (i - 1)];
                    incomeStatement.NetInterestIncome = valuesFinalList[10 + 21 * (i - 1)];
                    incomeStatement.OtherNonOperatingIncome = valuesFinalList[11 + 21 * (i - 1)];
                    incomeStatement.PreTaxeIncome = valuesFinalList[12 + 21 * (i - 1)];
                    incomeStatement.IncomeTax = valuesFinalList[14 + 21 * (i - 1)];
                    incomeStatement.NetIncome = valuesFinalList[15 + 21 * (i - 1)];
                    incomeStatement.EPSBasic = valuesFinalList[17 + 21 * (i - 1)];
                    incomeStatement.EPSDiluted = valuesFinalList[18 + 21 * (i - 1)];
                    incomeStatement.SharesBasic = valuesFinalList[19 + 21 * (i - 1)];
                    incomeStatement.SharesDiluted = valuesFinalList[20 + 21 * (i - 1)];
                
                    incomeStatementForCompany.Add(incomeStatement);
                    //Console.WriteLine(incomeStatement.Year + " " + incomeStatement.Revenue);
                }
                else
                {
                    continue;
                }
                
                #endregion
            }
            return incomeStatementForCompany;
        }
    }
}
