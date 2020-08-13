using Recodme.Labs.MarketAnalyzer.DataAccessLayer.Base;
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
            var dataAccessDao = new BaseDataAccessObject<Company>();
            var incomeSDataAccessDao = new BaseDataAccessObject<IncomeStatement>();
            var dbCompanies = dataAccessDao.GetDataBaseCompanies();
            var allIncomeStatements = new List<List<IncomeStatement>>();
            var incomeStatementScraper = new IncomeStatementScraper();

            foreach (var company in dbCompanies)
            {
                if (company.Ticker != "OXY.WT")
                {
                    var ticker = company.Ticker;

                    await Task.Delay(TimeSpan.FromSeconds(2));
                    var incomeStatement = await incomeStatementScraper.ScrapeIncomeStatement(ticker);

                    foreach (var incs in incomeStatement)
                    {
                        incs.CompanyId = company.Id;
                        Console.WriteLine(ticker + " " + incs.Year + " " + incs.Revenue);
                    }
                    await incomeSDataAccessDao.AddListAsync(incomeStatement);
                    allIncomeStatements.Add(incomeStatement);
                }
            }
            return allIncomeStatements;
        }

    }
}
