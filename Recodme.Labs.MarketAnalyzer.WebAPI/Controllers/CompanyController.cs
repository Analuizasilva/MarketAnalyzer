using Microsoft.AspNetCore.Mvc;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.DataLayer.Pocos;
using Recodme.Labs.MarketAnalyzer.WebAPI.Models;
using Recodme.Labs.MarketAnalyzer.WebAPI.Models.Company;
using Recodme.Labs.MarketAnalyzer.WebAPI.Models.Support;
using System.Diagnostics;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System;
using Recodme.Labs.MarketAnalyzer.WebAPI.Models.Home;
using System.Globalization;
using Recodme.Labs.MarketAnalyzer.Analysis.Support;

namespace Recodme.Labs.MarketAnalyzer.WebAPI.Controllers
{
    public class CompanyController : Controller
    {
        private readonly CompanyDataPoco dataPoco;
        private readonly AnalysisBusinessObject analysis;

        public CompanyController()
        {
            this.dataPoco = new CompanyDataPoco();
            this.analysis = new AnalysisBusinessObject();
        }

        //public IActionResult Index()
        //{
        //    var companies = dataPoco.Company;
        //    return View(companies);
        //}

        [HttpGet]
        public IActionResult Details(IndexViewModel indexViewModel)
        {
            //var doubleModelBinder = new DoubleModelBinder();
            //System.Web.Mvc.ModelBinders.Binders.Add(typeof(double), doubleModelBinder);

            var stockData = this.analysis.GetStockData(indexViewModel.WeightNumberRoic, indexViewModel.WeightNumberEquity, indexViewModel.WeightNumberEPS, indexViewModel.WeightNumberRevenue, indexViewModel.WeightNumberPERatio, indexViewModel.WeightNumberDebtToEquity, indexViewModel.WeightNumberAssetsToLiabilities);

            var model = new CompanyViewModel();
            var detailsDataPoco = new DetailsDataPoco();

            var item = stockData
                .Where(x => x.CompanyDataPoco.Company.Ticker == indexViewModel.Ticker)
                .SingleOrDefault();

            if (item != null)
            {
                detailsDataPoco.MarketCapLastFiveYearsGrowth = item.StockAnalysis.MarketCapSlopeInfo.LastFiveYearsGrowth;
                detailsDataPoco.MarketCapLastTenYearsGrowth = item.StockAnalysis.MarketCapSlopeInfo.LastTenYearsGrowth;
                detailsDataPoco.Marketcap = item.StockAnalysis.MarketCapSlopeInfo.Growth;
                detailsDataPoco.MedianMarketCapGrowth = item.StockAnalysis.MarketCapSlopeInfo.GrowthMedian;

                detailsDataPoco.RevenueGrowth = item.StockAnalysis.RevenueSlopeInfo.Growth;
                detailsDataPoco.EquityGrowth = item.StockAnalysis.EquitySlopeInfo.Growth;
                detailsDataPoco.EpsGrowth = item.StockAnalysis.EPSSlopeInfo.Growth;

                detailsDataPoco.EquityNominalValues = item.StockAnalysis.EquitySlopeInfo.NominalValues;
                detailsDataPoco.EPSNominalValues = item.StockAnalysis.EPSSlopeInfo.NominalValues;
                detailsDataPoco.RevenueNominalValues = item.StockAnalysis.RevenueSlopeInfo.NominalValues;               
                detailsDataPoco.Roic = item.StockAnalysis.RoicSlopeInfo.NominalValues;

                detailsDataPoco.PERatio = item.StockAnalysis.PERatio;
                detailsDataPoco.AssetsToLiabilities = item.StockAnalysis.AssetsToLiabilities;
                detailsDataPoco.DebtToEquity = item.StockAnalysis.DebtToEquity;               
                detailsDataPoco.StockPrice = item.StockPrice;

                detailsDataPoco.CompanyName = item.CompanyDataPoco.Company.Name;
                detailsDataPoco.Forbes2000Rank = item.CompanyDataPoco.Company.Forbes2000Rank;
                detailsDataPoco.Ticker = item.CompanyDataPoco.Company.Ticker;
                detailsDataPoco.MarketAnalyzerRank = item.MarketAnalyzerRank;

                detailsDataPoco.AssetsToLiabilitiesFitness = item.StockFitness.AssetsToLiabilitiesFitness;
                detailsDataPoco.DebtToEquityFitness = item.StockFitness.DebtToEquityFitness;
                detailsDataPoco.RoicFitness = item.StockFitness.RoicFitness;
                detailsDataPoco.EquityFitness = item.StockFitness.EquityFitness;
                detailsDataPoco.EPSFitness = item.StockFitness.EPSFitness;
                detailsDataPoco.RevenueFitness = item.StockFitness.RevenueFitness;
                detailsDataPoco.PERatioFitness = item.StockFitness.PERatioFitness;
                detailsDataPoco.TotalFitness = item.StockFitness.RoicFitness * indexViewModel.WeightNumberRoic + item.StockFitness.EquityFitness * indexViewModel.WeightNumberEquity + item.StockFitness.EPSFitness * indexViewModel.WeightNumberEPS + item.StockFitness.RevenueFitness * indexViewModel.WeightNumberRevenue + item.StockFitness.PERatioFitness * indexViewModel.WeightNumberPERatio + item.StockFitness.DebtToEquityFitness * indexViewModel.WeightNumberDebtToEquity + item.StockFitness.AssetsToLiabilitiesFitness * indexViewModel.WeightNumberAssetsToLiabilities;

                detailsDataPoco.WeightNumberRoic = Convert.ToDouble(indexViewModel.WeightNumberRoic, CultureInfo.InvariantCulture);
                detailsDataPoco.WeightNumberEquity = Convert.ToDouble(indexViewModel.WeightNumberEquity, CultureInfo.InvariantCulture);
                detailsDataPoco.WeightNumberEPS = Convert.ToDouble(indexViewModel.WeightNumberEPS, CultureInfo.InvariantCulture);
                detailsDataPoco.WeightNumberRevenue = Convert.ToDouble(indexViewModel.WeightNumberRevenue, CultureInfo.InvariantCulture);
                detailsDataPoco.WeightNumberPERatio = Convert.ToDouble(indexViewModel.WeightNumberPERatio, CultureInfo.InvariantCulture);
                detailsDataPoco.WeightNumberDebtToEquity = Convert.ToDouble(indexViewModel.WeightNumberDebtToEquity, CultureInfo.InvariantCulture);
                detailsDataPoco.WeightNumberAssetsToLiabilities = Convert.ToDouble(indexViewModel.WeightNumberAssetsToLiabilities, CultureInfo.InvariantCulture);

                detailsDataPoco.SlopeRoic = item.StockAnalysis.RoicSlopeInfo.NominalTrendline.Slope;
                detailsDataPoco.SlopeEps = item.StockAnalysis.EPSSlopeInfo.NominalTrendline.Slope;
                detailsDataPoco.SlopeEquity = item.StockAnalysis.EquitySlopeInfo.NominalTrendline.Slope;
                detailsDataPoco.SlopeRevenue = item.StockAnalysis.RevenueSlopeInfo.NominalTrendline.Slope;

                detailsDataPoco.SlopeEpsGrowth = item.StockAnalysis.EPSSlopeInfo.GrowthTrendline.Slope;
                detailsDataPoco.SlopeEquityGrowth = item.StockAnalysis.EquitySlopeInfo.GrowthTrendline.Slope;
                detailsDataPoco.SlopeRevenueGrowth = item.StockAnalysis.RevenueSlopeInfo.GrowthTrendline.Slope;

                detailsDataPoco.MedianRoic = item.StockAnalysis.RoicSlopeInfo.NominalMedian;
                detailsDataPoco.MedianEps = item.StockAnalysis.EPSSlopeInfo.NominalMedian;
                detailsDataPoco.MedianRevenue = item.StockAnalysis.RevenueSlopeInfo.NominalMedian;
                detailsDataPoco.MedianEquity = item.StockAnalysis.EquitySlopeInfo.NominalMedian;

                detailsDataPoco.MedianEquityGrowth = item.StockAnalysis.EquitySlopeInfo.GrowthMedian;
                detailsDataPoco.MedianEpsGrowth = item.StockAnalysis.EPSSlopeInfo.GrowthMedian;
                detailsDataPoco.MedianRevenueGrowth = item.StockAnalysis.RevenueSlopeInfo.GrowthMedian;

                detailsDataPoco.DeviationRoic = item.StockAnalysis.RoicSlopeInfo.NominalDeviation;
                detailsDataPoco.DeviationEps = item.StockAnalysis.EPSSlopeInfo.NominalDeviation;
                detailsDataPoco.DeviationRevenue = item.StockAnalysis.RevenueSlopeInfo.NominalDeviation;
                detailsDataPoco.DeviationEquity = item.StockAnalysis.EquitySlopeInfo.NominalDeviation;

                detailsDataPoco.DeviationEquityGrowth = item.StockAnalysis.EquitySlopeInfo.GrowthDeviation;
                detailsDataPoco.DeviationEpsGrowth = item.StockAnalysis.EPSSlopeInfo.GrowthDeviation;
                detailsDataPoco.DeviationRevenueGrowth = item.StockAnalysis.RevenueSlopeInfo.GrowthDeviation;
            }
            return View(detailsDataPoco);
        }

