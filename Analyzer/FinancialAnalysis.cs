using Recodme.Labs.MarketAnalyzer.Analysis.Support;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer.Base;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using System;
using System.Collections.Generic;

namespace Recodme.Labs.MarketAnalyzer.Analysis
{
    //qualquer um destes métodos recebe sempre como parâmetro a informação fiananceira da bd que precisa para extrair os dados
    public class FinancialAnalysis
    {
        public List<ExtractedValue> GetRoic(List<ExtractedKeyRatio> keyRatios)
        { 
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

        public List<ExtractedValue> GetPriceToEarnings(List<ExtractedKeyRatio> keyRatios)
        {
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

        public List<ExtractedValue> GetEquity(List<ExtractedBalanceSheet> balanceSheets)
        {
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

        public List<ExtractedValue> GetMarketCap(List<ExtractedKeyRatio> keyRatios)
        {
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

        public List<ExtractedValue> GetRevenue(List<ExtractedIncomeStatement> incomeStatements)
        {
            var extractedValues = new List<ExtractedValue>();

            foreach (var item in incomeStatements)
            {
                var extractedValue = new ExtractedValue();
                extractedValue.Year = item.Year;
                extractedValue.Value = (double?)item.Revenue;
                extractedValue.CompanyId = item.CompanyId;
                extractedValues.Add(extractedValue);
            }
            return extractedValues;
        }

        public List<ExtractedValue> GetEPS(List<ExtractedIncomeStatement> incomeStatements)
        {
            var extractedValues = new List<ExtractedValue>();

            foreach (var item in incomeStatements)
            {
                var extractedValue = new ExtractedValue();
                extractedValue.Year = item.Year;
                extractedValue.Value = (double?)item.EpsBasic;
                extractedValue.CompanyId = item.CompanyId;
                extractedValues.Add(extractedValue);
            }
            return extractedValues;
        }

        public List<ExtractedValue> GetDividends(List<ExtractedKeyRatio> keyRatios)
        {
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

        public List<ExtractedValue> GetAssetsToLiabilities(List<ExtractedBalanceSheet> balanceSheets)
        {
            var extractedValues = new List<ExtractedValue>();

            foreach (var item in balanceSheets)
            {
                var extractedValue = new ExtractedValue();

                var totalAssets = (double?)item.TotalAssets;
                var totalLiabelities = (double?)item.TotalLiabilities;

                double? assentsToLiabilities = 0;

                if (totalAssets != 0)
                {
                    assentsToLiabilities = totalLiabelities / totalAssets;
                }                

                extractedValue.Value = assentsToLiabilities;
                extractedValue.Year = item.Year;
                extractedValue.CompanyId = item.CompanyId;

                extractedValues.Add(extractedValue);
            }
            return extractedValues;
        }

        public List<ExtractedValue> DebtToEquity(List<ExtractedBalanceSheet> balanceSheets)
        {
            var extractedValues = new List<ExtractedValue>();

            foreach (var item in balanceSheets)
            {
                var extractedValue = new ExtractedValue();

                var totalLiabilities = item.TotalLiabilities;
                var shareholdersEquity = item.ShareholdersEquity;
                decimal? debtToEquity = 0;

                if (shareholdersEquity != 0)
                {
                    debtToEquity = totalLiabilities / shareholdersEquity;
                }                     

                extractedValue.Value = (double?)debtToEquity;
                extractedValue.CompanyId = item.Id;
                extractedValue.Year = item.Year;

                extractedValues.Add(extractedValue);
            }
            return extractedValues;
        }

        public List<ExtractedValue> GetStockPrice(List<Company> companies)
        {
            var extractedValues = new List<ExtractedValue>();

            foreach (var item in companies)
            {
                var extractedValue = new ExtractedValue();
                extractedValue.Year = DateTime.Now.Year;
                extractedValue.Value = (double)item.StockPrice;
                extractedValue.CompanyId = item.Id;
                extractedValue.Year = DateTime.Now.Year;
                extractedValues.Add(extractedValue);
            }
            return extractedValues;
        }

    }
}
