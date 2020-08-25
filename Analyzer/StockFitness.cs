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
        public double WeightNumberRoic{ get; set; }
        public double WeightNumberEquity { get; set; }
        public double WeightNumberEPS { get; set; }
        public double WeightNumberRevenue { get; set; }
        public double WeightNumberPERatio { get; set; }
        public double WeightNumberDebtToEquity { get; set; }
        public double WeightNumberAssetsToLiabilities { get; set; }

        public StockFitness() { }
        public StockFitness(SlopeInfo slopeInfo)
        {
            var fitnessCalculus = new FitnessCalculus();

            var roicFitness = fitnessCalculus.GetRoicFitness(slopeInfo);

            var equityFitness = fitnessCalculus.GetGrowthFitness(slopeInfo);

            var ePSFitness = fitnessCalculus.GetGrowthFitness(slopeInfo);

            var revenueFitness = fitnessCalculus.GetGrowthFitness(slopeInfo);

            var pERatioFitness = fitnessCalculus.GetPERatioFitness(slopeInfo);
            
            PERatioFitness = pERatioFitness;
            RevenueFitness = revenueFitness;
            EPSFitness = ePSFitness;
            RoicFitness = roicFitness;
            EquityFitness = equityFitness;
        }
        public StockFitness(double? value)
        {
            var fitnessCalculus = new FitnessCalculus();
            var debtToEquityFitness = fitnessCalculus.GetDebtToEquityFitness(value);

            var assetsToLiabilitiesFitness = fitnessCalculus.GetAssetsToLiabilitiesFitness(value);

            AssetsToLiabilitiesFitness = assetsToLiabilitiesFitness;
            DebtToEquityFitness = debtToEquityFitness;
        }
        
    }
}
