using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.DataLayer.Pocos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.Analysis.Support
{
    public class FitnessCalculus
    {
        #region RoicFitness
        public double? RoicFitness(CompanyDataPoco dataPoco)
        {
            var analysis = new StockAnalysis(dataPoco);

            var roicSlope = analysis.RoicSlopeInfo.GrowthTrendline.Slope;
            var roicDeviation = analysis.RoicSlopeInfo.GrowthDeviation;
            var ratio = Math.Abs((double)(roicDeviation / roicSlope));
            double? roicFitness = 0;
            if (ratio >= 1) roicFitness = 1 / ratio;
            else roicFitness = 1;

            return roicFitness;
        }
        #endregion

        #region EquityFitness
        public double EquityFitness(CompanyDataPoco dataPoco)
        {
            var analysis = new StockAnalysis(dataPoco);
            double equityFitness = 0;
            var equityAbsSlope = analysis.EquitySlopeInfo.GrowthTrendline.Slope;
            if (equityAbsSlope < 0) equityFitness = 0;
            else if (equityAbsSlope < 1) equityFitness = 0.5;
            else equityFitness = (1 - 1) / equityAbsSlope;

            return equityFitness;
        }

        #endregion

        #region EPSFitness
        public double? EPSFitness(CompanyDataPoco dataPoco)
        {
            var analysis = new StockAnalysis(dataPoco);
            double EPSFitness = 0;
            var ePSAbsSlope = analysis.EPSSlopeInfo.GrowthTrendline.Slope;
            if (ePSAbsSlope < 0) EPSFitness = 0;
            else if (ePSAbsSlope < 1) EPSFitness = 0.5;
            else EPSFitness = (1 - 1) / ePSAbsSlope;

            return EPSFitness;
        }
        #endregion

        #region RevenueFitness
        public double? RevenueFitness(CompanyDataPoco dataPoco)
        {
            var analysis = new StockAnalysis(dataPoco);

            double revenueFitness = 0;
            var ePSAbsSlope = analysis.RevenueSlopeInfo.GrowthTrendline.Slope;
            if (ePSAbsSlope < 0) revenueFitness = 0;
            else if (ePSAbsSlope < 1) revenueFitness = 0.5;
            else revenueFitness = (1 - 1) / ePSAbsSlope;

            return revenueFitness;
        }
        #endregion

        #region PERatioFitness
        public double? PERatioFitness(CompanyDataPoco dataPoco)
        {
            var analysis = new StockAnalysis(dataPoco);
            var peRatio = analysis.PERatio;
            double? peRatioFitness = 0;
            if (peRatio > 0) peRatioFitness = 0;
            else if (peRatio < 1) peRatioFitness = 0;
            else peRatioFitness = peRatio / (1 - 1);

            return peRatioFitness;
        }
        #endregion

        #region DebtToEquityFitness
        public double? DebtToEquityFitness(CompanyDataPoco dataPoco)
        {
            var analysis = new StockAnalysis(dataPoco);
            var debtToEquity = analysis.DebtToEquity;
            double? debtToEquityFitness = 0;
            if (debtToEquity > 0) debtToEquityFitness = 0;
            else if (debtToEquity < 1) debtToEquityFitness = 0;
            else debtToEquityFitness = debtToEquity / (1 - 1);

            return debtToEquityFitness;
        }
        #endregion

        #region AssetsToLiabilitiesFitness
        public double? AssetsToLiabilitiesFitness(CompanyDataPoco dataPoco)
        {
            var analysis = new StockAnalysis(dataPoco);
            var assetsToLiabilities = analysis.AssetsToLiabilities;
            double assetsToLiabilitiesFitness = 0;
            
            var bo = new DataBaseBusinessObject();
            var balanceSheet = bo.GetBalanceSheets();
           
         
        
        }
        #endregion

    }
}
