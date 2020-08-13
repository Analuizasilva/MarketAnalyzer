using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.Scraping.QuickFsScrapers;
using Recodme.Labs.MarketAnalyzer.Scraping.SlickChartsScrapers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.QuickFS
{
    public class IncomeStatementBO
    {
        public async Task<List<List<IncomeStatement>>> ScrapeAllIncomeStatements()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            var slickChartsScraper = new SlickChartsScraper();
            var companies = slickChartsScraper.ScrapeCompanies();

            var incomeStatementScraper = new IncomeStatementScraper();

            var allIncomeStatements = new List<List<IncomeStatement>>();

            foreach (var company in companies)
            {
                if (company.Ticker != "OXY.WT")
                {
                    var ticker = company.Ticker;

                    var incomeStatement = await incomeStatementScraper.ScrapeIncomeStatement(ticker);
                    foreach (var incs in incomeStatement)
                    {
                        //incs.CompanyId = company.Id; mudar para o company da base de dados
                        Console.WriteLine(ticker + " " + incs.Year + " " + incs.Revenue);
                    }
                    allIncomeStatements.Add(incomeStatement);
                }
            }

            return allIncomeStatements;
        }

    }
}
