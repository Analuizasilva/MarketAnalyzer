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
            //var wc = new WebClient();
            //string page = wc.DownloadString("https://www.slickcharts.com/sp500");

            //var htmlDocument = new HtmlAgilityPack.HtmlDocument();
            //htmlDocument.LoadHtml(page);

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

                var _rank = Convert.ToInt32(headerContent[count].InnerText);

                var _priceString = headerContent[count + 4].InnerText;
                var _price = _priceString.Remove(0, 13);

                var _company = new Company(companyName, ticker, _rank, _price);

                listOfCompanies.Add(_company);
            }
            _ctx.Companies.AddRange(listOfCompanies);
            _ctx.SaveChanges();
        }
    }    
}
