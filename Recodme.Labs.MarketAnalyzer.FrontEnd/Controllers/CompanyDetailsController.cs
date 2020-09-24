using Microsoft.AspNetCore.Mvc;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.DataLayer.Pocos;
using Recodme.Labs.MarketAnalyzer.FrontEnd.Models;
using Recodme.Labs.MarketAnalyzer.FrontEnd.Models.Home;
using Recodme.Labs.MarketAnalyzer.FrontEnd.Models.Support;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Recodme.Labs.MarketAnalyzer.FrontEnd.Models.CompanyDetails;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNet.Identity;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.UserRecordsBO;
using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recodme.Labs.MarketAnalyzer.Analysis;

namespace Recodme.Labs.MarketAnalyzer.FrontEnd.Controllers
{
    public class CompanyDetailsController : Controller
    {
        private readonly CompanyDataPoco dataPoco;
        private readonly AnalysisBusinessObject analysis;

        public CompanyDetailsController()
        {
            this.dataPoco = new CompanyDataPoco();
            this.analysis = new AnalysisBusinessObject();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Details(IndexViewModel indexViewModel)
        {
            var stockData = this.analysis.GetStockData(indexViewModel.WeightNumberRoic, indexViewModel.WeightNumberEquity, indexViewModel.WeightNumberEPS, indexViewModel.WeightNumberRevenue, indexViewModel.WeightNumberPERatio, indexViewModel.WeightNumberDebtToEquity, indexViewModel.WeightNumberAssetsToLiabilities);

            var model = new CompanyDetailsViewModel();
            var detailsDataPoco = new DetailsDataPoco();
            var notesBO = new NoteBusinessObject();
            var user = User.Identity.GetUserId();

            var growthPrediction = new FutureGrowth();
            

            var item = stockData
                .Where(x => x.CompanyDataPoco.Company.Ticker == indexViewModel.Ticker)
                .SingleOrDefault();

            if (item != null)
            {
                detailsDataPoco.CompanyGrowthPrediction = growthPrediction.GetFutureValues(detailsDataPoco.CompanyId);
                var notes = notesBO.GetNotes(user, item.CompanyDataPoco.Company.Id);
                detailsDataPoco.CompanyId = item.CompanyDataPoco.Company.Id;
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


                detailsDataPoco.StarRaking = item.CompanyDataPoco.Company.StarRaking;
                detailsDataPoco.Outperform = item.CompanyDataPoco.Company.Outperform;
                detailsDataPoco.Underperform = item.CompanyDataPoco.Company.Underperform;

                detailsDataPoco.Notes = notes;

            }
            return View(detailsDataPoco);
        }

        #region Chart Roic
        [AllowAnonymous]
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
        [AllowAnonymous]
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
        [AllowAnonymous]
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

        #region Chart Revenue
        [AllowAnonymous]
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
        [AllowAnonymous]
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
        [AllowAnonymous]
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
        [AllowAnonymous]
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
        [AllowAnonymous]
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

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Details(DetailsDataPoco detailsDataPocoVM)
        {
            var user = User.Identity.GetUserId();


            var stockData = this.analysis.GetStockData(detailsDataPocoVM.WeightNumberRoic, detailsDataPocoVM.WeightNumberEquity, detailsDataPocoVM.WeightNumberEPS, detailsDataPocoVM.WeightNumberRevenue, detailsDataPocoVM.WeightNumberPERatio, detailsDataPocoVM.WeightNumberDebtToEquity, detailsDataPocoVM.WeightNumberAssetsToLiabilities);

            var model = new CompanyDetailsViewModel();
            var detailsDataPoco = new DetailsDataPoco();
            var notesBO = new NoteBusinessObject();

            var item = stockData
                .Where(x => x.CompanyDataPoco.Company.Ticker == detailsDataPocoVM.Ticker)
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
                detailsDataPoco.TotalFitness = item.StockFitness.RoicFitness * detailsDataPocoVM.WeightNumberRoic + item.StockFitness.EquityFitness * detailsDataPocoVM.WeightNumberEquity + item.StockFitness.EPSFitness * detailsDataPocoVM.WeightNumberEPS + item.StockFitness.RevenueFitness * detailsDataPocoVM.WeightNumberRevenue + item.StockFitness.PERatioFitness * detailsDataPocoVM.WeightNumberPERatio + item.StockFitness.DebtToEquityFitness * detailsDataPocoVM.WeightNumberDebtToEquity + item.StockFitness.AssetsToLiabilitiesFitness * detailsDataPocoVM.WeightNumberAssetsToLiabilities;

                detailsDataPoco.WeightNumberRoic = Convert.ToDouble(detailsDataPocoVM.WeightNumberRoic, CultureInfo.InvariantCulture);
                detailsDataPoco.WeightNumberEquity = Convert.ToDouble(detailsDataPocoVM.WeightNumberEquity, CultureInfo.InvariantCulture);
                detailsDataPoco.WeightNumberEPS = Convert.ToDouble(detailsDataPocoVM.WeightNumberEPS, CultureInfo.InvariantCulture);
                detailsDataPoco.WeightNumberRevenue = Convert.ToDouble(detailsDataPocoVM.WeightNumberRevenue, CultureInfo.InvariantCulture);
                detailsDataPoco.WeightNumberPERatio = Convert.ToDouble(detailsDataPocoVM.WeightNumberPERatio, CultureInfo.InvariantCulture);
                detailsDataPoco.WeightNumberDebtToEquity = Convert.ToDouble(detailsDataPocoVM.WeightNumberDebtToEquity, CultureInfo.InvariantCulture);
                detailsDataPoco.WeightNumberAssetsToLiabilities = Convert.ToDouble(detailsDataPocoVM.WeightNumberAssetsToLiabilities, CultureInfo.InvariantCulture);

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


                detailsDataPoco.StarRaking = item.CompanyDataPoco.Company.StarRaking;
                detailsDataPoco.Outperform = item.CompanyDataPoco.Company.Outperform;
                detailsDataPoco.Underperform = item.CompanyDataPoco.Company.Underperform;


                detailsDataPoco.Note = detailsDataPocoVM.Note;
                var note = new Note();
                note.Description = detailsDataPocoVM.Note.Description;
                note.CompanyId = item.CompanyDataPoco.Company.Id;
                note.AspNetUserId = user;

                notesBO.Create(note);

                var notes = notesBO.GetNotes(user, item.CompanyDataPoco.Company.Id);
                detailsDataPoco.Notes = notes;

            }

            return View(detailsDataPoco);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult DeleteNote( string id, string ticker,  double? weightNumberRoic, double? weightNumberEquity, double? weightNumberEps, double? weightNumberRevenue, double? weightNumberPERatio, double? weightNumberDebtToEquity, double? weightNumberAssetsToLiabilities)
        {
            var noteBO = new NoteBusinessObject();
            var noteId = Guid.Parse(id);
            noteBO.Delete(noteId);
            
            return RedirectToAction("Details" , new { ticker, weightNumberRoic , weightNumberEquity, weightNumberEps, weightNumberRevenue, weightNumberPERatio, weightNumberDebtToEquity, weightNumberAssetsToLiabilities });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
