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
        #region Roic
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
        #endregion

        #region PriceToEarnings
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
        #endregion

        #region Equity
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
        #endregion

        #region MarketCap
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
        #endregion

        #region Revenue
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
        #endregion

        #region EPS
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
        #endregion

        #region Dividends
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
        #endregion

        #region AssetsToLiabilities
        public double? GetAssetsToLiabilities(CompanyDataPoco dataPoco)
        {
            var extractedValues = new List<ExtractedValue>();
            var balanceSheets = dataPoco.BalanceSheets;
            var orderedBalanceSheets = new List<ExtractedBalanceSheet>();
            orderedBalanceSheets = balanceSheets.OrderBy(x => x.Year).ToList();

            var lastYearBalanceSheet = orderedBalanceSheets.LastOrDefault();
            var extractedValue = new ExtractedValue();

            var totalAssets = (double?)lastYearBalanceSheet.TotalAssets;
            var totalLiabelities = (double?)lastYearBalanceSheet.TotalLiabilities;

            double? assetsToLiabilities = 0;
            if (totalAssets != 0)
            {
                assetsToLiabilities = totalLiabelities / totalAssets;
            }

            var result = extractedValue.Value = assetsToLiabilities;
            extractedValue.Year = lastYearBalanceSheet.Year;
            extractedValue.CompanyId = lastYearBalanceSheet.CompanyId;

            return result;
        }
        #endregion

        #region DebtToEquity
        public double? GetDebtToEquity(CompanyDataPoco dataPoco)
        {
            var extractedValues = new List<ExtractedValue>();
            var balanceSheets = dataPoco.BalanceSheets;
            var orderedBalanceSheets = new List<ExtractedBalanceSheet>();
            orderedBalanceSheets = balanceSheets.OrderBy(x => x.Year).ToList();       

            var lastYearBalanceSheet = orderedBalanceSheets.LastOrDefault();
            var extractedValue = new ExtractedValue();

            var totalLiabilities = lastYearBalanceSheet.TotalLiabilities;
            var shareholdersEquity = lastYearBalanceSheet.ShareholdersEquity;
            decimal? debtToEquity = 0;

            if (shareholdersEquity != 0)
            {
                debtToEquity = totalLiabilities / shareholdersEquity;
            }

            var result = extractedValue.Value = (double?)debtToEquity;
            extractedValue.CompanyId = lastYearBalanceSheet.Id;
            extractedValue.Year = lastYearBalanceSheet.Year;

            return result;
        }
        #endregion

        #region StockPrice
        public ExtractedValue GetStockPrice(CompanyDataPoco dataPoco)
        {            
            var company = dataPoco.Company;
            var extractedValue = new ExtractedValue();
            extractedValue.Value = (double)company.StockPrice;
            extractedValue.CompanyId = company.Id;
            extractedValue.Year = DateTime.Now.Year;

            return extractedValue;
        }
        #endregion
    }
}
