﻿using Recodme.Labs.MarketAnalyzer.DataAccessLayer.Base;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.Scraping.QuickFsScrapers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.QuickFS
{
    public class BalanceSheetBO
    {
        #region Scrape All Balance Sheet
        public async Task<List<List<BalanceSheet>>> ScrapeAllBalanceSheet()
        {
            var dataAccessDao = new BaseDataAccessObject<Company>();
            var BalanceSheetDataAccessDao = new BaseDataAccessObject<BalanceSheet>();
            var dbCompanies = dataAccessDao.GetDataBaseCompanies();
            var balanceSheets = new List<List<BalanceSheet>>();
            var balanceSheetScraper = new BalanceSheetScraper();

            foreach (var company in dbCompanies)
            {
                var ticker = company.Ticker;

                Random rnd = new Random();
                await Task.Delay(TimeSpan.FromSeconds(rnd.Next(1, 10)));

                var balanceSheet = await balanceSheetScraper.ScrapeBalanceSheet(ticker, HelperVars.QuickFsApiKey);

                foreach (var bs in balanceSheet)
                {
                    bs.CompanyId = company.Id;
                    Console.WriteLine(ticker + " " + bs.Year + " " + bs.CashEquivalents);
                }
                await BalanceSheetDataAccessDao.AddListAsync(balanceSheet);
                balanceSheets.Add(balanceSheet);
            }            
            return balanceSheets;
        }
        #endregion       
    }
}
