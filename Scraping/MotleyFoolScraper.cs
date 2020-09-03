using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.Scraping
{
    public class MotleyFoolScraper
    {
        public void ScrapeCAPSRating()
        {
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://www.fool.com/quote/aapl");

            var headerContent = doc.DocumentNode
                .SelectNodes("//div[@class='widget single caps-section']");
            var stars = doc.DocumentNode.SelectSingleNode("//div[@class='widget single caps-section']").Descendants("img");
            foreach(var h in headerContent)
            {
                Console.WriteLine(h.InnerText);
                
            }
            foreach(var s in stars)
            {
                Console.WriteLine(s.OuterHtml);
            }

            var content = doc.ParsedText;

        }
    }
}
