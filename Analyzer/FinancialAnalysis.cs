using Recodme.Labs.MarketAnalyzer.Analysis.Support;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recodme.Labs.MarketAnalyzer.Analysis
{
    public class FinancialAnalysis
    {
        //qualquer um destes métodos recebe sempre como parâmetro a informação fiananceira da bd que precisa para extrair os dados
        public List<ExtractedValue> GetRoic(CompanyDataPoco dataPoco)
        {
            var extractedValues = new List<ExtractedValue>();
            var keyRatios = dataPoco.KeyRatios;

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

        public List<ExtractedValue> GetPriceToEarnings(CompanyDataPoco dataPoco)
        {
            var extractedValues = new List<ExtractedValue>();
            var keyRatios = dataPoco.KeyRatios;

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

        public List<ExtractedValue> GetEquity(CompanyDataPoco dataPoco)
        {
            var extractedValues = new List<ExtractedValue>();
            var balanceSheets = dataPoco.BalanceSheets;

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

        public List<ExtractedValue> GetMarketCap(CompanyDataPoco dataPoco)
        {
            var extractedValues = new List<ExtractedValue>();
            var keyRatios = dataPoco.KeyRatios;

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

        public List<ExtractedValue> GetRevenue(CompanyDataPoco dataPoco)
        {
            var extractedValues = new List<ExtractedValue>();
            var incomeStatements = dataPoco.IncomeStatements;

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

        public List<ExtractedValue> GetEPS(CompanyDataPoco dataPoco)
        {
            var extractedValues = new List<ExtractedValue>();
            var incomeStatements = dataPoco.IncomeStatements;

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

        public List<ExtractedValue> GetDividends(CompanyDataPoco dataPoco)
        {
            var extractedValues = new List<ExtractedValue>();
            var keyRatios = dataPoco.KeyRatios;
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

        public List<ExtractedValue> GetAssetsToLiabilities(CompanyDataPoco dataPoco)
        {
            var extractedValues = new List<ExtractedValue>();
            var balanceSheets = dataPoco.BalanceSheets;

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

        public List<ExtractedValue> DebtToEquity(CompanyDataPoco dataPoco)
        {
            var extractedValues = new List<ExtractedValue>();
            var balanceSheets = dataPoco.BalanceSheets;

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

        public ExtractedValue GetStockPrice(CompanyDataPoco dataPoco)
        {
            var extractedValues = new List<ExtractedValue>();
            var company = dataPoco.Company;
            var extractedValue = new ExtractedValue();
            extractedValue.Value = (double)company.StockPrice;
            extractedValue.CompanyId = company.Id;
            extractedValue.Year = DateTime.Now.Year;
            return extractedValue;
        }

    }
}
