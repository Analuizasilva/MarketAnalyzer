using Microsoft.Ajax.Utilities;
using Recodme.Labs.MarketAnalyzer.Analysis;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer.Base;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.App
{
    public class App
    {
        public async Task Run()
        {
            var dao = new CompanyDataAccessObject();
            var result = dao.GetCompaniesInfo();
            var apple = result.FirstOrDefault(x => x.Company.Ticker == "AIPBF");

            var financial = new FinancialAnalysis();
            var equity = financial.GetEquity(apple);

            var slopeinfo = new SlopeInfo(equity);
            var growthTrendline = slopeinfo.GrowthTrendline;
            var growth = slopeinfo.Growth;

            var stockAnalysisApple = new StockAnalysis(apple);

            double equityFitness = 0;
            var equityAbsSlope = stockAnalysisApple.EquitySlopeInfo.GrowthTrendline.Slope;
            if (equityAbsSlope < 0) equityFitness = 0;
            else if (equityAbsSlope < 1) equityFitness = 0.5;
            else equityFitness = 1 - 1 / equityAbsSlope;


            var growthEquityTrendline = stockAnalysisApple.EquitySlopeInfo.GrowthTrendline;


            var roicSlope = stockAnalysisApple.RoicSlopeInfo.NominalTrendline.Slope;
            var roicDeviation = stockAnalysisApple.RoicSlopeInfo.NominalDeviation;
            var ratio = Math.Abs((double)(roicDeviation / roicSlope));
            double? roicFitness = 0;
            if (ratio >= 1) roicFitness = 1 / ratio;
            else roicFitness = 1;

            //var companyDAO = new BaseDataAccessObject<Company>();
            //var companyDB = companyDAO.ListAsync().Result;
            //var info = companyDAO.GetCompaniesInfo();

            //foreach (var company in companyDB)
            //{
            //    if (company.Ticker == "AAPL")
            //    {
            //        var companyId = company.Id;
            //        var slopeInfo = new SlopeInfo();
            //        slopeInfo.CalculateEquityGrowth(companyId);
            //        slopeInfo.CalculateEpsGrowth(companyId);
            //    }
            //}

        }
    }
}