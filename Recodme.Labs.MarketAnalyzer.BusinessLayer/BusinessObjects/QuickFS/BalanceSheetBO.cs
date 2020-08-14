using HtmlAgilityPack;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.Scraping.QuickFsScrapers;
using Recodme.Labs.MarketAnalyzer.Scraping.SlickChartsScrapers;
using Recodme.Labs.MarketAnalyzer.Scrapping.QuickFsScrapers.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.QuickFS
{
    public class BalanceSheetBO
    {
        #region Scrape All Balance Sheet
        public async Task<List<List<BalanceSheet>>> ScrapeAllBalanceSheet()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));

            var slickChartsScraper = new SlickChartsScraper();
            var companies = slickChartsScraper.ScrapeCompanies();

            var balanceSheetScraper = new BalanceSheetScraper();

            var balanceSheet = await balanceSheetScraper.AddToBalanceSheet();

            var allBalanceSheet = new List<List<BalanceSheet>>();
            var ticker = "";
            foreach (var company in companies)
            {
                if (company.Ticker != "OXY.WT")
                {
                    ticker = company.Ticker;

                    foreach (var bs in balanceSheet)
                    {
                        //bs.CompanyId = company.Id; mudar para o company da base de dados
                        Console.WriteLine(ticker + " " + bs.Year + " " + bs.CashEquivalents);
                    }
                    allBalanceSheet.Add(balanceSheet);
                }
                var extractedValuesList = await balanceSheetScraper.ScrapeBalanceSheet("ticker");
                await this.AddToBalanceSheet(extractedValuesList);
            }
            return allBalanceSheet;
        }

        #endregion     
    }
}
