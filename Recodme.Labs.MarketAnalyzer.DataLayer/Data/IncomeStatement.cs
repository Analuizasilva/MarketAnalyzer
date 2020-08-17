using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recodme.Labs.MarketAnalyzer.DataLayer
{
    public class IncomeStatement : Entity
    {
        #region Year
        private int _year;
        [Required]
        public int Year
        {
            get
            {
                return _year;
            }
            set
            {
                _year = value;
                RegisterChange();
            }
        }
        #endregion

        #region Revenue
        private float _revenue;
        [Display(Name ="Revenue")]
        public float Revenue
        {
            get
            {
                return _revenue;
            }
            set
            {
                _revenue = value;
                RegisterChange();
            }
        }
        #endregion

        #region Cost of Good Sold
        private float _costOfGoodsSold;
        [Display(Name = "Cost of Goods Sold")]
        public float CostOfGoodsSold
        {
            get
            {
                return _costOfGoodsSold;
            }
            set
            {
                _costOfGoodsSold = value;
                RegisterChange();
            }
        }
        #endregion

        #region Gross Profit
        private float _grossProfit;
        [Display(Name = "Gross Profit")]
        public float GrossProfit
        {
            get
            {
                return _grossProfit;
            }
            set
            {
                _grossProfit = value;
                RegisterChange();
            }
        }
        #endregion

        #region Sales General Administrative
        private float _salesGeneralAdministrative;
        [Display(Name = "Sales. General. & Administrative")]
        public float SalesGeneralAdministrative
        {
            get
            {
                return _salesGeneralAdministrative;
            }
            set
            {
                _salesGeneralAdministrative = value;
                RegisterChange();
            }
        }
        #endregion

        #region Research Development
        private float _researchDevelopment;
        [Display(Name = "Research & Development")]
        public float ResearchDevelopment
        {
            get
            {
                return _researchDevelopment;
            }
            set
            {
                _researchDevelopment = value;
                RegisterChange();
            }
        }
        #endregion

        #region Total Operating Expenses
        private float _totalOperatingExpenses;
        [Display(Name = "Total Operating Expenses")]
        public float TotalOperatingExpenses
        {
            get
            {
                return _totalOperatingExpenses;
            }
            set
            {
                _totalOperatingExpenses = value;
                RegisterChange();
            }
        }
        #endregion

        #region Operating Profit
        private float _operatingProfit;
        [Display(Name = "Operating Profit")]
        public float OperatingProfit
        {
            get
            {
                return _operatingProfit;
            }
            set
            {
                _operatingProfit = value;
                RegisterChange();
            }
        }
        #endregion

        #region Net Interest Income
        private float _netInterestIncome;
        [Display(Name = "Net Interest Income")]
        public float NetInterestIncome
        {
            get
            {
                return _netInterestIncome;
            }
            set
            {
                _netInterestIncome = value;
                RegisterChange();
            }
        }
        #endregion

        #region Other Non Operating Income
        private float _otherNonOperatingIncome;
        [Display(Name = "Other Non-Operating Income")]
        public float OtherNonOperatingIncome
        {
            get
            {
                return _otherNonOperatingIncome;
            }
            set
            {
                _otherNonOperatingIncome = value;
                RegisterChange();
            }
        }
        #endregion

        #region Pre-Tax Income
        private float _preTaxIncome;
        [Display(Name = "Pre-Tax Income")]
        public float PreTaxeIncome
        {
            get
            {
                return _preTaxIncome;
            }
            set
            {
                _preTaxIncome = value;
                RegisterChange();
            }
        }
        #endregion

        #region Income Tax
        private float _incomeTax;
        [Display(Name = "Income Tax")]
        public float IncomeTax
        {
            get
            {
                return _incomeTax;
            }
            set
            {
                _incomeTax = value;
                RegisterChange();
            }
        }
        #endregion

        #region Net Income
        private float _netIncome;
        [Display(Name = "Net Income")]
        public float NetIncome
        {
            get
            {
                return _netIncome;
            }
            set
            {
                _netIncome = value;
                RegisterChange();
            }
        }
        #endregion

        #region EPS Basic
        private float _ePSBasic;
        [Display(Name = "EPS (Basic)")]
        public float EPSBasic
        {
            get
            {
                return _ePSBasic;
            }
            set
            {
                _ePSBasic = value;
                RegisterChange();
            }
        }
        #endregion

        #region EPS Diluted
        private float _ePSDiluted;
        [Display(Name = "EPS (Diluted)")]
        public float EPSDiluted
        {
            get
            {
                return _ePSDiluted;
            }
            set
            {
                _ePSDiluted = value;
                RegisterChange();
            }
        }
        #endregion

        #region Shares Basic
        private float _sharesBasic;
        [Display(Name = "Shares (Basic)")]
        public float SharesBasic
        {
            get
            {
                return _sharesBasic;
            }
            set
            {
                _sharesBasic = value;
                RegisterChange();
            }
        }
        #endregion

        #region Shares Diluted
        private float _sharesDiluted;
        [Display (Name = "Shares (Diluted)")]
        public float SharesDiluted
        {
            get
            {
                return _sharesDiluted;
            }
            set
            {
                _sharesDiluted = value;
                RegisterChange();
            }
        }
        #endregion

        #region Company Foreign Key
        [ForeignKey("Company")]
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }
        #endregion

        #region Constructors
        public IncomeStatement()
        {

        }

        public IncomeStatement(int year, float revenue, float costOfGoodsSold, float grossProfit, 
            float salesGeneralAdministrative, float researchDevelopment, float totalOperatingExpenses, 
            float operatingProfit, float netInterestIncome, float otherNonOperatingIncome, float preTaxIncome,
            float incomeTax, float netIncome, float ePSBasic, float ePSDiluted, float sharesBasic, float sharesDiluted, 
            Guid companyId)
        {
            _year = year;
            _revenue = revenue;
            _costOfGoodsSold = costOfGoodsSold;
            _grossProfit = grossProfit;
            _salesGeneralAdministrative = salesGeneralAdministrative;
            _researchDevelopment = researchDevelopment;
            _totalOperatingExpenses = totalOperatingExpenses;
            _operatingProfit = operatingProfit;
            _netInterestIncome = netInterestIncome;
            _otherNonOperatingIncome = otherNonOperatingIncome;
            _preTaxIncome = preTaxIncome;
            _incomeTax = incomeTax;
            _netIncome = netIncome;
            _ePSBasic = ePSBasic;
            _ePSDiluted = ePSDiluted;
            _sharesBasic = sharesBasic;
            _sharesDiluted = sharesDiluted;
            CompanyId = companyId;    
        }

        public IncomeStatement(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, int year, float revenue, float costOfGoodsSold, float grossProfit,
            float salesGeneralAdministrative, float researchDevelopment, float totalOperatingExpenses,
            float operatingProfit, float netInterestIncome, float otherNonOperatingIncome, float preTaxIncome,
            float incomeTax, float netIncome, float ePSBasic, float ePSDiluted, float sharesBasic, float sharesDiluted,
            Guid companyId) : base (id, createdAt, updatedAt, isDeleted)
        {

            _year = year;
            _revenue = revenue;
            _costOfGoodsSold = costOfGoodsSold;
            _grossProfit = grossProfit;
            _salesGeneralAdministrative = salesGeneralAdministrative;
            _researchDevelopment = researchDevelopment;
            _totalOperatingExpenses = totalOperatingExpenses;
            _operatingProfit = operatingProfit;
            _netInterestIncome = netInterestIncome;
            _otherNonOperatingIncome = otherNonOperatingIncome;
            _preTaxIncome = preTaxIncome;
            _incomeTax = incomeTax;
            _netIncome = netIncome;
            _ePSBasic = ePSBasic;
            _ePSDiluted = ePSDiluted;
            _sharesBasic = sharesBasic;
            _sharesDiluted = sharesDiluted;
            CompanyId = companyId;
        }
        #endregion
    }
}
