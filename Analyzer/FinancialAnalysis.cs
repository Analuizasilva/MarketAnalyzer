using Recodme.Labs.MarketAnalyzer.Analysis.Support;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer.Base;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.Analysis
{
   public class FinancialAnalysis
    {
        public List<ExtractedValue> GetRoic()
        {
            var dataAccessO = new BaseDataAccessObject<ExtractedKeyRatio>();
            var keyRatios = dataAccessO.GetDataBaseKeyRatios();
            
            var extractedValues = new List<ExtractedValue>();
            foreach (var item in keyRatios)
            {
                var extractedValue = new ExtractedValue();
                extractedValue.Year = item.Year;
                extractedValue.Value = item.ReturnOnInvestedCapital;
                extractedValue.CompanyId = item.CompanyId;
                extractedValues.Add(extractedValue);
            }
            return extractedValues;
        }




    }
}
