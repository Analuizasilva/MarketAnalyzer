using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recodme.Labs.MarketAnalyzer.FrontEnd.Models.Home;

namespace Recodme.Labs.MarketAnalyzer.FrontEnd.Controllers
{
    public class NoteController : Controller
    {
        [HttpGet]
        public IActionResult GetNotes()
        {
            var model = new IndexViewModel();
            var analysis = new AnalysisBusinessObject();
            var stockFitnessAnalysis = analysis.GetStockData();


            foreach (var poco in stockFitnessAnalysis)
            {
                var homeData = new HomeDataPoco();
                homeData.CompanyName = poco.CompanyDataPoco.Company.Name;
                homeData.Ticker = poco.CompanyDataPoco.Company.Ticker;
                homeData.MarketAnalyzerRank = poco.MarketAnalyzerRank;
                if (poco.CompanyDataPoco.Company.StockPrice != 0)
                {
                    homeData.StockPrice = poco.CompanyDataPoco.Company.StockPrice;
                }
                homeData.Fitness = poco.Fitness;
                homeData.Ticker = poco.CompanyDataPoco.Company.Ticker;
                model.HomeDataPocos.Add(homeData);
            }

            model.HomeDataPocos.OrderByDescending(l => l.MarketAnalyzerRank);

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel vm)
        {
            var model = new IndexViewModel();
            var analysis = new AnalysisBusinessObject();
            var stockFitnessAnalysis = analysis.GetStockData(vm.WeightNumberRoic, vm.WeightNumberEquity, vm.WeightNumberEPS, vm.WeightNumberRevenue, vm.WeightNumberPERatio, vm.WeightNumberDebtToEquity, vm.WeightNumberAssetsToLiabilities);

            foreach (var poco in stockFitnessAnalysis)
            {
                var homeData = new HomeDataPoco();
                homeData.CompanyName = poco.CompanyDataPoco.Company.Name;
                homeData.Ticker = poco.CompanyDataPoco.Company.Ticker;
                homeData.MarketAnalyzerRank = poco.MarketAnalyzerRank;
                if (poco.CompanyDataPoco.Company.StockPrice != 0)
                {
                    homeData.StockPrice = poco.CompanyDataPoco.Company.StockPrice;
                }
                homeData.Fitness = poco.Fitness;
                homeData.Ticker = poco.CompanyDataPoco.Company.Ticker;
                model.HomeDataPocos.Add(homeData);
            }

            model.WeightNumberRoic = Convert.ToDouble(vm.WeightNumberRoic, CultureInfo.InvariantCulture);
            model.WeightNumberEquity = Convert.ToDouble(vm.WeightNumberEquity, CultureInfo.InvariantCulture);
            model.WeightNumberEPS = Convert.ToDouble(vm.WeightNumberEPS, CultureInfo.InvariantCulture);
            model.WeightNumberRevenue = Convert.ToDouble(vm.WeightNumberRevenue, CultureInfo.InvariantCulture);
            model.WeightNumberPERatio = Convert.ToDouble(vm.WeightNumberPERatio, CultureInfo.InvariantCulture);
            model.WeightNumberDebtToEquity = Convert.ToDouble(vm.WeightNumberDebtToEquity, CultureInfo.InvariantCulture);
            model.WeightNumberAssetsToLiabilities = Convert.ToDouble(vm.WeightNumberAssetsToLiabilities, CultureInfo.InvariantCulture);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
