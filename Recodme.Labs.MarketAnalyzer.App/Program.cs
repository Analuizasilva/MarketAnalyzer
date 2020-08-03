using DataAccessLayer.Contexts;
using System;
using System.Linq;

namespace Recodme.Labs.MarketAnalyzer.App
{
    class Program
    {
        static void Main(string[] args)
        {

            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://www.slickcharts.com/sp500");

            var Name = doc.DocumentNode
                .SelectNodes("//div[@class='table-responsive']").ToList();

            foreach(var item in Name)
            {
                Console.WriteLine(item.InnerText);
            }

        }
    }
}
