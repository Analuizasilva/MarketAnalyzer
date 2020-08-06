using HtmlAgilityPack;
using Recodme.Labs.MarketAnalyzer.Scraping.QuickFsScrapers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.QuickFS
{
    public class BalaceSheetBO
    {
        public async Task OrderBalaceShettInfo(HtmlNode node)
        {
            var balanceSheetScraper = new BalanceSheetScraper();
            balanceSheetScraper.ScrapeBalanceSheet();
        }
    }
}
