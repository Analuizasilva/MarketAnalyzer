using Recodme.Labs.MarketAnalyzer.Analysis.Support;
using Recodme.Labs.MarketAnalyzer.DataLayer.Pocos;

namespace Recodme.Labs.MarketAnalyzer.Analysis
{
    public class StockFitness
    {

        //        Viabilidade de cada empresa

        //fitness do roic, equity Growth, EPS Growth, Revenue Growth, PE Ratio, Debt to Equity, Assets to Liabilities
        //um somatório dos valores e dar um valor total da viabilidade a cada empresa.

        //O sistema deve conseguir atribuir um peso decidido pelo utilizador a cada atributo.

        public double? RoicFitness { get; set; }
        public double? EquityFitness { get; set; }
        public double? EPSFitness { get; set; }
        public double? RevenueFitness { get; set; }
        public double? PERatioFitness { get; set; }
        public double? DebtToEquityFitness { get; set; }
        public double? AssetsToLiabilitiesFitness { get; set; }
        public double? TotalFitness { get; set; }
        public double WeightNumberRoic { get; set; } = 2;
        public double WeightNumberEquity { get; set; } = 1.7;
        public double WeightNumberEPS { get; set; } = 1.5;
        public double WeightNumberRevenue { get; set; } = 1.3;
        public double WeightNumberPERatio { get; set; } = 2;
        public double WeightNumberDebtToEquity { get; set; } = 0.8;
        public double WeightNumberAssetsToLiabilities { get; set; } = 0.8;

        public StockFitness() { }
        public StockFitness(StockAnalysis stockAnalysis)
        {
            var fitnessCalculus = new FitnessCalculus();

            var roicFitness = fitnessCalculus.GetRoicFitness(stockAnalysis.RoicSlopeInfo);

            var equityFitness = fitnessCalculus.GetGrowthFitness(stockAnalysis.EquitySlopeInfo);

            var ePSFitness = fitnessCalculus.GetGrowthFitness(stockAnalysis.EPSSlopeInfo);

            var revenueFitness = fitnessCalculus.GetGrowthFitness(stockAnalysis.RevenueSlopeInfo);

            var pERatioFitness = fitnessCalculus.GetPERatioFitness(stockAnalysis.PriceToEarningsSlopeInfo);

            var debtToEquityFitness = fitnessCalculus.GetDebtToEquityFitness(stockAnalysis.DebtToEquity);

            var assetsToLiabilitiesFitness = fitnessCalculus.GetAssetsToLiabilitiesFitness(stockAnalysis.AssetsToLiabilities);

            PERatioFitness = pERatioFitness;
            RevenueFitness = revenueFitness;
            EPSFitness = ePSFitness;
            RoicFitness = roicFitness;
            EquityFitness = equityFitness;
            AssetsToLiabilitiesFitness = assetsToLiabilitiesFitness;
            DebtToEquityFitness = debtToEquityFitness;
            TotalFitness = pERatioFitness * WeightNumberPERatio + revenueFitness * WeightNumberRevenue + ePSFitness * WeightNumberEPS + roicFitness * WeightNumberRoic + equityFitness * WeightNumberEquity + assetsToLiabilitiesFitness * WeightNumberAssetsToLiabilities + debtToEquityFitness * WeightNumberDebtToEquity;        
                
        }
    }
}
