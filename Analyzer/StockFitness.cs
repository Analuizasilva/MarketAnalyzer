using Recodme.Labs.MarketAnalyzer.DataLayer.Pocos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.Analysis
{
    public class StockFitness
    {

        /* Viabilidade de cada empresa
fitness do roic, equity Growth, EPS Growth, Revenue Growth, PE Ratio, Debt to Equity, Assets to Liabilities
um somatório dos valores e dar um valor total da viabilidade a cada empresa.

O sistema deve conseguir atribuir um peso decidido pelo utilizador a cada atributo.

*/

        public double? RoicFitness { get; set; }
        public double? EquityFitness { get; set; }
        public double? EPSFitness { get; set; }
        public double? RevenueFitness { get; set; }
        public double? PERatioFitness { get; set; }
        public double? DebtToEquityFitness { get; set; }
        public double? AssetsToLiabilitiesFitness { get; set; }
        public double? TotalFitness { get; set; }
        public double WeightNumber { get; set; }


        public StockFitness(CompanyDataPoco dataPoco)
        {
            var analysis = new StockAnalysis(dataPoco);
            #region RoicFitness
            var roicSlope = analysis.RoicSlopeInfo.GrowthTrendline.Slope;
            var roicDeviation = analysis.RoicSlopeInfo.GrowthDeviation;
            var ratio = Math.Abs((double)(roicDeviation / roicSlope));
            double? roicFitness = 0;
            if (ratio >= 1) roicFitness = 1 / ratio;
            else roicFitness = 1;
            #endregion

            double equityFitness = 0;
            var equityAbsSlope = analysis.EquitySlopeInfo.GrowthTrendline.Slope;
            if (equityAbsSlope < 0) equityFitness = 0;
            else if(equityAbsSlope<1) equityFitness =0.5;
            else equityFitness = 1-1/equityAbsSlope;

            var ePSSlope = analysis.EPSSlopeInfo.GrowthTrendline.Slope;
            var revenueSlope = analysis.RevenueSlopeInfo.GrowthTrendline.Slope;

            var peRatio = analysis.PERatio;

            var debtToEquity = analysis.DebtToEquity;

            var assetsToLiabilities = analysis.AssetsToLiabilities;

            RoicFitness = roicFitness;
            EquityFitness = analysis.Equity;

        }
    }
}
