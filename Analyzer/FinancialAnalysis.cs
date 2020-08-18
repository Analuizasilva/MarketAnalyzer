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

        public List<ExtractedValue> GetPriceToEarnings()
        {
            var dataAccessO = new BaseDataAccessObject<ExtractedKeyRatio>();
            var keyRatios = dataAccessO.GetDataBaseKeyRatios();

            var extractedValues = new List<ExtractedValue>();
            foreach (var item in keyRatios)
            {
                var extractedValue = new ExtractedValue();
                extractedValue.Year = item.Year;
                extractedValue.Value = item.PriceToEarnings;
                extractedValue.CompanyId = item.CompanyId;
                extractedValues.Add(extractedValue);
            }
            return extractedValues;
        }

        public List<ExtractedValue> GetEquity()
        {
            var dataAccessO = new BaseDataAccessObject<ExtractedBalanceSheet>();
            var balanceSheets = dataAccessO.GetDataBaseBalanceSheet();
            var extractedValues = new List<ExtractedValue>();
            foreach (var item in balanceSheets)
            {
                var extractedValue = new ExtractedValue();
                extractedValue.Year = item.Year;
                extractedValue.Value = (double?)(item.TotalAssets - item.TotalLiabilities);
                extractedValue.CompanyId = item.CompanyId;
                extractedValues.Add(extractedValue);
            }
            return extractedValues;
        }

        public List<ExtractedValue> GetMarketCap()
        {
            var dataAccessO = new BaseDataAccessObject<ExtractedKeyRatio>();
            var keyRatios = dataAccessO.GetDataBaseKeyRatios();

            var extractedValues = new List<ExtractedValue>();
            foreach (var item in keyRatios)
            {
                var extractedValue = new ExtractedValue();
                extractedValue.Year = item.Year;
                extractedValue.Value = (double?)item.MarketCapitalization;
                extractedValue.CompanyId = item.CompanyId;
                extractedValues.Add(extractedValue);
            }
            return extractedValues;
        }

        public List<ExtractedValue> GetRevenue()
        {
            var dataAccessO = new BaseDataAccessObject<ExtractedIncomeStatement>();
            var extractedIncomeStatements = dataAccessO.GetDataBaseIncomeStatement();
            var extractedValues = new List<ExtractedValue>();
            foreach (var item in extractedIncomeStatements)
            {
                var extractedValue = new ExtractedValue();
                extractedValue.Year = item.Year;
                extractedValue.Value = (double)item.Revenue;
                extractedValue.CompanyId = item.CompanyId;
                extractedValues.Add(extractedValue);
            }
            return extractedValues;
        }

        public List<ExtractedValue> GetEPS()
        {
            var dataAccessO = new BaseDataAccessObject<ExtractedIncomeStatement>();
            var incomeStatement = dataAccessO.GetDataBaseIncomeStatement();
            var extractedValues = new List<ExtractedValue>();
            foreach (var item in incomeStatement)
            {
                var extractedValue = new ExtractedValue();
                extractedValue.Year = item.Year;
                extractedValue.Value = (double?)item.EpsBasic;
                extractedValue.CompanyId = item.CompanyId;
                extractedValues.Add(extractedValue);
            }
            return extractedValues;
        }

        public List<ExtractedValue> GetDividends()
        {
            var dataAccessO = new BaseDataAccessObject<ExtractedKeyRatio>();
            var keyRatios = dataAccessO.GetDataBaseKeyRatios();

            var extractedValues = new List<ExtractedValue>();
            foreach (var item in keyRatios)
            {
                var extractedValue = new ExtractedValue();
                extractedValue.Year = item.Year;
                extractedValue.Value = item.DividendsPerShare;
                extractedValue.CompanyId = item.CompanyId;
                extractedValues.Add(extractedValue);
            }
            return extractedValues;
        }
    }
}
