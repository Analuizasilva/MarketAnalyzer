using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recodme.Labs.MarketAnalyzer.Analysis;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.DataLayer.Pocos;
using Recodme.Labs.MarketAnalyzer.WebAPI.Models.Company;

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

        public async Task<IActionResult> Details(Guid companyId)
        {
            var dataPoco = new CompanyDataPoco();
            //vai buscar info da company ao business
            //cria viewModel e preenche com dados
            //passa viewModel para a view
            var analysis = new AnalysisBusinessObject();
            var stockData = analysis.GetStockFitness();
            var model = new CompanyModelView();

            foreach (var item in stockData)
            {
                model.CompanyName = item.CP.Company.Name;
                model.CompanyRank = item.CP.Company.Forbes2000Rank;
                model.CompanyTicker = item.CP.Company.Ticker;
                model.MaRank = item.Fitness.Value;

            }
            var com = new CompanyModelView();
            return View(com);
        }
    }
}