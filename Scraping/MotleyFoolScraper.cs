using Recodme.Labs.MarketAnalyzer.DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.Scraping
{
    public class MotleyFoolScraper
    {
        public Company ScrapeCAPSRating(string ticker)
        {
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();

            HtmlAgilityPack.HtmlDocument doc = web.Load("https://www.fool.com/quote/"+ticker);
            if (doc.DocumentNode
                .SelectNodes("//div[@class='widget single caps-section']") != null)
            {
                var headerContent = doc.DocumentNode
                .SelectNodes("//div[@class='widget single caps-section']").Descendants("span");
                var stars = doc.DocumentNode.SelectSingleNode("//div[@class='widget single caps-section']").Descendants("img");

                var textList = new List<string>();
                foreach (var h in headerContent)
                {
                    var text = h.InnerText;
                    textList.Add(text);
                }

                double? outperform = double.Parse(textList[1]);
                double? underperform = double.Parse(textList[3]);

                var starString = "";
                int? star = 0;
                var starsList = new List<string>();
                foreach (var s in stars)
                {
                    starString = s.OuterHtml;
                    starsList.Add(starString);
                }
                string number = Convert.ToString(starsList[0][10]);
                star = int.Parse(number);

                var company = new Company();
                company.Outperform = outperform;
                company.Underperform = underperform;
                company.StarRaking = star;
                company.Ticker = ticker;
                Console.WriteLine(company.Ticker);
                return company;
            }
            else return null;
        }
    }
}
