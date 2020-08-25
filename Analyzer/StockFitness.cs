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
        public double WeightNumber { get; set; }

        //public StockFitness(CompanyDataPoco dataPoco)
        //{
        //    var fitnessCalculus = new FitnessCalculus();

        //    var roicFitness = fitnessCalculus.GetRoicFitness(dataPoco);

        //    var equityFitness = fitnessCalculus.GetEquityFitness(dataPoco);

        //var ePSFitness = fitnessCalculus.GetEPSFitness(dataPoco);

        //var revenueFitness = fitnessCalculus.GetRevenueFitness(dataPoco);

        //var pERatioFitness = fitnessCalculus.GetPERatioFitness(dataPoco);

        //var debtToEquityFitness = fitnessCalculus.GetDebtToEquityFitness(dataPoco);

        //var assetsToLiabilitiesFitness = fitnessCalculus.GetAssetsToLiabilitiesFitness(dataPoco);

        //AssetsToLiabilitiesFitness = assetsToLiabilitiesFitness;
        //DebtToEquityFitness = debtToEquityFitness;
        //PERatioFitness = pERatioFitness;
        //RevenueFitness = revenueFitness;
        //EPSFitness = ePSFitness;
        //    RoicFitness = roicFitness;
        //    EquityFitness = equityFitness;
        //}
    }
}
