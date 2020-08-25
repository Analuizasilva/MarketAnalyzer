using Microsoft.Ajax.Utilities;
using Recodme.Labs.MarketAnalyzer.Analysis;
using Recodme.Labs.MarketAnalyzer.Analysis.Support;
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
            var results = dao.GetCompaniesInfo();
            //var apple = results.FirstOrDefault(x => x.Company.Ticker == "EIPA.F");
            var financial = new FinancialAnalysis();
            var fitness = new FitnessCalculus();
            //var roic = financial.GetPriceToEarnings(apple);
            //var slopeInfo = new SlopeInfo(roic);
            //var fitnessResult = fitness.GetPERatioFitness(slopeInfo);

            //var count = 0;
            //foreach (var item in results)
            //{
            //    var roic = financial.GetRoic(item);
            //    if (roic.All(x => x.Value != null))
            //    {
            //        var slopeinfo = new SlopeInfo(roic);
            //        var fitnessResult = fitness.GetRoicFitness(slopeinfo);
            //        Console.WriteLine(item.Company.Ticker + " " + fitnessResult);
            //        count++;
            //    }               
            //}
            //Console.WriteLine(count);


            var count = 0;
            foreach (var item in results)
            {
                var pe = financial.GetPriceToEarnings(item);
                if (pe.All(x => x.Value != null))
                {
                    var slopeinfo = new SlopeInfo(pe);
                    var fitnessResult = fitness.GetPERatioFitness(slopeinfo);
                    Console.WriteLine(item.Company.Ticker + " " + fitnessResult);
                    count++;
                }
            }
            Console.WriteLine(count);

            //foreach (var item in results)
            //{
            //    var equity = financial.GetEquity(item);
            //    if (equity.All(x => x.Value != null))
            //    {
            //        var slopeinfo = new SlopeInfo(equity);
            //        var fitnessResult = fitness.GetEquityFitness(slopeinfo);
            //        Console.WriteLine(item.Company.Ticker + " " + fitnessResult);
            //    }
            //}
            //Console.WriteLine(results.Count + " " + "Companies " );

            //var ExtractedValues = new List<ExtractedValue>();
            //var mathCalculus = new MathCalculus();
            //mathCalculus.CalculateLastThreeYearsGrowth(ExtractedValues);

            //var equity = financial.GetEquity(apple);

            //var slopeinfo = new SlopeInfo(equity);

            //var growthTrendline = slopeinfo.GrowthTrendline;
            //var growth = slopeinfo.Growth;

            //var stockAnalysisApple = new StockAnalysis(apple);

            //double equityFitness = 0;
            //var equityAbsSlope = stockAnalysisApple.EquitySlopeInfo.GrowthTrendline.Slope;
            //if (equityAbsSlope < 0) equityFitness = 0;
            //else if (equityAbsSlope < 1) equityFitness = 0.5;
            //else equityFitness = 1 - 1 / equityAbsSlope;

            //var growthEquityTrendline = stockAnalysisApple.EquitySlopeInfo.GrowthTrendline;

            //var roicSlope = stockAnalysisApple.RoicSlopeInfo.NominalTrendline;
            //var roicDeviation = stockAnalysisApple.RoicSlopeInfo.NominalDeviation;

            //var ratio = Math.Abs((double)(roicDeviation / roicSlope));
            //double? roicFitness = 0;
            //if (ratio >= 1) roicFitness = 1 / ratio;
            //else roicFitness = 1;

            //var fitnessCalculus = new FitnessCalculus();
            //fitnessCalculus.RoicFitness(apple);

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