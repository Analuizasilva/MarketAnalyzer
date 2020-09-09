using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
using Recodme.Labs.MarketAnalyzer.FrontEnd.Models;
using Recodme.Labs.MarketAnalyzer.FrontEnd.Models.Home;
using Recodme.Labs.MarketAnalyzer.FrontEnd.Models.Support;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace Recodme.Labs.MarketAnalyzer.FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
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
            var weightNumber = new Note();
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

            weightNumber.WeightNumberRoic = Convert.ToDouble(vm.WeightNumberRoic, CultureInfo.InvariantCulture);
            weightNumber.WeightNumberEquity = Convert.ToDouble(vm.WeightNumberEquity, CultureInfo.InvariantCulture);
            weightNumber.WeightNumberRevenue = Convert.ToDouble(vm.WeightNumberRevenue, CultureInfo.InvariantCulture);
            weightNumber.WeightNumberAssetsToLiabilities = Convert.ToDouble(vm.WeightNumberAssetsToLiabilities, CultureInfo.InvariantCulture);
            weightNumber.WeightNumberDebtToEquity = Convert.ToDouble(vm.WeightNumberDebtToEquity, CultureInfo.InvariantCulture);
            weightNumber.WeightNumberEPS = Convert.ToDouble(vm.WeightNumberEPS, CultureInfo.InvariantCulture);
            weightNumber.WeightNumberPERatio = Convert.ToDouble(vm.WeightNumberPERatio, CultureInfo.InvariantCulture);
            
            return View(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
