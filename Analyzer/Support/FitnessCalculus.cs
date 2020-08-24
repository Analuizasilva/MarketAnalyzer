using Recodme.Labs.MarketAnalyzer.DataLayer.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recodme.Labs.MarketAnalyzer.Analysis.Support
{
    public class FitnessCalculus
    {
        #region RoicFitness
        public double? GetRoicFitness(SlopeInfo slopeInfo)
        {
            if (slopeInfo.NominalValues == null) return 0;
            var roicValues = slopeInfo.NominalValues;
            double? fitnessNominalValue = 0;
            var slope = slopeInfo.GrowthTrendline.Slope;
            var deviation = slopeInfo.GrowthDeviation;
            double? fitnessValueDeviation=0;
            double? fitnessSlopeValue=0;
            double? fitnessSlopeThreeYears=0;

            #region All values bigger than 10%
            double? count = 0;
            foreach (var item in roicValues)
            {
                if (item.Value >= 0.1) fitnessNominalValue = 3;

                if (item.Value >= 0 && item.Value < 0.1) fitnessNominalValue = 1.5;

                else if (item.Value < 0) fitnessNominalValue = 0;

                count += fitnessNominalValue;

            }
            fitnessNominalValue = count / roicValues.Count;
            #endregion

            #region Small deviation
            if (deviation <= 0.15) fitnessValueDeviation = 3;
            if (deviation > 0.15 && deviation < 0.3) fitnessValueDeviation = 1.5;
            else if(deviation>=0.3) fitnessValueDeviation = 0;
            #endregion

            #region Slope 
            if (slope >= 0.1) fitnessSlopeValue = 3;
            if (slope >= 0 && slope < 0.1) fitnessSlopeValue = 1.5;
            else if (slope<0) fitnessSlopeValue = 0;
            #endregion

            #region Slope last 3 years
            var lastThreeYearsGrowthSlope = slopeInfo.LastThreeYearsTrendLine.Slope;
            if (lastThreeYearsGrowthSlope >= 0.1) fitnessSlopeThreeYears = 3;
            if (lastThreeYearsGrowthSlope >= 0 && lastThreeYearsGrowthSlope < 0.1) fitnessSlopeThreeYears = 1.5;
            else if(lastThreeYearsGrowthSlope<0) fitnessSlopeThreeYears = 0;
            #endregion

            var fitness = (fitnessSlopeThreeYears + fitnessSlopeValue + fitnessValueDeviation + fitnessNominalValue) / 12;
            return fitness;
        }
        #endregion

        //#region EquityFitness
        //public double EquityFitness(CompanyDataPoco dataPoco)
        //{
        //    var analysis = new StockAnalysis(dataPoco);
        //    double equityFitness;
        //    var equityAbsSlope = analysis.EquitySlopeInfo.GrowthTrendline.Slope;
        //    if (equityAbsSlope < 0) equityFitness = 0;
        //    else if (equityAbsSlope < 1) equityFitness = 0.5;
        //    else equityFitness = 1 - 1 / equityAbsSlope;

        //    return equityFitness;
        //}
        //#endregion

        //#region EPSFitness
        //public double? EPSFitness(CompanyDataPoco dataPoco)
        //{
        //    var analysis = new StockAnalysis(dataPoco);
        //    double EPSFitness = 0;
        //    var ePSAbsSlope = analysis.EPSSlopeInfo.GrowthTrendline.Slope;
        //    if (ePSAbsSlope < 0) EPSFitness = 0;
        //    else if (ePSAbsSlope < 1) EPSFitness = 0.5;
        //    else EPSFitness = 1 - 1 / ePSAbsSlope;

        //    return EPSFitness;
        //}
        //#endregion

        //#region RevenueFitness
        //public double? RevenueFitness(CompanyDataPoco dataPoco)
        //{
        //    var analysis = new StockAnalysis(dataPoco);

        //    double revenueFitness = 0;
        //    var ePSAbsSlope = analysis.RevenueSlopeInfo.GrowthTrendline.Slope;
        //    if (ePSAbsSlope < 0) revenueFitness = 0;
        //    else if (ePSAbsSlope < 1) revenueFitness = 0.5;
        //    else revenueFitness = 1 - 1 / ePSAbsSlope;

        //    return revenueFitness;
        //}
        //#endregion

        //#region PERatioFitness
        //public double? PERatioFitness(CompanyDataPoco dataPoco)
        //{
        //    var analysis = new StockAnalysis(dataPoco);
        //    var peRatio = analysis.PERatio;
        //    double? peRatioFitness = 0;


        //    return peRatioFitness;
        //}
        //#endregion

        //#region DebtToEquityFitness
        //public double? DebtToEquityFitness(CompanyDataPoco dataPoco)
        //{
        //    var analysis = new StockAnalysis(dataPoco);
        //    var debtToEquity = analysis.DebtToEquity;
        //    double? debtToEquityFitness = 0;

        //    if (debtToEquity)


        //        return debtToEquityFitness;
        //}
        //#endregion

        //#region AssetsToLiabilitiesFitness
        //public double? AssetsToLiabilitiesFitness(CompanyDataPoco dataPoco)
        //{
        //    var analysis = new StockAnalysis(dataPoco);
        //    var assetsToLiabilities = analysis.AssetsToLiabilities;
        //    double assetsToLiabilitiesFitness = 0;


        //}
        //#endregion

    }
}
