using Microsoft.AspNetCore.Mvc;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.DataLayer.Pocos;
using Recodme.Labs.MarketAnalyzer.WebAPI.Models;
using Recodme.Labs.MarketAnalyzer.WebAPI.Models.Company;
using Recodme.Labs.MarketAnalyzer.WebAPI.Models.Support;
using System.Diagnostics;
using System.Linq;

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
        public IActionResult Details(string ticker)
        {
            var dataPoco = new CompanyDataPoco();
            //vai buscar info da company ao business
            //cria viewModel e preenche com dados
            //passa viewModel para a view

            var analysis = new AnalysisBusinessObject();
            var stockData = analysis.GetStockData();

            var model = new CompanyModelView();
            var detailsDataPoco = new DetailsDataPoco();

            var item = stockData.Where(x => x.CompanyDataPoco.Company.Ticker == ticker).SingleOrDefault();

            if (item != null)
            {
                detailsDataPoco.Marketcap = item.Marketcap;
                detailsDataPoco.RevenueGrowth = item.StockAnalysis.RevenueSlopeInfo.Growth;
                detailsDataPoco.EquityGrowth = item.StockAnalysis.EquitySlopeInfo.Growth;
                detailsDataPoco.EpsGrowth = item.StockAnalysis.EPSSlopeInfo.Growth;

                detailsDataPoco.CompanyName = item.CompanyDataPoco.Company.Name;
                detailsDataPoco.Forbes2000Rank = item.CompanyDataPoco.Company.Forbes2000Rank;
                detailsDataPoco.Ticker = item.CompanyDataPoco.Company.Ticker;
                detailsDataPoco.MarketAnalyzerRank = item.MarketAnalyzerRank;
                detailsDataPoco.StockPrice = item.StockPrice;

                detailsDataPoco.AssetsToLiabilities = item.StockAnalysis.AssetsToLiabilities;
                detailsDataPoco.DebtToEquity = item.StockAnalysis.DebtToEquity;
                detailsDataPoco.Roic = item.StockAnalysis.Roic;
                detailsDataPoco.Equity = item.StockAnalysis.Equity;
                detailsDataPoco.EPS = item.StockAnalysis.EPS;
                detailsDataPoco.Revenue = item.StockAnalysis.Revenue;
                detailsDataPoco.PERatio = item.StockAnalysis.PERatio;

                detailsDataPoco.AssetsToLiabilitiesFitness = item.StockFitness.AssetsToLiabilitiesFitness;
                detailsDataPoco.DebtToEquityFitness = item.StockFitness.DebtToEquityFitness;
                detailsDataPoco.RoicFitness = item.StockFitness.RoicFitness;
                detailsDataPoco.EquityFitness = item.StockFitness.EquityFitness;
                detailsDataPoco.EPSFitness = item.StockFitness.EPSFitness;
                detailsDataPoco.RevenueFitness = item.StockFitness.RevenueFitness;
                detailsDataPoco.PERatioFitness = item.StockFitness.PERatioFitness;
                detailsDataPoco.TotalFitness = item.StockFitness.TotalFitness;

                detailsDataPoco.WeightNumberRoic = item.StockFitness.WeightNumberRoic;
                detailsDataPoco.WeightNumberEquity = item.StockFitness.WeightNumberEquity;
                detailsDataPoco.WeightNumberEPS = item.StockFitness.WeightNumberEPS;
                detailsDataPoco.WeightNumberRevenue = item.StockFitness.WeightNumberRevenue;
                detailsDataPoco.WeightNumberPERatio = item.StockFitness.WeightNumberPERatio;
                detailsDataPoco.WeightNumberDebtToEquity = item.StockFitness.WeightNumberDebtToEquity;
                detailsDataPoco.WeightNumberAssetsToLiabilities = item.StockFitness.WeightNumberAssetsToLiabilities;
            }
            return View(detailsDataPoco);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}