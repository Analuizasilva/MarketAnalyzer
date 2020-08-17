﻿//using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace Recodme.Labs.MarketAnalyzer.DataLayer
//{
//    public class CashFlowStatement : Entity
//    {
//        #region Year
//        private int _year;
//        [Display(Name = "Year")]
//        public int Year
//        {
//            get => _year;
//            set
//            {
//                _year = value;
//                RegisterChange();
//            }
//        }
//        #endregion

//        #region Net Income
//        private float _netIncome;
//        [Display(Name = "Net Income")]
//        public float NetIncome
//        {
//            get => _netIncome;
//            set
//            {
//                _netIncome = value;
//                RegisterChange();
//            }
//        }
//        #endregion

//        #region Depreciation & Amortization
//        private float _depreciationAndAmortization;
//        [Display(Name = "Depreciation & Amortization")]
//        public float DepreciationAndAmortization
//        {
//            get => _depreciationAndAmortization;
//            set
//            {
//                _depreciationAndAmortization = value;
//                RegisterChange();
//            }
//        }
//        #endregion

//        #region Change In Working Capital
//        private float _changeInWorkingCapital;
//        [Display(Name = "Change In Working Capital")]
//        public float ChangeInWorkingCapital
//        {
//            get => _changeInWorkingCapital;
//            set
//            {
//                _changeInWorkingCapital = value;
//                RegisterChange();
//            }
//        }
//        #endregion

//        #region Change In Deferred Tax
//        private float _changeInDeferredTax;
//        [Display(Name = "Change In Deferred Tax")]
//        public float ChangeInDeferredTax
//        {
//            get => _changeInDeferredTax;
//            set
//            {
//                _changeInDeferredTax = value;
//                RegisterChange();
//            }
//        }
//        #endregion

//        #region Stock-Based Compensation
//        private float _stockBasedCompensation;
//        [Display(Name = "Stock-Based Compensation")]
//        public float StockBasedCompensation
//        {
//            get => _stockBasedCompensation;
//            set
//            {
//                _stockBasedCompensation = value;
//                RegisterChange();
//            }
//        }
//        #endregion

//        #region Other Operations 
//        private float _otherOperations;
//        [Display(Name = "Other6")]
//        public float OtherOperations
//        {
//            get => _otherOperations;
//            set
//            {
//                _otherOperations = value;
//                RegisterChange();
//            }
//        }
//        #endregion

//        #region Cash From Operations
//        private float _cashFromOperations;
//        [Display(Name = "Cash From Operations")]
//        public float CashFromOperations
//        {
//            get => _cashFromOperations;
//            set
//            {
//                _cashFromOperations = value;
//                RegisterChange();
//            }
//        }
//        #endregion

//        #region Property. Plant. & Equipment
//        private float _propertyPlantAndEquipment;
//        [Display(Name = "Property. Plant. & Equipment")]
//        public float PropertyPlantAndEquipment
//        {
//            get => _propertyPlantAndEquipment;
//            set
//            {
//                _propertyPlantAndEquipment = value;
//                RegisterChange();
//            }
//        }
//        #endregion

//        #region Acquisitions
//        private float _acquisitions;
//        [Display(Name = "Acquisitions")]
//        public float Acquisitions
//        {
//            get => _acquisitions;
//            set
//            {
//                _acquisitions = value;
//                RegisterChange();
//            }
//        }
//        #endregion

//        #region Investments
//        private float _investments;
//        [Display(Name = "Investments")]
//        public float Investments
//        {
//            get => _investments;
//            set
//            {
//                _investments = value;
//                RegisterChange();
//            }
//        }
//        #endregion

//        #region Intangibles
//        private float _intangibles;
//        [Display(Name = "Intangibles")]
//        public float Intangibles
//        {
//            get => _intangibles;
//            set
//            {
//                _intangibles = value;
//                RegisterChange();
//            }
//        }
//        #endregion

//        #region Other Investing
//        private float _otherInvesting;
//        [Display(Name = "Other13")]
//        public float OtherInvesting
//        {
//            get => _otherInvesting;
//            set
//            {
//                _otherInvesting = value;
//                RegisterChange();
//            }
//        }
//        #endregion

//        #region Cash From Investing
//        private float _cashFromInvesting;
//        [Display(Name = "Cash From Investing")]
//        public float CashFromInvesting
//        {
//            get => _cashFromInvesting;
//            set
//            {
//                _cashFromInvesting = value;
//                RegisterChange();
//            }
//        }
//        #endregion

//        #region Net Issuance of Common Stock
//        private float _netIssuanceOfCommonStock;
//        [Display(Name = "Net Issuance of Common Stock")]
//        public float NetIssuanceOfCommonStock
//        {
//            get => _netIssuanceOfCommonStock;
//            set
//            {
//                _netIssuanceOfCommonStock = value;
//                RegisterChange();
//            }
//        }
//        #endregion

