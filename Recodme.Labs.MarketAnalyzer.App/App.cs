using Microsoft.Ajax.Utilities;
using Recodme.Labs.MarketAnalyzer.Analysis;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.App
{
    public class App
    {
        public async Task Run()
        {
            var financial = new FinancialAnalysis();
            financial.GetRoic();
        }
    }
}