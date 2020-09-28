using Recodme.Labs.MarketAnalyzer.Analysis.Support;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.Analysis
{
    public class FutureGrowth
    {
        private readonly CompanyDataAccessObject _dao;

        public FutureGrowth()
        {
            this._dao = new CompanyDataAccessObject();
        }

        public CompanyGrowthPrediction GetFutureValues(Guid companyId)
        {
            var companyInfo = _dao.GetCompanyInfo(companyId);


            var valuesList = new List<ExtractedValue>();
            var valuesFiveYearsList = new List<ExtractedValue>();
            var valuesThreeYearsList = new List<ExtractedValue>();

            var incomeStatements = companyInfo.IncomeStatements.OrderBy(x => x.Year);
            var cashFlowStatements = companyInfo.CashFlowStatements.OrderBy(x => x.Year);
            var balanceSheets = companyInfo.BalanceSheets.OrderBy(x => x.Year);
            var KeyRatios = companyInfo.KeyRatios.OrderBy(x => x.Year);

            //(Net Income -Dividends - Depreciation & Amortization) / (Shareholders' Equity + Long-Term Debt)

            foreach (var item in incomeStatements)
            {

                var values = new ExtractedValue();
                values.CompanyId = companyId;
                values.Year = item.Year;

                var netIncome = item.NetIncome;
                if (netIncome == null) netIncome = 0;

                var dividends = KeyRatios.Where(x => x.Year == item.Year).SingleOrDefault().DividendsPerShare;
                if (dividends == null) dividends = 0;

                var depreciationAndAmortization = cashFlowStatements.Where(x => x.Year == item.Year).SingleOrDefault().DepreciationAmortization;
                if (depreciationAndAmortization == null) depreciationAndAmortization = 0;

                var shareholdersEquity = balanceSheets.Where(x => x.Year == item.Year).SingleOrDefault().ShareholdersEquity;
                if (shareholdersEquity == null) shareholdersEquity = 0;

                var longTermDebt = balanceSheets.Where(x => x.Year == item.Year).SingleOrDefault().LongTermDebt;
                if (longTermDebt == null) longTermDebt = 0;

                var growthValue = (netIncome - (decimal)dividends - depreciationAndAmortization) / (shareholdersEquity + longTermDebt);
                values.Value = (double)growthValue;

                valuesList.Add(values);
                if (item.Year < incomeStatements.ToList()[(incomeStatements.ToList().Count - 5)].Year) valuesFiveYearsList.Add(values);
                if (item.Year < incomeStatements.ToList()[(incomeStatements.ToList().Count - 3)].Year) valuesThreeYearsList.Add(values);
            }

            var trendline = new Trendline();
            var other = new OtherTrendlines();
            var valuesTrendline = trendline.GetTrendline(valuesList);
            var slope = valuesTrendline.Slope;
            var intercept = valuesTrendline.Intercept;
            var estimatedValue = (DateTime.Now.Year + 1) * slope + intercept;

            var valuesTrendline5Years = trendline.GetTrendline(valuesFiveYearsList);
            var slope5Years = valuesTrendline.Slope;
            var intercept5Years = valuesTrendline.Intercept;
            var estimatedValue5Years = (DateTime.Now.Year + 1) * slope + intercept;

            var valuesTrendline3Years = trendline.GetTrendline(valuesThreeYearsList);
            var slope3Years = valuesTrendline.Slope;
            var intercept3Years = valuesTrendline.Intercept;
            var estimatedValue3Years = (DateTime.Now.Year + 1) * slope + intercept;


            var estimatedValues = new CompanyGrowthPrediction();
            estimatedValues.CompanyId = companyId;
            estimatedValues.Year = DateTime.Now.Year + 1;

            if (other.GetMinGrowthValue(valuesList, DateTime.Now.Year + 1) < other.GetMaxGrowthValue(valuesList, DateTime.Now.Year + 1))
            {
                estimatedValues.MinValue = other.GetMinGrowthValue(valuesList, DateTime.Now.Year + 1);
                estimatedValues.EspectedValue = estimatedValue;
                estimatedValues.MaxValue = other.GetMaxGrowthValue(valuesList, DateTime.Now.Year + 1);
            }
            else if (other.GetMinGrowthValue(valuesList, DateTime.Now.Year + 1) == other.GetMaxGrowthValue(valuesList, DateTime.Now.Year + 1))
            {
                estimatedValues.MinValue = estimatedValue - estimatedValue * 0.1;
                estimatedValues.EspectedValue = estimatedValue;
                estimatedValues.MaxValue = estimatedValue + estimatedValue * 0.1;
            }
            else
            {
                estimatedValues.MinValue = other.GetMaxGrowthValue(valuesList, DateTime.Now.Year + 1);
                estimatedValues.EspectedValue = estimatedValue;
                estimatedValues.MaxValue = other.GetMinGrowthValue(valuesList, DateTime.Now.Year + 1);
            }
            if (other.GetMinGrowthValue(valuesFiveYearsList, DateTime.Now.Year + 1) < other.GetMaxGrowthValue(valuesFiveYearsList, DateTime.Now.Year + 1))
            {
                estimatedValues.MinValueFiveYears = other.GetMinGrowthValue(valuesFiveYearsList, DateTime.Now.Year + 1);
                estimatedValues.EspectedValueFiveYears = estimatedValue5Years;
                estimatedValues.MaxValueFiveYears = other.GetMaxGrowthValue(valuesFiveYearsList, DateTime.Now.Year + 1);
            }
            else if (other.GetMinGrowthValue(valuesFiveYearsList, DateTime.Now.Year + 1) == other.GetMaxGrowthValue(valuesFiveYearsList, DateTime.Now.Year + 1))
            {
                estimatedValues.MinValueFiveYears = estimatedValue - estimatedValue * 0.1;
                estimatedValues.EspectedValueFiveYears = estimatedValue5Years;
                estimatedValues.MaxValueFiveYears = estimatedValue + estimatedValue * 0.1;
            }
            else
            {
                estimatedValues.MinValueFiveYears = other.GetMaxGrowthValue(valuesFiveYearsList, DateTime.Now.Year + 1);
                estimatedValues.EspectedValueFiveYears = estimatedValue5Years;
                estimatedValues.MaxValueFiveYears = other.GetMinGrowthValue(valuesFiveYearsList, DateTime.Now.Year + 1);
            }
            if (other.GetMinGrowthValue(valuesThreeYearsList, DateTime.Now.Year + 1) < other.GetMaxGrowthValue(valuesThreeYearsList, DateTime.Now.Year + 1))
            {
                estimatedValues.MinValueThreeYears = other.GetMinGrowthValue(valuesThreeYearsList, DateTime.Now.Year + 1);
                estimatedValues.EspectedValueThreeYears = estimatedValue3Years;
                estimatedValues.MaxValueThreeYears = other.GetMaxGrowthValue(valuesThreeYearsList, DateTime.Now.Year + 1);
            }
            else if (other.GetMinGrowthValue(valuesThreeYearsList, DateTime.Now.Year + 1) == other.GetMaxGrowthValue(valuesThreeYearsList, DateTime.Now.Year + 1))
            {
                estimatedValues.MinValueThreeYears = estimatedValue - estimatedValue * 0.1;
                estimatedValues.EspectedValueThreeYears = estimatedValue3Years;
                estimatedValues.MaxValueThreeYears = estimatedValue + estimatedValue * 0.1;
            }
            else
            {
                estimatedValues.MinValueThreeYears = other.GetMaxGrowthValue(valuesThreeYearsList, DateTime.Now.Year + 1);
                estimatedValues.EspectedValueThreeYears = estimatedValue3Years;
                estimatedValues.MaxValueThreeYears = other.GetMinGrowthValue(valuesThreeYearsList, DateTime.Now.Year + 1);
            }


            return estimatedValues;

        }
    }
}