//        #region Net Issuance of Debt
//        private float _netIssuanceOfDebt;
//        [Display(Name = "Net Issuance of Debt")]
//        public float NetIssuanceOfDebt
//        {
//            get => _netIssuanceOfDebt;
//            set
//            {
//                _netIssuanceOfDebt = value;
//                RegisterChange();
//            }
//        }
//        #endregion

//        #region Cash Paid for Dividends
//        private float _cashPaidForDividends;
//        [Display(Name = "Cash Paid for Dividends")]
//        public float CashPaidForDividends
//        {
//            get => _cashPaidForDividends;
//            set
//            {
//                _cashPaidForDividends = value;
//                RegisterChange();
//            }
//        }
//        #endregion

//        #region Other Financing
//        private float _otherFinancing;
//        [Display(Name = "Other19")]
//        public float OtherFinancing
//        {
//            get => _otherFinancing;
//            set
//            {
//                _otherFinancing = value;
//                RegisterChange();
//            }
//        }
//        #endregion

//        #region Cash From Financing
//        private float _cashFromFinancing;
//        [Display(Name = "Cash From Financing")]
//        public float CashFromFinancing
//        {
//            get => _cashFromFinancing;
//            set
//            {
//                _cashFromFinancing = value;
//                RegisterChange();
//            }
//        }
//        #endregion

//        #region Foreign Key

//        [ForeignKey("Company")]
//        public Guid CompanyId { get; set; }
//        public virtual Company Company { get; set; }

//        #endregion


//        public CashFlowStatement()
//        {
//        }

//        public CashFlowStatement(int year, float netIncome, float depreciationAndAmortization, float changeInWorkingCapital, float changeInDeferredTax, float stockBasedCompensation, float otherOperations, float cashFromOperations, float propertyPlantAndEquipment, float acquisitions, float investments, float intangibles, float otherInvesting, float cashFromInvesting, float netIssuanceOfCommonStock, float netIssuanceOfDebt, float cashPaidForDividends, float otherFinancing, float cashFromFinancing)
//        {
//            _year = year;
//            _netIncome = netIncome;
//            _depreciationAndAmortization = depreciationAndAmortization;
//            _changeInWorkingCapital = changeInWorkingCapital;
//            _changeInDeferredTax = changeInDeferredTax;
//            _stockBasedCompensation = stockBasedCompensation;
//            _otherOperations = otherOperations;
//            _cashFromOperations = cashFromOperations;
//            _propertyPlantAndEquipment = propertyPlantAndEquipment;
//            _acquisitions= acquisitions;
//            _investments = investments;
//            _intangibles = intangibles;
//            _otherInvesting = otherInvesting;
//            _cashFromInvesting = cashFromInvesting;
//            _netIssuanceOfCommonStock = netIssuanceOfCommonStock;
//            _netIssuanceOfDebt = netIssuanceOfDebt;
//            _cashPaidForDividends = cashPaidForDividends;
//            _otherFinancing = otherFinancing;
//            _cashFromFinancing = cashFromFinancing;
//        }

//        public CashFlowStatement(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, int year, float netIncome, float depreciationAndAmortization, float changeInWorkingCapital, float changeInDeferredTax, float stockBasedCompensation, float otherOperations, float cashFromOperations, float propertyPlantAndEquipment, float acquisitions, float investments, float intangibles, float otherInvesting, float cashFromInvesting, float netIssuanceOfCommonStock, float netIssuanceOfDebt, float cashPaidForDividends, float otherFinancing, float cashFromFinancing) : base(id, createdAt, updatedAt, isDeleted)
//        {
//            _year = year;
//            _netIncome = netIncome;
//            _depreciationAndAmortization = depreciationAndAmortization;
//            _changeInWorkingCapital = changeInWorkingCapital;
//            _changeInDeferredTax = changeInDeferredTax;
//            _stockBasedCompensation = stockBasedCompensation;
//            _otherOperations = otherOperations;
//            _cashFromOperations = cashFromOperations;
//            _propertyPlantAndEquipment = propertyPlantAndEquipment;
//            _acquisitions = acquisitions;
//            _investments = investments;
//            _intangibles = intangibles;
//            _otherInvesting = otherInvesting;
//            _cashFromInvesting = cashFromInvesting;
//            _netIssuanceOfCommonStock = netIssuanceOfCommonStock;
//            _netIssuanceOfDebt = netIssuanceOfDebt;
//            _cashPaidForDividends = cashPaidForDividends;
//            _otherFinancing = otherFinancing;
//            _cashFromFinancing = cashFromFinancing;
//        }


//    }
//}
