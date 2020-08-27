using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.WebAPI.Models;
using Recodme.Labs.MarketAnalyzer.WebAPI.Models.Home;
using Recodme.Labs.MarketAnalyzer.WebAPI.Models.Support;
using System;
using System.Diagnostics;
using System.Linq;

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


            foreach (var poco in stockFitnessAnalysis)
            {
                var homeData = new HomeDataPoco();
                homeData.CompanyName = poco.CompanyDataPoco.Company.Name;
                homeData.Ticker = poco.CompanyDataPoco.Company.Ticker;
                homeData.MarketAnalyzerRank = poco.MarketAnalyzerRank;
                homeData.Forbes2000Rank = poco.CompanyDataPoco.Company.Forbes2000Rank;
                homeData.Fitness = poco.Fitness;

                model.HomeDataPocos.Add(homeData);
            }

            model.HomeDataPocos.OrderByDescending(l => l.MarketAnalyzerRank);

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
