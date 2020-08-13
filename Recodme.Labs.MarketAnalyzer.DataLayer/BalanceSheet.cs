using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recodme.Labs.MarketAnalyzer.DataLayer
{
    public class BalanceSheet : Entity
    {
        private Guid companyId;
        [ForeignKey("Company")]
        public Guid CompanyId
        {
            get => companyId;
            set
            {
                companyId = value;
                RegisterChange();
            }
        }

        public Company Company { get; set; }

        private int _year;
        [Display(Name = "Year")]
        public int Year
        {
            get => _year;
            set
            {
                _year = value;
                RegisterChange();
            }
        }

        #region Assets
        private float _cashEquivalents;
        [Display(Name = "Cash & Equivalents")]
        public float CashEquivalents
        {
            get => _cashEquivalents;
            set
            {
                _cashEquivalents = value;
                RegisterChange();
            }
        }

        private float _shortTermInvestments;
        [Display(Name = "Short-Term Investments")]
        public float ShortTermInvestments 
        {
            get => _shortTermInvestments;
            set
            {
                _shortTermInvestments = value;
                RegisterChange();
            }
        }

        private float _accountsReceivable;
        [Display(Name = "Accounts Receivable")]
        public float AccountsReceivable
        {
            get => _accountsReceivable;
            set
            {
                _accountsReceivable = value;
                RegisterChange();
            }
        }

        private float _inventories;
        [Display(Name = "Inventories")]
        public float Inventories
        {
            get => _inventories;
            set
            {
                _inventories = value;
                RegisterChange();
            }
        }

        private float _otherCurrentAssets;
        [Display(Name = "Other Current Assets")]
        public float OtherCurrentAssets
        {
            get => _otherCurrentAssets;
            set
            {
                _otherCurrentAssets = value;
                RegisterChange();
            }
        }

        private float _totalCurrentAssets;
        [Display(Name = "Total Current Assets")]
        public float TotalCurrentAssets
        {
            get => _totalCurrentAssets;
            set
            {
                _totalCurrentAssets = value;
                RegisterChange();
            }
        }

        private float _investiments;
        [Display(Name = "Investiments")]
        public float Investiments
        {
            get => _investiments;
            set
            {
                _investiments = value;
                RegisterChange();
            }
        }

        private float _propertyPlantAndEquipment;
        [Display(Name = "Property, Plant, & Equipment")]
        public float PropertyPlantAndEquipment
        {
            get => _propertyPlantAndEquipment;
            set
            {
                _propertyPlantAndEquipment = value;
                RegisterChange();
            }
        }

        private float _goodwill;
        [Display(Name = "Goodwill")]
        public float Goodwill
        {
            get => _goodwill;
            set
            {
                _goodwill = value;
                RegisterChange();
            }
        }

        private float _otherIntangibleAssets;
        [Display(Name = "Other Intangible Assets")]
        public float OtherIntangibleAssets
        {
            get => _otherIntangibleAssets;
            set
            {
                _otherIntangibleAssets = value;
                RegisterChange();
            }
        }

        private float _otherAssets;
        [Display(Name = "Other Assets")]
        public float OtherAssets
        {
            get => _otherAssets;
            set
            {
                _otherAssets = value;
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
        #endregion   

        #region Liabilities & Equity
        private float _accountsPayable;
        [Display(Name = "Accounts Payable")]
        public float AccountsPayable
        {
            get => _accountsPayable;
            set
            {
                _accountsPayable = value;
                RegisterChange();
            }
        }

        private float _taxPayable;
        [Display(Name = "Tax Payable")]
        public float TaxPayable
        {
            get => _taxPayable;
            set
            {
                _taxPayable = value;
                RegisterChange();
            }
        }

        private float _accruedLiabilities;
        [Display(Name = "Accrued Liabilities")]
        public float AccruedLiabilities
        {
            get => _accruedLiabilities;
            set
            {
                _accruedLiabilities = value;
                RegisterChange();
            }
        }

        private float _shortTermDebt;
        [Display(Name = "Short-Term Debt")]
        public float ShortTermDebt
        {
            get => _shortTermDebt;
            set
            {
                _shortTermDebt = value;
                RegisterChange();
            }
        }

        private float _currentDeferredRevenue;
        [Display(Name = "Current Deferred Revenue")]
        public float CurrentDeferredRevenue
        {
            get => _currentDeferredRevenue;
            set
            {
                _currentDeferredRevenue = value;
                RegisterChange();
            }
        }

        private float _otherCurrentLiabilities;
        [Display(Name = "Other Current Liabilities")]
        public float OtherCurrentLiabilities
        {
            get => _otherCurrentLiabilities;
            set
            {
                _otherCurrentLiabilities = value;
                RegisterChange();
            }
        }

        private float _totalCurrentLiabilities;
        [Display(Name = "Total Current Liabilities")]
        public float TotalCurrentLiabilities
        {
            get => _totalCurrentLiabilities;
            set
            {
                _totalCurrentLiabilities = value;
                RegisterChange();
            }
        }

        private float _longTermDebt;
        [Display(Name = "Long-Term Debt")]
        public float LongTermDebt
        {
            get => _longTermDebt;
            set
            {
                _longTermDebt = value;
                RegisterChange();
            }
        }

        private float _deferredRevenue;
        [Display(Name = "Total Deferred Revenue")]
        public float DeferredRevenue
        {
            get => _deferredRevenue;
            set
            {
                _deferredRevenue = value;
                RegisterChange();
            }
        }

        private float _otherLiabilities;
        [Display(Name = "Other Liabilities")]
        public float OtherLiabilities
        {
            get => _otherLiabilities;
            set
            {
                _otherLiabilities = value;
                RegisterChange();
            }
        }

        private float _totalLiabilities;
        [Display(Name = "Total Liabilities")]
        public float TotalLiabilities
        {
            get => _totalLiabilities;
            set
            {
                _totalLiabilities = value;
                RegisterChange();
            }
        }

        private float _retainedEarnings;
        [Display(Name = "Retained Earnings")]
        public float RetainedEarnings
        {
            get => _retainedEarnings;
            set
            {
                _retainedEarnings = value;
                RegisterChange();
            }
        }

        private float _paidInCapital;
        [Display(Name = "Paid In Capital")]
        public float PaidInCapital
        {
            get => _paidInCapital;
            set
            {
                _paidInCapital = value;
                RegisterChange();
            }
        }

        private float _commonStock;
        [Display(Name = "Common Stock")]
        public float CommonStock
        {
            get => _commonStock;
            set
            {
                _commonStock = value;
                RegisterChange();
            }
        }

        private float _aOCI;
        [Display(Name = "AOCI")]
        public float AOCI
        {
            get => _aOCI;
            set
            {
                _aOCI = value;
                RegisterChange();
            }
        }


        private float _shareholdersEquity;
        [Display(Name = "Shareholders' Equity")]
        public float ShareholdersEquity
        {
            get => _shareholdersEquity;
            set
            {
                _shareholdersEquity = value;
                RegisterChange();
            }
        }

        private float _liabilitiesAndEquity;
        [Display(Name = "Liabilities & Equity")]
        public float LiabilitiesAndEquity
        {
            get => _liabilitiesAndEquity;
            set
            {
                _liabilitiesAndEquity = value;
                RegisterChange();
            }
        }
        #endregion

        #region Constructors

        public BalanceSheet()
        {

        }

        public BalanceSheet(Guid companyId, Company company, int year, float cashEquivalents, float shortTermInvestments, float accountsReceivable, float inventories, float otherCurrentAssets, float totalCurrentAssets, float investiments,
          float propertyPlantAndEquipment, float goodwill, float otherIntangibleAssets, float otherAssets,
          float totalAssets, float accountsPayable, float taxPayable, float accruedLiabilities, float shortTermDebt,
          float currentDeferredRevenue, float otherCurrentLiabilities, float totalCurrentLiabilities, float longTermDebt,
          float deferredRevenue, float otherLiabilities, float totalLiabilities, float retainedEarnings,
          float paidInCapital, float commonStock, float aOCI, float shareholdersEquity,
          float liabilitiesAndEquity)
        {
            CompanyId = companyId;
            Company = company;
            _year = year;
            _cashEquivalents = cashEquivalents;
            _shortTermInvestments = shortTermInvestments;
            _accountsReceivable = accountsReceivable;
            _inventories = inventories;
            _otherCurrentAssets = otherCurrentAssets;
            _totalCurrentAssets = totalCurrentAssets;
            _investiments = investiments;
            _propertyPlantAndEquipment = propertyPlantAndEquipment;
            _goodwill = goodwill;
            _otherIntangibleAssets = otherIntangibleAssets;
            _otherAssets = otherAssets;
            _totalAssets = totalAssets;
            _accountsPayable = accountsPayable;
            _taxPayable = taxPayable;
            _accruedLiabilities = accruedLiabilities;
            _shortTermDebt = shortTermDebt;
            _currentDeferredRevenue = currentDeferredRevenue;
            _otherCurrentLiabilities = otherCurrentLiabilities;
            _totalCurrentLiabilities = totalCurrentLiabilities;
            _longTermDebt = longTermDebt;
            _deferredRevenue = deferredRevenue;
            _otherLiabilities = otherLiabilities;
            _totalLiabilities = totalLiabilities;
            _retainedEarnings = retainedEarnings;
            _paidInCapital = paidInCapital;
            _commonStock = commonStock;
            _aOCI = aOCI;         
            _shareholdersEquity = shareholdersEquity;
            _liabilitiesAndEquity = liabilitiesAndEquity;
        }

        public BalanceSheet(Guid id, DateTime createAt, DateTime updateAt, bool isDeleted, Guid companyId, Company company, int year, float cashEquivalents, float shortTermInvestments, float accountsReceivable, float inventories, float otherCurrentAssets, float totalCurrentAssets, float investiments,
         float propertyPlantAndEquipment, float goodwill, float otherIntangibleAssets, float otherAssets,
         float totalAssets, float accountsPayable, float taxPayable, float accruedLiabilities, float shortTermDebt,
         float currentDeferredRevenue, float otherCurrentLiabilities, float totalCurrentLiabilities, float longTermDebt,
         float totalDeferredRevenue, float otherLiabilities, float totalLiabilities, float retainedEarnings,
         float paidInCapital, float commonStock, float aOCI, float shareholdersEquity,
         float liabilitiesAndEquity) : base(id, createAt, updateAt, isDeleted)
        {
            CompanyId = companyId;
            Company = company;
            _year = year;
            _cashEquivalents = cashEquivalents;
            _shortTermInvestments = shortTermInvestments;
            _accountsReceivable = accountsReceivable;
            _inventories = inventories;
            _otherCurrentAssets = otherCurrentAssets;
            _totalCurrentAssets = totalCurrentAssets;
            _investiments = investiments;
            _propertyPlantAndEquipment = propertyPlantAndEquipment;
            _goodwill = goodwill;
            _otherIntangibleAssets = otherIntangibleAssets;
            _otherAssets = otherAssets;
            _totalAssets = totalAssets;
            _accountsPayable = accountsPayable;
            _taxPayable = taxPayable;
            _accruedLiabilities = accruedLiabilities;
            _shortTermDebt = shortTermDebt;
            _currentDeferredRevenue = currentDeferredRevenue;
            _otherCurrentLiabilities = otherCurrentLiabilities;
            _totalCurrentLiabilities = totalCurrentLiabilities;
            _longTermDebt = longTermDebt;
            _deferredRevenue = totalDeferredRevenue;
            _otherLiabilities = otherLiabilities;
            _totalLiabilities = totalLiabilities;
            _retainedEarnings = retainedEarnings;
            _paidInCapital = paidInCapital;
            _commonStock = commonStock;
            _aOCI = aOCI;
            _shareholdersEquity = shareholdersEquity;
            _liabilitiesAndEquity = liabilitiesAndEquity;
        }
        #endregion
    }
}
