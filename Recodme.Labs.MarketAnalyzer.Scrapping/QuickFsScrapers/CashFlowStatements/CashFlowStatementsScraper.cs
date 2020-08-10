using Newtonsoft.Json.Linq;
using Recodme.Labs.MarketAnalyzer.Scrapping.QuickFsScrapers.CashFlowStatements;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.Scraping.QuickFsScrapers.CashFlowStatements
{
    public class CashFlowStatementsScraper
    {
        public async Task ScraperCashFlowStatements()
        {
            var helper = new WebHelper();
            var request = await helper.ComposeWebRequestGet("https://api.quickfs.net/stocks/MSFT:US/cf/Annual/grL0gNYoMoLUB1ZoAKLfhXkoMoLODiO1WoL9.grLtk3PoMoLmqFEsMasbNK9fkXudkNBtR2jpkr5dINZoAKLtRNZoMlG1MJR3PQk0PiRcOpEfqXGoMwcoqNWaka9tIKO6OlGnPiYiOosoIS1fySsoMoLfAwWthFIfZFLaR29uhSDdkFZoAKLsRNWiq29rIKO6OlPrWQDrWlx4OosokFLtqpacISqaOlmsAKLrISqth25Zkpa2Olt7OaBJOlmnAKLQZCO6PF19vZ.4Cln1o9anX5WXxb47nHBsRfwL7J-rMp073IE-QEfpJZ");
            
            var result = await helper.CallWebRequest(request);
            result = result.Replace("<\\/td>", "");

            //result = result.Replace("\\$[^\\$] * +\\$", "");
            //result = result.Replace("<\\/tbody>", "");
            //result = result.Replace("<\\/table>", "");
            //result = result.Replace("<\\/ tbody ><\\/ table >\"},\"errors\":[],\"code\":0,\"qfs_symbol_v2\":\"MSFT:US\",\"statementPeriod\":\"Annual\"}", "");

            var html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(result);
            
            var htmlNodes = html.DocumentNode.Descendants("td").ToList();
            
            var balaceSheetYear = html.DocumentNode.SelectNodes("//tr[@class='thead']").Descendants("td").ToList().Skip(1).Select(element => element.InnerText.Replace("<\\/td>", ""));
            
            var numberOfColumns = html.DocumentNode.SelectNodes("//tr[@class='thead']").Descendants("td").ToList().Count();
            
            var numberOfRows = htmlNodes.Count / numberOfColumns;
            
            var listValues = new List<CashFlowStatementsValues>();
            
            
            for (int i = 1; i < numberOfRows; i++)
            {
                var index = (numberOfColumns * i);
                var cashFlowStatementsValues = new CashFlowStatementsValues { Key = htmlNodes[index].InnerText };
                var list = new List<string>();
                for (int j = 1; j <= balaceSheetYear.Count(); j++)
                {
                    if (htmlNodes[index + j].InnerText.Replace("<\\/tr>", "") != string.Empty && cashFlowStatementsValues.Key != string.Empty)
                    {
                        list.Add(htmlNodes[index + j].InnerText.Replace("<\\/tr>", ""));
                    }
                }
                if (list.Count > 0)
                {
                    cashFlowStatementsValues.Values = list;
                    listValues.Add(cashFlowStatementsValues);
                }
            }
        }
    }

}
