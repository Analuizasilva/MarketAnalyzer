using Recodme.Labs.MarketAnalyzer.DataAccessLayer.Base;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.Scraping.QuickFsScrapers;
using Recodme.Labs.MarketAnalyzer.Scraping.SlickChartsScrapers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.QuickFS
{
    public class IncomeStatementBO
    {
        public async Task ScrapeAllIncomeStatements()
        {
            var dataAccessDao = new BaseDataAccessObject<Company>();
            var incomeSDataAccessDao = new BaseDataAccessObject<IncomeStatement>();

            var dbCompanies = dataAccessDao.GetDataBaseCompanies();
            var dbIncomeStatements = incomeSDataAccessDao.GetDataBaseIncomeStatement();

            var allIncomeStatements = new List<List<IncomeStatement>>();
            var incomeStatementScraper = new IncomeStatementScraper();

            foreach (var company in dbCompanies)
            {
                var ticker = company.Ticker;

                Random rnd = new Random();
                await Task.Delay(TimeSpan.FromSeconds(rnd.Next(1, 10)));
                var incomeStatements = await incomeStatementScraper.ScrapeIncomeStatement(ticker, HelperVars.QuickFsApiKey);

                foreach (var incomeStatement in incomeStatements)
                {
                    incomeStatement.CompanyId = company.Id;
                    Console.WriteLine(ticker + " " + incomeStatement.Year + " " + incomeStatement.Revenue);
                }

                #region new income statements

                var incomeStatementToAdd = incomeStatements.Where(incomeS => !dbIncomeStatements.Any(dbis => dbis.CompanyId == incomeS.CompanyId)).ToList();

                await incomeSDataAccessDao.AddListAsync(incomeStatementToAdd);
                #endregion

                #region income statements to update

                var incomeStatementsToUpdate = new List<IncomeStatement>();
                foreach (var incomeStatement in incomeStatements)
                {
                    var dbincomeStatementsToUpdate = dbIncomeStatements.Where(dbIncomeStatement => dbIncomeStatement.CompanyId == incomeStatement.CompanyId && dbIncomeStatement.Year == incomeStatement.Year).ToList();
                    foreach (var ins in dbincomeStatementsToUpdate)
                    {
                        if (ins != null)
                        {
                            ins.Equals(incomeStatement);
                            incomeStatementsToUpdate.Add(ins);
                        }
                    }
                }
                await incomeSDataAccessDao.UpdateListAsync(incomeStatementsToUpdate);
                #endregion
            }
        }
    }
}
