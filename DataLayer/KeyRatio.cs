using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.DataLayer
{
    public class KeyRatio:Entity
    {
        #region Year
        private int _year;
        [Required]
        public int Year
        {
            get => _year;
            set
            {
                _year = value;
                RegisterChange();
            }
        }
        #endregion

        #region Returns

        private float _returnOnAssets;
        [Display (Name = "Return On Assets")]
        public float ReturnOnAssets
        {
            get => _returnOnAssets;
            set
            {
                _returnOnAssets = value;
                RegisterChange();
            }
        }


        private float _returnOnEquity;
        [Display(Name = "Return On Equity")]
        public float ReturnOnEquity
        {
            get => _returnOnEquity;
            set
            {
                _returnOnEquity = value;
                RegisterChange();
            }
        }



        private float _returnOnInvestedCapital;
        [Display(Name = "Return On Invested Capital")]
        public float ReturnOnInvestedCapital
        {
            get => _returnOnInvestedCapital;
            set
            {
                _returnOnInvestedCapital = value;
                RegisterChange();
            }
        }

        private float _returnOnCapitalEmployed;
        [Display(Name = "Return On Capital Employed")]
        public float ReturnOnCapitalEmployed
        {
            get => _returnOnCapitalEmployed;
            set
            {
                _returnOnCapitalEmployed = value;
                RegisterChange();
            }
        }

        private float _returnOnTangibleCapitalEmployed;
        [Display(Name = "Return On Tangible Capital Employed")]
        public float ReturnOnTangibleCapitalEmployed
        {
            get => _returnOnTangibleCapitalEmployed;
            set
            {
                _returnOnTangibleCapitalEmployed = value;
                RegisterChange();
            }
        }



        #endregion

        #region Margins as percentage of Revenue
        private float _grossMargin;
        [Display(Name = "Gross Margin")]
        public float GrossMargin
        {
            get => _grossMargin;
            set
            {
                _grossMargin = value;
                RegisterChange();
            }
        }

        private float _eBITDAMargin;
        [Display(Name = "EBITDA Margin")]
        public float EBITDAMargin
        {
            get => _eBITDAMargin;
            set
            {
                _eBITDAMargin = value;
                RegisterChange();
            }
        }

        private float _operatingMargin;
        [Display(Name = "Operating Margin")]
        public float OperatingMargin
        {
            get => _operatingMargin;
            set
            {
                _operatingMargin = value;
                RegisterChange();
            }
        }

        private float _pretaxMargin;
        [Display(Name = "Pretax Margin")]
        public float PretaxMargin
        {
            get => _pretaxMargin;
            set
            {
                _pretaxMargin = value;
                RegisterChange();
            }
        }

        private float _netMargin;
        [Display(Name = "Net Margin")]
        public float NetMargin
        {
            get => _netMargin;
            set
            {
                _netMargin = value;
                RegisterChange();
            }
        }

        private float _freeCashMargin;
        [Display(Name = "Free Cash Margin")]
        public float FreeCashMargin
        {
            get => _freeCashMargin;
            set
            {
                _freeCashMargin = value;
                RegisterChange();
            }
        }



        #endregion

        #region Capital Structure

        private float _assetsToEquity;
        [Display(Name = "Assets To Equity")]
        public float AssetsToEquity
        {
            get => _assetsToEquity;
            set
            {
                _assetsToEquity = value;
                RegisterChange();
            }
        }

        private float _equityToAssets;
        [Display(Name = "Equity to Assets")]
        public float EquityToAssets
        {
            get => _equityToAssets;
            set
            {
                _equityToAssets = value;
                RegisterChange();
            }
        }

        private float _debtToEquity;
        [Display(Name = "Debt to Equity")]
        public float DebtToEquity
        {
            get => _debtToEquity;
            set
            {
                _debtToEquity = value;
                RegisterChange();
            }
        }

        private float _debtToAssets;
        [Display(Name = "Debt to Assets")]
        public float DebtToAssets
        {
            get => _debtToAssets;
            set
            {
                _debtToAssets = value;
                RegisterChange();
            }
        }

        #endregion

        #region Year-Over-Year Growth
        private float _revenue;
        public float Revenue
        {
            get => _revenue;
            set
            {
                _revenue = value;
                RegisterChange();
            }
        }

        private float _grossProfit;
        [Display(Name = "Gross Profit")]
        public float GrossProfit
        {
            get => _grossProfit;
            set
            {
                _grossProfit = value;
                RegisterChange();
            }
        }

        private float _eBITDA;
        public float EBITDA
        {
            get => _eBITDA;
            set
            {
                _eBITDA = value;
                RegisterChange();
            }
        }

        private float _operatingIncome;
        [Display(Name = "Operating Income")]
        public float OperatingIncome
        {
            get => _operatingIncome;
            set
            {
                _operatingIncome = value;
                RegisterChange();
            }
        }

        private float _pretaxIncome;
        [Display(Name = "Pretax Income")]
        public float PretaxIncome
        {
            get => _pretaxIncome;
            set
            {
                _pretaxIncome = value;
                RegisterChange();
            }
        }

        private float _netIncome;
        [Display(Name = "Net Income")]
        public float NetIncome
        {
            get => _netIncome;
            set
            {
                _netIncome = value;
                RegisterChange();
            }
        }

        private float _dilutedEPS;
        [Display(Name = "Diluted EPS")]
        public float DilutedEPS
        {
            get => _dilutedEPS;
            set
            {
                _dilutedEPS = value;
                RegisterChange();
            }
        }

        private float _dilutedShares;
        [Display(Name = "Diluted Shares")]
        public float DilutedShares
        {
            get => _dilutedShares;
            set
            {
                _dilutedShares = value;
                RegisterChange();
            }
        }

        private float _pPAndE;
        [Display(Name = "PP&E")]
        public float PPAndE
        {
            get => _pPAndE;
            set
            {
                _pPAndE = value;
                RegisterChange();
            }
        }

        private float _totalAssets;
        [Display(Name = "Total Assets")]
        public float TotalAssets
        {
            get => _totalAssets;
            set
            {
                _totalAssets = value;
                RegisterChange();
            }
        }

        private float _equity;
        public float Equity
        {
            get => _equity;
            set
            {
                _equity = value;
                RegisterChange();
            }
        }

        private float _cashFromOperations;
        [Display(Name = "Cash from Operations")]
        public float CashFromOperations
        {
            get => _cashFromOperations;
            set
            {
                _cashFromOperations = value;
                RegisterChange();
            }
        }

        private float _capitalExpenditures;
        [Display(Name = "Capital Expenditures")]
        public float CapitalExpenditures
        {
            get => _capitalExpenditures;
            set
            {
                _capitalExpenditures = value;
                RegisterChange();
            }
        }

        private float _freeCashFlowPercentage;
        [Display(Name = "Free Cash Flow %")]
        public float FreeCashFlowPercentage
        {
            get => _freeCashFlowPercentage;
            set
            {
                _freeCashFlowPercentage = value;
                RegisterChange();
            }
        }



        #endregion

        #region Supplementary Items

        private float _freeCashFlow;
        [Display(Name = "Free Cash Flow")]
        public float FreeCashFlow
        {
            get => _freeCashFlow;
            set
            {
                _freeCashFlow = value;
                RegisterChange();
            }
        }

        private float _bookValue;
        [Display(Name = "Book Value")]
        public float BookValue
        {
            get => _bookValue;
            set
            {
                _bookValue = value;
                RegisterChange();
            }
        }

        private float _tangibleBookValue;
        [Display(Name = "Tangible Book Value")]
        public float TangibleBookValue
        {
            get => _tangibleBookValue;
            set
            {
                _tangibleBookValue = value;
                RegisterChange();
            }
        }


        #endregion

        #region Per-Share Items

        private float _revenuePerShare;
        [Display(Name = "Revenue Per-Share")]
        public float RevenuePerShare
        {
            get => _revenuePerShare;
            set
            {
                _revenuePerShare = value;
                RegisterChange();
            }
        }

        private float _eBITDAPerShare;
        [Display(Name = "EBITDA Per-Share")]
        public float EBITDAPerShare
        {
            get => _eBITDAPerShare;
            set
            {
                _eBITDAPerShare = value;
                RegisterChange();
            }
        }

        private float _operatingIncomePerShare;
        [Display(Name = "Operating Income Per-Share")]
        public float OperatingIncomePerShare
        {
            get => _operatingIncomePerShare;
            set
            {
                _operatingIncomePerShare = value;
                RegisterChange();
            }
        }

        private float _freeCashFlowPerShare;
        [Display(Name = "Free Cash Flow Per-Share")]
        public float FreeCashFlowPerShare
        {
            get => _freeCashFlowPerShare;
            set
            {
                _freeCashFlowPerShare = value;
                RegisterChange();
            }
        }

        private float _bookValuePerShare;
        [Display(Name = "Book Value Per-Share")]
        public float BookValuePerShare
        {
            get => _bookValuePerShare;
            set
            {
                _bookValuePerShare = value;
                RegisterChange();
            }
        }

        private float _tangibleBookValuePerShare;
        [Display(Name = "Tangible Book Value Per-Share")]
        public float TangibleBookValuePerShare
        {
            get => _tangibleBookValuePerShare;
            set
            {
                _tangibleBookValuePerShare = value;
                RegisterChange();
            }
        }


        #endregion

        #region Valuation Metrics

        private float _marketCapitalization;
        [Display(Name = "Market Capitalization")]
        public float MarketCapitalization
        {
            get => _marketCapitalization;
            set
            {
                _marketCapitalization = value;
                RegisterChange();
            }
        }

        private float _priceToEarnings;
        [Display(Name = "Price-to-Earnings")]
        public float PriceToEarnings
        {
            get => _priceToEarnings;
            set
            {
                _priceToEarnings = value;
                RegisterChange();
            }
        }

        private float _priceToBook;
        [Display(Name = "Price-to-Book")]
        public float PriceToBook
        {
            get => _priceToBook;
            set
            {
                _priceToBook = value;
                RegisterChange();
            }
        }

        private float _priceToSales;
        [Display(Name = "Price-to-Sales")]
        public float PriceToSales
        {
            get => _priceToSales;
            set
            {
                _priceToSales = value;
                RegisterChange();
            }
        }


        #endregion

        #region Dividends
        private float _dividendsPerShare;
        [Display(Name = "Dividends per share")]
        public float DividendsPerShare
        {
            get => _dividendsPerShare;
            set
            {
                _dividendsPerShare = value;
                RegisterChange();
            }
        }

        private float _payoutRatio;
        [Display(Name = "Payout Ratio")]
        public float PayoutRatio
        {
            get => _payoutRatio;
            set
            {
                _payoutRatio = value;
                RegisterChange();
            }
        }



        #endregion


        #region Foreign Key

        [ForeignKey("Company")]
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }

        #endregion


        #region Construtores

        public KeyRatio()
        {

        }

        public KeyRatio(int year, float returnOnAssets, float returnOnEquity, float returnOnInvestedCapital, float returnOnCapitalEmployed, float returnOnTangibleCapitalEmployed, float grossMargin, float eBITDAMargin, float operatingMargin, float pretaxMargin, float netMargin, float freeCashMargin, float assetsToEquity, float equityToAssets, float debtToEquity, float debtToAssets, float revenue, float grossProfit, float eBITDA, float operatingIncome, float pretaxIncome, float netIncome, float dilutedEPS, float dilutedShares, float pPAndE, float totalAssets, float equity, float cashFromOperations, float capitalExpenditures, float freeCashFlowPercentage, float freeCashFlow, float bookValue, float tangibleBookValue, float revenuePerShare, float eBITDAPerShare, float operatingIncomePerShare, float freeCashFlowPerShare, float bookValuePerShare, float tangibleBookValuePerShare, float marketCapitalization, float priceToEarnings, float priceToBook, float priceToSales, float dividendsPerShare, float payoutRatio)
        {
            _year = year;
            _returnOnAssets = returnOnAssets;
            _returnOnEquity = returnOnEquity;
            _returnOnInvestedCapital = returnOnInvestedCapital;
            _returnOnCapitalEmployed = returnOnCapitalEmployed;
            _returnOnTangibleCapitalEmployed = returnOnTangibleCapitalEmployed;
            _grossMargin = grossMargin;
            _eBITDAMargin = eBITDAMargin;
            _operatingMargin = operatingMargin;
            _pretaxMargin = pretaxMargin;
            _netMargin = netMargin;
            _freeCashMargin = freeCashMargin;
            _assetsToEquity = assetsToEquity;
            _equityToAssets = equityToAssets;
            _debtToEquity = debtToEquity;
            _debtToAssets = debtToAssets;
            _revenue = revenue;
            _grossProfit = grossProfit;
            _eBITDA = eBITDA;
            _operatingIncome = operatingIncome;
            _pretaxIncome = pretaxIncome;
            _netIncome = netIncome;
            _dilutedEPS = dilutedEPS;
            _dilutedShares = dilutedShares;
            _pPAndE = pPAndE;
            _totalAssets = totalAssets;
            _equity = equity;
            _cashFromOperations = cashFromOperations;
            _capitalExpenditures = capitalExpenditures;
            _freeCashFlowPercentage = freeCashFlowPercentage;
            _freeCashFlow = freeCashFlow;
            _bookValue = bookValue;
            _tangibleBookValue = tangibleBookValue;
            _revenuePerShare = revenuePerShare;
            _eBITDAPerShare = eBITDAPerShare;
            _operatingIncomePerShare = operatingIncomePerShare;
            _freeCashFlowPerShare = freeCashFlowPerShare;
            _bookValuePerShare = bookValuePerShare;
            _tangibleBookValuePerShare = tangibleBookValuePerShare;
            _marketCapitalization = marketCapitalization;
            _priceToEarnings = priceToEarnings;
            _priceToBook = priceToBook;
            _priceToSales = priceToSales;
            _dividendsPerShare = dividendsPerShare;
            _payoutRatio = payoutRatio;

        }

        public KeyRatio(Guid id, DateTime createdAt, DateTime updatedAd, bool isDeleted, int year, float returnOnAssets, float returnOnEquity, float returnOnInvestedCapital, float returnOnCapitalEmployed, float returnOnTangibleCapitalEmployed, float grossMargin, float eBITDAMargin, float operatingMargin, float pretaxMargin, float netMargin, float freeCashMargin, float assetsToEquity, float equityToAssets, float debtToEquity, float debtToAssets, float revenue, float grossProfit, float eBITDA, float operatingIncome, float pretaxIncome, float netIncome, float dilutedEPS, float dilutedShares, float pPAndE, float totalAssets, float equity, float cashFromOperations, float capitalExpenditures, float freeCashFlowPercentage, float freeCashFlow, float bookValue, float tangibleBookValue, float revenuePerShare, float eBITDAPerShare, float operatingIncomePerShare, float freeCashFlowPerShare, float bookValuePerShare, float tangibleBookValuePerShare, float marketCapitalization, float priceToEarnings, float priceToBook, float priceToSales, float dividendsPerShare, float payoutRatio) :
            base(id, createdAt, updatedAd, isDeleted)
        {
            _year = year;
            _returnOnAssets = returnOnAssets;
            _returnOnEquity = returnOnEquity;
            _returnOnInvestedCapital = returnOnInvestedCapital;
            _returnOnCapitalEmployed = returnOnCapitalEmployed;
            _returnOnTangibleCapitalEmployed = returnOnTangibleCapitalEmployed;
            _grossMargin = grossMargin;
            _eBITDAMargin = eBITDAMargin;
            _operatingMargin = operatingMargin;
            _pretaxMargin = pretaxMargin;
            _netMargin = netMargin;
            _freeCashMargin = freeCashMargin;
            _assetsToEquity = assetsToEquity;
            _equityToAssets = equityToAssets;
            _debtToEquity = debtToEquity;
            _debtToAssets = debtToAssets;
            _revenue = revenue;
            _grossProfit = grossProfit;
            _eBITDA = eBITDA;
            _operatingIncome = operatingIncome;
            _pretaxIncome = pretaxIncome;
            _netIncome = netIncome;
            _dilutedEPS = dilutedEPS;
            _dilutedShares = dilutedShares;
            _pPAndE = pPAndE;
            _totalAssets = totalAssets;
            _equity = equity;
            _cashFromOperations = cashFromOperations;
            _capitalExpenditures = capitalExpenditures;
            _freeCashFlowPercentage = freeCashFlowPercentage;
            _freeCashFlow = freeCashFlow;
            _bookValue = bookValue;
            _tangibleBookValue = tangibleBookValue;
            _revenuePerShare = revenuePerShare;
            _eBITDAPerShare = eBITDAPerShare;
            _operatingIncomePerShare = operatingIncomePerShare;
            _freeCashFlowPerShare = freeCashFlowPerShare;
            _bookValuePerShare = bookValuePerShare;
            _tangibleBookValuePerShare = tangibleBookValuePerShare;
            _marketCapitalization = marketCapitalization;
            _priceToEarnings = priceToEarnings;
            _priceToBook = priceToBook;
            _priceToSales = priceToSales;
            _dividendsPerShare = dividendsPerShare;
            _payoutRatio = payoutRatio;
        }
        #endregion
    }
}
