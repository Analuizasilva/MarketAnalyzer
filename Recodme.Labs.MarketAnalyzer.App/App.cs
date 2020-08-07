using DataAccessLayer.Contexts;
using Microsoft.Ajax.Utilities;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.Scraping;
using Recodme.Labs.MarketAnalyzer.Scraping.QuickFsScrapers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Recodme.Labs.MarketAnalyzer.App
{
    public class App
    {
        public async Task Run()
        {
            var incomestatementScraper = new IncomeStatementScraper();
            var result = await incomestatementScraper.ScrapeIncomeStatement();
            await incomestatementScraper.OrganizeScrapedIncomeStatement(result);
        }
    }
}