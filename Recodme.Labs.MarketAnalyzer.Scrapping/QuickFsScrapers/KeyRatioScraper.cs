﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Recodme.Labs.MarketAnalyzer.Scraping.QuickFsScrapers
{
    public class KeyRatioScraper
    {
        public async Task<HtmlNode> ScrapeKeyRatio()
        {
            var helper = new WebHelper();
            var request = await helper.ComposeWebRequestGet("https://api.quickfs.net/stocks/AAPL:US/ratios/Annual/grL0gNYoMoLUB1ZoAKLfhXkoMoLODiO1WoL9.grLtk3PoMoLmqFEsMasbNK9fkXudkNBtR2jpkr5dINZoAKLtRNZoMlG1MJR3PQP1PlxcOpEfqXGoMwcoqNWaka9tIKO6OlGnPiYsOosoIS1fySsoMoLiApW1hpffZFLaR29uhSDdkFZoAKLsRNWiq29rIKO6OpLcqSBQJ0ZrPCOcOwHryNIthXBwICO6PKsokpBwyS9dDFLtqoO6grLBDrO6PCsoZ0GoMlH9vN0.4clnWa197BohIJjcOe14FjaQaoJ9aGymU9SIOGqOFku");
            var result = await helper.CallWebRequest(request);
            result = result.Replace("<\\/td>", "</td>");

            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(result);

            var htmlNodes = html.DocumentNode.Descendants().Where(x => x.Name == "tbody").SingleOrDefault();
            Console.WriteLine(htmlNodes.InnerText);
            return htmlNodes;



            
        }


    }
}