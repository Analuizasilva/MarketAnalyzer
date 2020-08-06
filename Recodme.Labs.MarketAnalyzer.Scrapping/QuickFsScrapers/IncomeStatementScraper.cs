using DataAccessLayer.Contexts;
using Microsoft.Extensions.Caching.Memory;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.Scraping.QuickFsScrapers
{
    public class IncomeStatementScraper
    {
        public void ScrapeIncomeStatement()
        {
            var ctx = new Context();
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://quickfs.net/company/AAPL:MM");

            var headerContent = doc.DocumentNode
                .SelectNodes("//table[@id= is-table]").Descendants("tr").ToList();

            var listOfCompanies = new List<Company>();
            foreach (var item in headerContent)
            {
                Console.WriteLine(headerContent);
            }

            //for (int i = 0; i < headerContent.Count() / 7; i++)
            //{
            //    var count = i * 7;

            //    var companyName = headerContent[count + 1].InnerText;

            //    var ticker = headerContent[count + 2].InnerText;

            //    var rank = Convert.ToInt32(headerContent[count].InnerText);

            //    var priceString = headerContent[count + 4].InnerText;
            //    var priceTemp = priceString.Remove(0, 13);
            //    var price = Convert.ToDouble(priceTemp, CultureInfo.InvariantCulture);

            //    var company = new Company(companyName, ticker, rank, price);

            //    listOfCompanies.Add(company);
            //}
            //return listOfCompanies;
        }
    }
}