        #region Chart Roic
        [HttpPost]
        public JsonResult CanvasRoic([FromBody] string ticker)
        {
            var stockData = this.analysis.GetStockData();
            var item = stockData.Where(x => x.CompanyDataPoco.Company.Ticker == ticker).SingleOrDefault();

            List<object> iDados = new List<object>();

            DataTable chartEquity = new DataTable();
            chartEquity.Columns.Add("Year", typeof(System.String));
            chartEquity.Columns.Add(" ", typeof(System.Double));

            if (item != null)
            {
                foreach (var data in item.StockAnalysis.RoicSlopeInfo.NominalValues)
                {
                    chartEquity.Rows.Add(data.Year, Math.Round((double)(data.Value * 100), 2));
                }

                foreach (DataColumn dataColumn in chartEquity.Columns)
                {
                    List<object> x = new List<object>();
                    x = (from DataRow dataRow in chartEquity.Rows select dataRow[dataColumn.ColumnName]).ToList();
                    iDados.Add(x);
                }
            }
            return Json(iDados);
        }
        #endregion

        #region Chart Equity
        [HttpPost]
        public JsonResult CanvasEquity([FromBody] string ticker)
        {
            var stockData = this.analysis.GetStockData();
            var item = stockData.Where(x => x.CompanyDataPoco.Company.Ticker == ticker).SingleOrDefault();

            List<object> iDados = new List<object>();

            DataTable chartEquity = new DataTable();
            chartEquity.Columns.Add("Year", typeof(System.String));
            chartEquity.Columns.Add(" ", typeof(System.Double));

            if (item != null)
            {
                foreach (var data in item.StockAnalysis.EquitySlopeInfo.NominalValues)
                {
                    chartEquity.Rows.Add(data.Year, Math.Round((double)(data.Value * 100), 2));
                }

                foreach (DataColumn dataColumn in chartEquity.Columns)
                {
                    List<object> x = new List<object>();
                    x = (from DataRow dataRow in chartEquity.Rows select dataRow[dataColumn.ColumnName]).ToList();
                    iDados.Add(x);
                }
            }
            return Json(iDados);
        }
        #endregion

