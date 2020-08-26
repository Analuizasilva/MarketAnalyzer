using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.WebAPI.Models;
using Recodme.Labs.MarketAnalyzer.WebAPI.Models.Home;

namespace Recodme.Labs.MarketAnalyzer.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new IndexViewModel();
            var analysis = new AnalysisBusinessObject();
            var stockFitnessAnalysis = analysis.GetStockFitness();

            foreach( var poco in stockFitnessAnalysis)
            {
                model.Poco.CompanyName = poco.CP.Company.Name;
                model.Poco.Ticker = poco.CP.Company.Ticker;
                model.Poco. = poco.MarketAnalyzerRank;
                model.Forbes2000Rank = poco.CP.Company.Forbes2000Rank;
                model.Fitness = poco.Fitness;
            }

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
