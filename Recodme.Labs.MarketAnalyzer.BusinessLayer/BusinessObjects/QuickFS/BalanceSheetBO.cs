using Recodme.Labs.MarketAnalyzer.DataAccessLayer.Base;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.Scraping.QuickFsScrapers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.QuickFS
{
    public class BalanceSheetBO
    {
        #region Scrape All Balance Sheet
        public async Task<List<List<BalanceSheet>>> ScrapeAllBalanceSheet()
        {
            var dataAccessDao = new BaseDataAccessObject<Company>();
            var incomeSDataAccessDao = new BaseDataAccessObject<IncomeStatement>();
            var dbCompanies = dataAccessDao.GetDataBaseCompanies();
            var balanceSheets = new List<List<IncomeStatement>>();
            var incomeStatementScraper = new IncomeStatementScraper();

            foreach (var company in dbCompanies)
            {
                if (company.Ticker != "OXY.WT")
                {
                    var ticker = company.Ticker;

                    await Task.Delay(TimeSpan.FromSeconds(2));
                    var incomeStatement = await incomeStatementScraper.ScrapeIncomeStatement(ticker, HelperVars.QuickFsApiKey);

                    foreach (var incs in incomeStatement)
                    {
                        incs.CompanyId = company.Id;
                        Console.WriteLine(ticker + " " + incs.Year + " " + incs.Revenue);
                    }
                    await incomeSDataAccessDao.AddListAsync(incomeStatement);
                    balanceSheets.Add(incomeStatement);
                }
            }
            return balanceSheets;
        }
        #endregion     
    }
}
