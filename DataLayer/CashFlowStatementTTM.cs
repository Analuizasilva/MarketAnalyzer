using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recodme.Labs.MarketAnalyzer.DataLayer
{
    public class CashFlowStatementTTM : Entity
    {

        private int _year;
        public int Year
        {
            get => _year;
            set
            {
                _year = value;
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

        private float _depreciationAndAmortization;
        [Display(Name = "Depreciation And Amortization")]
        public float DepreciationAndAmortization
        {
            get => _depreciationAndAmortization;
            set
            {
                _depreciationAndAmortization = value;
                RegisterChange();
            }
        }

        private float _changeInWorkingCapital;
        [Display(Name = "Change In Working Capital")]
        public float ChangeInWorkingCapital
        {
            get => _changeInWorkingCapital;
            set
            {
                _changeInWorkingCapital = value;
                RegisterChange();
            }
        }

        private float _changeInDeferredTax;
        [Display(Name = "Change In Deferred Tax")]
        public float ChangeInDeferredTax
        {
            get => _changeInDeferredTax;
            set
            {
                _changeInDeferredTax = value;
                RegisterChange();
            }
        }

        private float _stockBasedCompensation;
        [Display(Name = "Stock Based Compensation")]
        public float StockBasedCompensation
        {
            get => _stockBasedCompensation;
            set
            {
                _stockBasedCompensation = value;
                RegisterChange();
            }
        }


        private float _otherOperations;
        [Display(Name = "Other Operations")]
        public float OtherOperations
        {
            get => _otherOperations;
            set
            {
                _otherOperations = value;
                RegisterChange();
            }
        }

        private float _cashFromOperations;
        [Display(Name = "Cash From Operations")]
        public float CashFromOperations
        {
            get => _cashFromOperations;
            set
            {
                _cashFromOperations = value;
                RegisterChange();
            }
        }

        private float _propertyPlantAndEquipment;
        [Display(Name = "Property Plant And Equipment")]
        public float PropertyPlantAndEquipment
        {
            get => _propertyPlantAndEquipment;
            set
            {
                _propertyPlantAndEquipment = value;
                RegisterChange();
            }
        }

        private float _acquisitions;
        public float Acquisitions
        {
            get => _acquisitions;
            set
            {
                _acquisitions = value;
                RegisterChange();
            }
        }

        private float _investments;
        public float Investments
        {
            get => _investments;
            set
            {
                _investments = value;
                RegisterChange();
            }
        }

        private float _intangibles;
        public float Intangibles
        {
            get => _intangibles;
            set
            {
                _intangibles = value;
                RegisterChange();
            }
        }

        private float _otherInvesting;
        [Display(Name = "Other Investing")]
        public float OtherInvesting
        {
            get => _otherInvesting;
            set
            {
                _otherInvesting = value;
                RegisterChange();
            }
        }

        private float _cashFromInvesting;
        [Display(Name = "Cash From Investing")]
        public float CashFromInvesting
        {
            get => _cashFromInvesting;
            set
            {
                _cashFromInvesting = value;
                RegisterChange();
            }
        }

        private float _netIssuanceOfCommonStock;
        [Display(Name = "Net Issuance Of Common Stock")]
        public float NetIssuanceOfCommonStock
        {
            get => _netIssuanceOfCommonStock;
            set
            {
                _netIssuanceOfCommonStock = value;
                RegisterChange();
            }
        }

        private float _netIssuanceOfDebt;
        [Display(Name = "Net Issuance Of Debt")]
        public float NetIssuanceOfDebt
        {
            get => _netIssuanceOfDebt;
            set
            {
                _netIssuanceOfDebt = value;
                RegisterChange();
            }
        }

        private float _cashPaidForDividends;
        [Display(Name = "Cash Paid For Dividends")]
        public float CashPaidForDividends
        {
            get => _cashPaidForDividends;
            set
            {
                _cashPaidForDividends = value;
                RegisterChange();
            }
        }

        private float _otherFinancing;
        [Display(Name = "Other Financing")]
        public float OtherFinancing
        {
            get => _otherFinancing;
            set
            {
                _otherFinancing = value;
                RegisterChange();
            }
        }

        
        private float _cashFromFinancing;
        [Display(Name = "Cash From Financing")]
        public float CashFromFinancing
        {
            get => _cashFromFinancing;
            set
            {
                _cashFromFinancing = value;
                RegisterChange();
            }
        }

        #region Foreign Key

        [ForeignKey("Company")]
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }

        #endregion

        public CashFlowStatementTTM()
        {
        }

        public CashFlowStatementTTM(int year, float netIncome, float depreciationAndAmortization, float changeInWorkingCapital, float changeInDeferredTax, float stockBasedCompensation, float otherOperations, float cashFromOperations, float propertyPlantAndEquipment, float acquisitions, float investments, float intangibles, float otherInvesting, float cashFromInvesting, float netIssuanceOfCommonStock, float netIssuanceOfDebt, float cashPaidForDividends, float otherFinancing, float cashFromFinancing)
        {
            _year = year;
            _netIncome = netIncome;
            _depreciationAndAmortization = depreciationAndAmortization;
            _changeInWorkingCapital = changeInWorkingCapital;
            _changeInDeferredTax = changeInDeferredTax;
            _stockBasedCompensation = stockBasedCompensation;
            _otherOperations = otherOperations;
            _cashFromOperations = cashFromOperations;
            _propertyPlantAndEquipment = propertyPlantAndEquipment;
            _acquisitions= acquisitions;
            _investments = investments;
            _intangibles = intangibles;
            _otherInvesting = otherInvesting;
            _cashFromInvesting = cashFromInvesting;
            _netIssuanceOfCommonStock = netIssuanceOfCommonStock;
            _netIssuanceOfDebt = netIssuanceOfDebt;
            _cashPaidForDividends = cashPaidForDividends;
            _otherFinancing = otherFinancing;
            _cashFromFinancing = cashFromFinancing;
        }

        public CashFlowStatementTTM(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, int year, float netIncome, float depreciationAndAmortization, float changeInWorkingCapital, float changeInDeferredTax, float stockBasedCompensation, float otherOperations, float cashFromOperations, float propertyPlantAndEquipment, float acquisitions, float investments, float intangibles, float otherInvesting, float cashFromInvesting, float netIssuanceOfCommonStock, float netIssuanceOfDebt, float cashPaidForDividends, float otherFinancing, float cashFromFinancing) : base(id, createdAt, updatedAt, isDeleted)
        {
            _year = year;
            _netIncome = netIncome;
            _depreciationAndAmortization = depreciationAndAmortization;
            _changeInWorkingCapital = changeInWorkingCapital;
            _changeInDeferredTax = changeInDeferredTax;
            _stockBasedCompensation = stockBasedCompensation;
            _otherOperations = otherOperations;
            _cashFromOperations = cashFromOperations;
            _propertyPlantAndEquipment = propertyPlantAndEquipment;
            _acquisitions = acquisitions;
            _investments = investments;
            _intangibles = intangibles;
            _otherInvesting = otherInvesting;
            _cashFromInvesting = cashFromInvesting;
            _netIssuanceOfCommonStock = netIssuanceOfCommonStock;
            _netIssuanceOfDebt = netIssuanceOfDebt;
            _cashPaidForDividends = cashPaidForDividends;
            _otherFinancing = otherFinancing;
            _cashFromFinancing = cashFromFinancing;
        }


    }
}
