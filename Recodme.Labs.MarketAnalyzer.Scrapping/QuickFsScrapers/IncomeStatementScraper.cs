using HtmlAgilityPack;
using Microsoft.Extensions.Caching.Memory;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.Scraping.SlickChartsScrapers;
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
        public async Task<List<HtmlNode>> ScrapeIncomeStatement(string ticker)
        {
            string url = "https://api.quickfs.net/stocks/" + ticker + ":US/is/Annual/grL0gNYoMoLUB1ZoAKLfhXkoMoLODiO1WoL9.grLtk3PoMoLmqFEsMasbNK9fkXudkNBtR2jpkr5dINZoAKLtRNZoMlG1MJR3PQP1PlxcOpEfqXGoMwcoqNWaka9tIKO6OlGnPiYsOosoIS1fySsoMoLiApW1hpffZFLaR29uhSDdkFZoAKLsRNWiq29rIKO6OpLcqSBQJ0ZrPCOcOwHryNIthXBwICO6PKsokpBwyS9dDFLtqoO6grLBDrO6PCsoZ0GoMlH9vN0.4clnWa197BohIJjcOe14FjaQaoJ9aGymU9SIOGqOFku";
            var helper = new WebHelper();
            var request = await helper.ComposeWebRequestGet(url);
            var result = await helper.CallWebRequest(request);
            result = result.Replace("<\\/td>", "</td>");
            result = result.Replace("$", "");

            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(result);


            //var htmlNodes = html.DocumentNode.Descendants().Where(x => x.Name == "tbody").SingleOrDefault();
            var htmlNodes = html.DocumentNode.Descendants("td").ToList();
            //foreach (var item in htmlNodes)
            //{
            //    Console.WriteLine(item.InnerText);
            //}
            return htmlNodes;
        }

        public async Task<List<IncomeStatement>> OrganizeScrapedIncomeStatement(List<HtmlNode> htmlNodes)
        {
            #region Lists
            List<int> incomeStatementYears = new List<int>();
            List<float> incomeStatementRevenue = new List<float>();
            List<float> incomeStatementCostOfGoodsSold = new List<float>();
            List<float> incomeStatementGrossProfit = new List<float>();
            List<float> incomeStatementSalesGeneralAdministrative = new List<float>();
            List<float> incomeStatementResearchDevelopment = new List<float>();
            List<float> incomeStatementTotalOperatingExpenses = new List<float>();
            List<float> incomeStatementOperatingProfit = new List<float>();
            List<float> incomeStatementNetInterestIncome = new List<float>();
            List<float> incomeStatementOtherNonOperatingIncome = new List<float>();
            List<float> incomeStatementPreTaxIncome = new List<float>();
            List<float> incomeStatementIncomeTax = new List<float>();
            List<float> incomeStatementNetIncome = new List<float>();
            List<float> incomeStatementEPSBasic = new List<float>();
            List<float> incomeStatementEPSDiluted = new List<float>();
            List<float> incomeStatementSharesBasic = new List<float>();
            List<float> incomeStatementSharesDiluted = new List<float>();
            List<float> incomeStatementTTM = new List<float>();
            #endregion

            #region Node separation
            for (int i = 0; i < htmlNodes.Count; i++)
            {
                if (i > 1 && i < 11) incomeStatementYears.Add(Convert.ToInt32(htmlNodes[i].InnerText, CultureInfo.InvariantCulture));
                if (i > 12 && i < 23) incomeStatementRevenue.Add(float.Parse(htmlNodes[i].InnerText, CultureInfo.InvariantCulture));
                if (i > 24 && i < 35) incomeStatementCostOfGoodsSold.Add(float.Parse(htmlNodes[i].InnerText, CultureInfo.InvariantCulture));
                if (i > 36 && i < 47) incomeStatementGrossProfit.Add(float.Parse(htmlNodes[i].InnerText, CultureInfo.InvariantCulture));
                if (i > 72 && i < 83) incomeStatementSalesGeneralAdministrative.Add(float.Parse(htmlNodes[i].InnerText, CultureInfo.InvariantCulture));
                if (i > 84 && i < 95) incomeStatementResearchDevelopment.Add(float.Parse(htmlNodes[i].InnerText, CultureInfo.InvariantCulture));
                if (i > 96 && i < 107) incomeStatementTotalOperatingExpenses.Add(float.Parse(htmlNodes[i].InnerText, CultureInfo.InvariantCulture));
                if (i > 108 && i < 119) incomeStatementOperatingProfit.Add(float.Parse(htmlNodes[i].InnerText, CultureInfo.InvariantCulture));
                if (i > 132 && i < 143) incomeStatementNetInterestIncome.Add(float.Parse(htmlNodes[i].InnerText, CultureInfo.InvariantCulture));
                if (i > 144 && i < 155) incomeStatementOtherNonOperatingIncome.Add(float.Parse(htmlNodes[i].InnerText, CultureInfo.InvariantCulture));
                if (i > 156 && i < 167) incomeStatementPreTaxIncome.Add(float.Parse(htmlNodes[i].InnerText, CultureInfo.InvariantCulture));
                if (i > 180 && i < 191) incomeStatementIncomeTax.Add(float.Parse(htmlNodes[i].InnerText, CultureInfo.InvariantCulture));
                if (i > 192 && i < 203) incomeStatementNetIncome.Add(float.Parse(htmlNodes[i].InnerText, CultureInfo.InvariantCulture));
                if (i > 216 && i < 227) incomeStatementEPSBasic.Add(float.Parse(htmlNodes[i].InnerText, CultureInfo.InvariantCulture));
                if (i > 228 && i < 239) incomeStatementEPSDiluted.Add(float.Parse(htmlNodes[i].InnerText, CultureInfo.InvariantCulture));
                if (i > 240 && i < 251) incomeStatementSharesBasic.Add(float.Parse(htmlNodes[i].InnerText, CultureInfo.InvariantCulture));
                if (i > 252 && i < 263) incomeStatementSharesDiluted.Add(float.Parse(htmlNodes[i].InnerText, CultureInfo.InvariantCulture));
                if (i == 23 || i == 35 || i == 47 || i == 83 || i == 95 || i == 107 || i == 119 || i == 143 || i == 155 || i == 167 || i == 191 || i == 203 || i == 227 || i == 239 || i == 251 || i == 263) incomeStatementTTM.Add(float.Parse(htmlNodes[i].InnerText, CultureInfo.InvariantCulture));
            }
            //foreach (var item in incomeStatementEPSBasic)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Income Statement
            
            List<IncomeStatement> CompanyIncomeStatement = new List<IncomeStatement>();
            for (var i = 0; i < incomeStatementYears.Count; i++)
            {
                var incomeStatement = new IncomeStatement();
                incomeStatement.Year = incomeStatementYears[i];
                incomeStatement.Revenue = incomeStatementRevenue[i];
                incomeStatement.CostOfGoodsSold = incomeStatementCostOfGoodsSold[i];
                incomeStatement.GrossProfit = incomeStatementGrossProfit[i];
                incomeStatement.SalesGeneralAdministrative = incomeStatementSalesGeneralAdministrative[i];
                incomeStatement.ResearchDevelopment = incomeStatementResearchDevelopment[i];
                incomeStatement.TotalOperatingExpenses = incomeStatementTotalOperatingExpenses[i];
                incomeStatement.OperatingProfit = incomeStatementOperatingProfit[i];
                incomeStatement.NetInterestIncome = incomeStatementNetInterestIncome[i];
                incomeStatement.OtherNonOperatingIncome = incomeStatementOtherNonOperatingIncome[i];
                incomeStatement.PreTaxeIncome = incomeStatementPreTaxIncome[i];
                incomeStatement.IncomeTax = incomeStatementIncomeTax[i];
                incomeStatement.NetIncome = incomeStatementNetIncome[i];
                incomeStatement.EPSBasic = incomeStatementEPSBasic[i];
                incomeStatement.EPSDiluted = incomeStatementEPSDiluted[i];
                incomeStatement.SharesBasic = incomeStatementSharesBasic[i];
                incomeStatement.SharesDiluted = incomeStatementSharesDiluted[i];

                CompanyIncomeStatement.Add(incomeStatement);
            }

            for (var i = 0; i < CompanyIncomeStatement.Count; i++)
            {
                Console.WriteLine(CompanyIncomeStatement[i].Year + " " + CompanyIncomeStatement[i].Revenue + " " + CompanyIncomeStatement[i].CostOfGoodsSold);
            }
            #endregion
            return CompanyIncomeStatement;

        }

    }
}
