using Recodme.Labs.MarketAnalyzer.DataLayer.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Recodme.Labs.MarketAnalyzer.Analysis.Support
{
    public class FitnessCalculus
    {
        #region RoicFitness
        public double? GetRoicFitness(SlopeInfo slopeInfo)
        {
            if (slopeInfo.NominalValues == null) return 0;
            var slope = slopeInfo.GrowthTrendline.Slope;
            var deviation = slopeInfo.GrowthDeviation;
            double? fitnessValueDeviation = 0;
            double? fitnessSlopeValue = 0;
            double? fitnessSlopeThreeYears = 0;

            #region All values bigger than 10%
            double? fitnessNominalValue = 0;
            double? count = 0;
            var values = slopeInfo.NominalValues;
            foreach (var item in values)
            {
                if (item.Value >= 0.1) fitnessNominalValue = 3;

                if (item.Value >= 0 && item.Value < 0.1) fitnessNominalValue = 1.5;

                else if (item.Value < 0) fitnessNominalValue = 0;

                count += fitnessNominalValue;
            }

            fitnessNominalValue = count / values.Count;
            #endregion

            #region Small deviation
            if (deviation <= 0.15) fitnessValueDeviation = 3;
            if (deviation > 0.15 && deviation < 0.3) fitnessValueDeviation = 1.5;
            else if (deviation >= 0.3) fitnessValueDeviation = 0;
            #endregion

            #region Slope 
            if (slope >= 0.1) fitnessSlopeValue = 3;
            if (slope >= 0 && slope < 0.1) fitnessSlopeValue = 1.5;
            else if (slope < 0) fitnessSlopeValue = 0;
            #endregion

            #region Slope last 3 years
            var lastThreeYearsGrowthSlope = slopeInfo.LastThreeYearsTrendLine.Slope;
            if (lastThreeYearsGrowthSlope >= 0.1) fitnessSlopeThreeYears = 3;
            if (lastThreeYearsGrowthSlope >= 0 && lastThreeYearsGrowthSlope < 0.1) fitnessSlopeThreeYears = 1.5;
            else if (lastThreeYearsGrowthSlope < 0) fitnessSlopeThreeYears = 0;
            #endregion

            var fitness = (fitnessSlopeThreeYears + fitnessSlopeValue + fitnessValueDeviation + fitnessNominalValue) / 12;
            return fitness;
        }
        #endregion

        #region Equity, EPS, Revenue Fitness
        public double? GetGrowthFitness(SlopeInfo slopeInfo)
        {
            if (slopeInfo.Growth == null) return 0;
            var slope = slopeInfo.GrowthTrendline.Slope;
            double? fitnessSlopeValue = 0;
            double? fitnessSlopeThreeYears = 0;

            #region All values bigger than 10%
            double? fitnessBiggerThanTen = 0;
            double? count = 0;
            var growthValues = slopeInfo.Growth;
            foreach (var item in growthValues)
            {
                if (item.Value >= 0.1) fitnessBiggerThanTen = 3;

                if (item.Value >= 0 && item.Value < 0.1) fitnessBiggerThanTen = 1.5;

                else if (item.Value < 0) fitnessBiggerThanTen = 0;

                count += fitnessBiggerThanTen;
            }

            fitnessBiggerThanTen = count / growthValues.Count;
            #endregion

            #region Slope 
            if (slope >= 0.1) fitnessSlopeValue = 3;
            if (slope >= 0 && slope < 0.1) fitnessSlopeValue = 1.5;
            else if (slope < 0) fitnessSlopeValue = 0;
            #endregion

            #region Slope last 3 years
            var lastThreeYearsGrowthSlope = slopeInfo.LastThreeYearsTrendLine.Slope;
            if (lastThreeYearsGrowthSlope >= 0.1) fitnessSlopeThreeYears = 3;
            if (lastThreeYearsGrowthSlope >= 0 && lastThreeYearsGrowthSlope < 0.1) fitnessSlopeThreeYears = 1.5;
            else if (lastThreeYearsGrowthSlope < 0) fitnessSlopeThreeYears = 0;
            #endregion

            var fitness = (fitnessSlopeThreeYears + fitnessSlopeValue + fitnessBiggerThanTen) / 9;
            return fitness;
        }
        #endregion

        #region PERatioFitness
        public double? GetPERatioFitness(SlopeInfo slopeInfo)
        {
            double? peRatioFitness = 0;
            var peValues = slopeInfo.NominalValues;

            if (peValues == null) return peRatioFitness;

            if (peValues.Any(x => x.Value == null)) return peRatioFitness;
            if (peValues.Any(x => x.Value < 0)) return peRatioFitness;
            double? count = 0;

            foreach (var item in peValues)
            {
                if (item.Value <= 0.15) peRatioFitness = 3;
                if (item.Value > 0.15 && item.Value < 0.3) peRatioFitness = 1.5;
                if (item.Value > 0.3 && item.Value < 0.6) peRatioFitness = 0.7;
                else if (item.Value >= 0.3) peRatioFitness = 0;
                count += peRatioFitness;
            }
            peRatioFitness = count / peValues.Count;

            return peRatioFitness;
        }
        #endregion

        #region DebtToEquityFitness
        public double? GetDebtToEquityFitness(double? value)
        {
            double? debtToEquityRatioFitness = 0;

            if (value == null) return debtToEquityRatioFitness;
            if (value < 0) debtToEquityRatioFitness = 0;
            if (value > 0 && value < 2) debtToEquityRatioFitness = 3;
            if (value > 2 && value < 10) debtToEquityRatioFitness = 1.5;
            else if (value >= 10) debtToEquityRatioFitness = 0;

            return debtToEquityRatioFitness / 3;
        }
        #endregion

        #region AssetsToLiabilitiesFitness
        public double? GetAssetsToLiabilitiesFitness(double? value)
        {
            double? assetsToLiabilitiesFitness = 0;
            if (value == null) return assetsToLiabilitiesFitness;
            if (value >= 0 && value < 1) assetsToLiabilitiesFitness = 0;
            if (value  >=1 && value < 2) assetsToLiabilitiesFitness = 0.25;
            if (value  >=2 && value < 3) assetsToLiabilitiesFitness = 0.75;
            if (value  >=3) assetsToLiabilitiesFitness = 1;
            return assetsToLiabilitiesFitness;
        }
        
        #endregion

    }
}
