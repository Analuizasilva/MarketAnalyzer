using DataAccessLayer.Contexts;
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
            //var _ctx = new Context();
            //_ctx.Database.EnsureCreated();

            //HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            //HtmlAgilityPack.HtmlDocument doc = web.Load("https://www.slickcharts.com/sp500");

            //var headerContent = doc.DocumentNode
            //    .SelectNodes("//div[@class='table-responsive']").Descendants("a").ToList();


            //var companyNames = new List<HtmlAgilityPack.HtmlNode>();  //par
            //var companyTicker = new List<HtmlAgilityPack.HtmlNode>(); //impar


            //for (var i = 0; i < headerContent.Count; i++)
            //{
            //    if (i % 2 == 0)
            //    {
            //        var data = headerContent[i];
            //        companyNames.Add(data);
            //    }
            //    else if (i % 2 == 1)
            //    {
            //        var data = headerContent[i];
            //        companyTicker.Add(data);
            //    }
            //}


            //foreach (var item in companyTicker)
            //{

            //    Console.WriteLine(item.InnerText);
            //}

            //_ctx.Companies.AddRange();




            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://www.slickcharts.com/sp500");

            var headerContent = doc.DocumentNode
                .SelectNodes("//td[@class='text-nowrap']").ToList();

            foreach (var item in headerContent)
            {
                    Console.WriteLine(item.InnerText);
             }








            



        }
    }
}
