using Microsoft.AspNetCore.Mvc;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.DataLayer.Pocos;
using Recodme.Labs.MarketAnalyzer.WebAPI.Models;
using Recodme.Labs.MarketAnalyzer.WebAPI.Models.Company;
using Recodme.Labs.MarketAnalyzer.WebAPI.Models.Support;
using System.Diagnostics;
using System.Linq;
using FusionCharts.Visualization;
using FusionCharts.DataEngine;
using System.Data;


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

            var model = new CompanyViewModel();
            var detailsDataPoco = new DetailsDataPoco();

            var item = stockData.Where(x => x.CompanyDataPoco.Company.Ticker == ticker).SingleOrDefault();

            if (item != null)
            {
                detailsDataPoco.Marketcap = item.Marketcap;
                detailsDataPoco.RevenueGrowth = item.StockAnalysis.RevenueSlopeInfo.Growth;
                detailsDataPoco.EquityGrowth = item.StockAnalysis.EquitySlopeInfo.Growth;
                detailsDataPoco.EpsGrowth = item.StockAnalysis.EPSSlopeInfo.Growth;
                detailsDataPoco.EquityNominalValues = item.StockAnalysis.EquitySlopeInfo.NominalValues;
                detailsDataPoco.EPSNominalValues = item.StockAnalysis.EPSSlopeInfo.NominalValues;
                detailsDataPoco.RevenueNominalValues = item.StockAnalysis.RevenueSlopeInfo.NominalValues;

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



            // Equity Chart

            DataTable ChartData = new DataTable();
            ChartData.Columns.Add("Year", typeof(System.String));
            ChartData.Columns.Add(" ", typeof(System.Double));
            foreach (var data in detailsDataPoco.EquityNominalValues)
            {
                ChartData.Rows.Add(data.Year, data.Value);
            }

            StaticSource source = new StaticSource(ChartData);
            DataModel model1 = new DataModel();
            model1.DataSources.Add(source);

            Charts.SplineChart spline = new Charts.SplineChart("spline_chart");

            spline.ThemeName = FusionChartsTheme.ThemeName.FUSION;
            spline.Width.Pixel(700);
            spline.Height.Pixel(400);

            spline.Data.Source = model1;

            spline.Caption.Text = "Equity (%)";
            spline.Caption.Bold = true;

            spline.SubCaption.Text = "";
            spline.XAxis.Text = "Year";
            spline.YAxis.Text = "Value";

            spline.Legend.Show = false;

            ViewData["Chart1"] = spline.Render();



            // Revenue Growth Chart

            DataTable ChartData2 = new DataTable();
            ChartData2.Columns.Add("Year", typeof(System.String));
            ChartData2.Columns.Add(" ", typeof(System.Double));
            foreach (var data in detailsDataPoco.RevenueGrowth)
            {
                ChartData2.Rows.Add(data.Year, data.Value * 100);
            }

            StaticSource source2 = new StaticSource(ChartData2);
            DataModel model2 = new DataModel();
            model2.DataSources.Add(source2);

            Charts.SplineChart spline2 = new Charts.SplineChart("spline_chart");

            spline2.ThemeName = FusionChartsTheme.ThemeName.FUSION;
            spline2.Width.Pixel(700);
            spline2.Height.Pixel(400);

            spline2.Data.Source = model2;

            spline2.Caption.Text = "Revenue Growth (%)";
            spline2.Caption.Bold = true;

            spline2.SubCaption.Text = "";
            spline2.XAxis.Text = "Year";
            spline2.YAxis.Text = "Value";

            spline2.Legend.Show = false;

            ViewData["Chart2"] = spline2.Render();

            return View(detailsDataPoco);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


//using System;
//using System.Web;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading.Tasks;
//using FusionCharts.Visualization;
//using FusionCharts.DataEngine;
//using System.Data;
//using Microsoft.AspNetCore.Mvc;

//namespace FusionChartsSamples
//{
//    public class CompanyController : Controller
//    {
//        public ActionResult Index1()
//        {
//            DataTable ChartData = new DataTable();
//            ChartData.Columns.Add("Year", typeof(System.String));
//            ChartData.Columns.Add("", typeof(System.Double));
//            ChartData.Rows.Add("2010", 15123);
//            ChartData.Rows.Add("2011", 14233);
//            ChartData.Rows.Add("2012", 23507);
//            ChartData.Rows.Add("2013", 9110);
//            ChartData.Rows.Add("2014", 15529);
//            ChartData.Rows.Add("2015", 20803);
//            ChartData.Rows.Add("2016", 19202);
//            StaticSource source = new StaticSource(ChartData);
//            DataModel model = new DataModel();
//            model.DataSources.Add(source);

//            Charts.LineChart line = new Charts.LineChart("line_chart_db");

//            line.ThemeName = FusionChartsTheme.ThemeName.FUSION;
//            line.Width.Pixel(700);
//            line.Height.Pixel(400);

//            line.Data.Source = model;

//            line.Caption.Text = "Apple ROIC";
//            line.Caption.Bold = true;

//            line.SubCaption.Text = "";
//            line.XAxis.Text = "Year";
//            line.YAxis.Text = "Millions";

//            line.Legend.Show = false;
//            line.ThemeName = FusionChartsTheme.ThemeName.FUSION;
//            ViewData["Chart"] = line.Render();
//            return View();
//        }
//    }
//}