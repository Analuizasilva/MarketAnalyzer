using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recodme.Labs.MarketAnalyzer.Analysis;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.DataLayer.Pocos;
using Recodme.Labs.MarketAnalyzer.WebAPI.Models.Company;
using Recodme.Labs.MarketAnalyzer.WebAPI.Models.Support;

namespace Recodme.Labs.MarketAnalyzer.WebAPI.Controllers
{
    public class CompanyController : Controller
    {
        private readonly CompanyDataPoco dataPoco = new CompanyDataPoco();

        public IActionResult Index()
        {
            var companies = dataPoco.Company;
            return View(companies);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid companyId)
        {
            var dataPoco = new CompanyDataPoco();
            //vai buscar info da company ao business
            //cria viewModel e preenche com dados
            //passa viewModel para a view
            var analysis = new AnalysisBusinessObject();
            var stockData = analysis.GetStockFitness();

            var model = new CompanyModelView();
            var homeDataPoco = new HomeDataPoco();

            foreach (var item in stockData)
            {
                homeDataPoco.CompanyName = item.CP.Company.Name;
                homeDataPoco.Forbes2000Rank = item.CP.Company.Forbes2000Rank;
                homeDataPoco.Ticker = item.CP.Company.Ticker;
                homeDataPoco.MarketAnalyzerRank = item.MarketAnalyzerRank;
                model.HomeDataPoco.Add(homeDataPoco);
            }       
            return View(model);
        }
    }
}