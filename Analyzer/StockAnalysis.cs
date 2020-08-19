using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.Analysis
{
    public class StockAnalysis
    {
        //vai receber como parâmetro toda a informação da bd necessária e referente a uma company
        //company, Incomestatements, balancesheets, etc

        //public Company...
        //public List<Income....

        //public SlopeInfo RoicSlopeInfo ...


        public StockAnalysis(/*parametros*/)
        {
            //vai atribuir as props
            //RoicSlopeInf = new RoicSlopeInfo(FinancialAnalysis.ExtractRoic(KeyRatios));

        }
        
        //vai ter várias públicas propriedades cada uma referente ao que se pretende analisar, i.e. SlopeInfos
        //vai ter também informação sobre as restantes informações de análise da empresa, como debttoequity
    }
}