        #region Chart Equity Growth
        [HttpPost]
        public JsonResult CanvasEquityGrowth([FromBody] string ticker)
        {
            var stockData = this.analysis.GetStockData();
            var item = stockData.Where(x => x.CompanyDataPoco.Company.Ticker == ticker).SingleOrDefault();

            List<object> iDados = new List<object>();

            DataTable chartEquity = new DataTable();
            chartEquity.Columns.Add("Year", typeof(System.String));
            chartEquity.Columns.Add(" ", typeof(System.Double));

            if (item != null)
            {
                foreach (var data in item.StockAnalysis.EquitySlopeInfo.Growth)
                {
                    chartEquity.Rows.Add(data.Year, Math.Round((double)(data.Value * 100),2));
                }

                foreach (DataColumn dataColumn in chartEquity.Columns)
                {
                    List<object> x = new List<object>();
                    x = (from DataRow dataRow in chartEquity.Rows select dataRow[dataColumn.ColumnName]).ToList();
                    iDados.Add(x);
                }
            }
            return Json(iDados);
        }
        #endregion

        #region Chart Revenue
        [HttpPost]
        public JsonResult CanvasRevenue([FromBody] string ticker)
        {
            var stockData = this.analysis.GetStockData();
            var item = stockData.Where(x => x.CompanyDataPoco.Company.Ticker == ticker).SingleOrDefault();

            List<object> iDados = new List<object>();

            DataTable chartEquity = new DataTable();
            chartEquity.Columns.Add("Year", typeof(System.String));
            chartEquity.Columns.Add(" ", typeof(System.Double));

            if (item != null)
            {
                foreach (var data in item.StockAnalysis.RevenueSlopeInfo.NominalValues)
                {
                    chartEquity.Rows.Add(data.Year, Math.Round((double)(data.Value * 100), 2));
                }

                foreach (DataColumn dataColumn in chartEquity.Columns)
                {
                    List<object> x = new List<object>();
                    x = (from DataRow dataRow in chartEquity.Rows select dataRow[dataColumn.ColumnName]).ToList();
                    iDados.Add(x);
                }
            }
            return Json(iDados);
        }
        #endregion

