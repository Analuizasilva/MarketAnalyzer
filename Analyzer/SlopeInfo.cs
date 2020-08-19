using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.Analysis
{
    public class SlopeInfo
    {
        //o que um slopeInfo recebe como parâmetro é a lista de extractedValues

        public void CalculateEquityGrowth()
        {
            var financialAnalysis = new FinancialAnalysis();
            var extractedEquity = financialAnalysis.GetEquity();

        }


    }
}
