﻿using DataAccessLayer.Contexts;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Recodme.Labs.MarketAnalyzer.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var _ctx = new Context();
            _ctx.Database.EnsureCreated();

            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://www.slickcharts.com/sp500");

            var headerContent = doc.DocumentNode
                .SelectNodes("//table[@class='table table-hover table-borderless table-sm']").Descendants("td").ToList();

            var listOfCompanies = new List<Company>();

            for (int i = 0; i < headerContent.Count() / 7; i++)
            {
                var count = i * 7;
                //Console.WriteLine($"{headerContent[count].InnerText} | {headerContent[count + 1].InnerText} |{headerContent[count + 2].InnerText} |{headerContent[count + 4].InnerText} ");

                var _rank = Convert.ToInt32(headerContent[count].InnerText);

                var _priceString = headerContent[count + 4].InnerText;
                var _price = Convert.ToDouble(_priceString.Remove(0, 13));

                var _company = new Company(headerContent[count + 1].InnerText, headerContent[count + 2].InnerText, _rank, _price);
             
                listOfCompanies.Add(_company);
                _ctx.Companies.AddRange(listOfCompanies);

            }

        }
    }
}