        #region Chart Revenue Growth
        [HttpPost]
        public JsonResult CanvasRevenueGrowth([FromBody] string ticker)
        {
            var stockData = this.analysis.GetStockData();
            var item = stockData.Where(x => x.CompanyDataPoco.Company.Ticker == ticker).SingleOrDefault();

            List<object> iDados = new List<object>();

            DataTable chartEquity = new DataTable();
            chartEquity.Columns.Add("Year", typeof(System.String));
            chartEquity.Columns.Add(" ", typeof(System.Double));

            if (item != null)
            {
                foreach (var data in item.StockAnalysis.RevenueSlopeInfo.Growth)
                {
                    chartEquity.Rows.Add(data.Year, Math.Round((double)(data.Value * 100), 2));
                }

                foreach (DataColumn dataColumn in chartEquity.Columns)
                {
                    List<object> x = new List<object>();
                    x = (from DataRow dataRow in chartEquity.Rows select dataRow[dataColumn.ColumnName]).ToList();
                    iDados.Add(x);
                }
            }
            return Json(iDados);
        }
        #endregion

        #region Chart Eps
        [HttpPost]
        public JsonResult CanvasEps([FromBody] string ticker)
        {
            var stockData = this.analysis.GetStockData();
            var item = stockData.Where(x => x.CompanyDataPoco.Company.Ticker == ticker).SingleOrDefault();

            List<object> iDados = new List<object>();

            DataTable chartEquity = new DataTable();
            chartEquity.Columns.Add("Year", typeof(System.String));
            chartEquity.Columns.Add(" ", typeof(System.Double));

            if (item != null)
            {
                foreach (var data in item.StockAnalysis.EPSSlopeInfo.NominalValues)
                {
                    chartEquity.Rows.Add(data.Year, Math.Round((double)(data.Value * 100), 2));
                }

                foreach (DataColumn dataColumn in chartEquity.Columns)
                {
                    List<object> x = new List<object>();
                    x = (from DataRow dataRow in chartEquity.Rows select dataRow[dataColumn.ColumnName]).ToList();
                    iDados.Add(x);
                }
            }
            return Json(iDados);
        }
        #endregion

        #region Chart EPS Growth
        [HttpPost]
        public JsonResult CanvasEpsGrowth([FromBody] string ticker)
        {
            var stockData = this.analysis.GetStockData();
            var item = stockData.Where(x => x.CompanyDataPoco.Company.Ticker == ticker).SingleOrDefault();
            List<object> iDados = new List<object>();
            DataTable chartEpsGrowth = new DataTable();
            chartEpsGrowth.Columns.Add("Year", typeof(System.String));
            chartEpsGrowth.Columns.Add(" ", typeof(System.Double));
            if (item != null)
            {
                foreach (var data in item.StockAnalysis.EPSSlopeInfo.Growth)
                {
                    chartEpsGrowth.Rows.Add(data.Year, Math.Round((double)(data.Value * 100), 2));
                }
                foreach (DataColumn dataColumn in chartEpsGrowth.Columns)
                {
                    List<object> x = new List<object>();
                    x = (from DataRow dataRow in chartEpsGrowth.Rows select dataRow[dataColumn.ColumnName]).ToList();
                    iDados.Add(x);
                }
            }
            return Json(iDados);
        }
        #endregion

        #region Chart Market Cap
        [HttpPost]
        public JsonResult CanvasMarketCap([FromBody] string ticker)
        {
            var stockData = this.analysis.GetStockData();
            var item = stockData.Where(x => x.CompanyDataPoco.Company.Ticker == ticker).SingleOrDefault();

            List<object> iDados = new List<object>();

            DataTable chartEquity = new DataTable();
            chartEquity.Columns.Add("Year", typeof(System.Int32));
            chartEquity.Columns.Add("Value", typeof(System.Double));            

            if (item != null)
            {
                foreach (var data in item.StockAnalysis.MarketCapSlopeInfo.NominalValues)
                {
                    double dataDouble = 0;
                    if (data.Value == null)
                    {
                        data.Value = dataDouble;
                    }
                    
                    chartEquity.Rows.Add(data.Year, Math.Round((double)(data.Value * 100), 2));
                }                
               
                foreach (DataColumn dataColumn in chartEquity.Columns)
                {
                    List<object> x = new List<object>();
                    x = (from DataRow dataRow in chartEquity.Rows select dataRow[dataColumn.ColumnName]).ToList();
                    iDados.Add(x);
                }
            }
            return Json(iDados);
        }
        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
