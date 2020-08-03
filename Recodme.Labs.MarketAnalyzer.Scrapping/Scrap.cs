using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.Scrapping
{
    public class Scrap
    {
        public void GetInfo()
        {
            var wc = new WebClient();
            string page = wc.DownloadString("https://www.slickcharts.com/sp500");

            var htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(page);


        }
    }
}
