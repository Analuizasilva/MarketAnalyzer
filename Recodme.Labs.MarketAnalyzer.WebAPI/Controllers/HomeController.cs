using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Recodme.Labs.MarketAnalyzer.Analysis.Support;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.WebAPI.Models;
using Recodme.Labs.MarketAnalyzer.WebAPI.Models.Home;
using Recodme.Labs.MarketAnalyzer.WebAPI.Models.Support;

namespace Recodme.Labs.MarketAnalyzer.WebAPI.Controllers
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
           

            foreach( var poco in stockFitnessAnalysis)
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

            foreach(var poco in stockFitnessAnalysis)
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

        public IActionResult CompanyInfo(Guid companyId)
        {
            //vai buscar info da company ao business
            //cria viewModel e preenche com dados
            //passa viewModel para a view
            return View();
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
