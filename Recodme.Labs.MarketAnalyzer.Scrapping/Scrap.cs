using DataAccessLayer.Contexts;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recodme.Labs.MarketAnalyzer.Scrapping
{
    public class Scrap
    {
        public void GetInfo()
        {
            var _ctx = new Context();
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://www.slickcharts.com/sp500");

            var headerContent = doc.DocumentNode
                .SelectNodes("//table[@class='table table-hover table-borderless table-sm']").Descendants("td").ToList();
            
            var listOfCompanies = new List<Company>();

            for (int i = 0; i < headerContent.Count() / 7; i++)
            {                
                var count = i * 7;

                var companyName = headerContent[count + 1].InnerText;

                var ticker = headerContent[count + 2].InnerText;

                var rank = Convert.ToInt32(headerContent[count].InnerText);

                var priceString = headerContent[count + 4].InnerText;
                var price = Convert.ToDouble(priceString.Remove(0, 13));

                var company = new Company(companyName, ticker, rank, price);

                listOfCompanies.Add(company);
            }
            _ctx.Companies.AddRange(listOfCompanies);
            _ctx.SaveChanges();
        }
    }    
}
