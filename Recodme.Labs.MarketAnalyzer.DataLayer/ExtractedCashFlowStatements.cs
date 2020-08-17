﻿using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.DataLayer
{
    public class ExtractedCashFlowStatements: Entity
    {
        public int Year { get; set; }
        public decimal? DepreciationAmortization { get; set; }
        public decimal? ChangeInWorkCapital { get; set; }
        public decimal? ChangeInDeferredTax { get; set; }
        public decimal? StockBasedCompensation { get; set; }
        public decimal? OperationsOther { get; set; }
        public decimal? CashFromOperations { get; set; }
        public decimal? PropertyPlanEquipment { get; set; }
        public decimal? Acquisitions { get; set; }
        public decimal? Investments { get; set; }
        public decimal? Intangibles { get; set; }
        public decimal? InvestingOther { get; set; }
        public decimal? CashFromInvesting { get; set; }
        public decimal? IssuanceCommonStockNet { get; set; }
        public decimal? IssuancePreferredStockNet { get; set; }
        public decimal? IssuanceDebtNet { get; set; }
        public decimal? CashPaidForDividends { get; set; }
        public decimal? FinancingOther { get; set; }
        public decimal? CashFromFinancing { get; set; }
        

        public virtual Companies Company { get; set; }
        public Guid CompanyId { get; set; }
        public virtual DataSources DataSource { get; set; }
        public Guid DataSourceId { get; set; }

        public ExtractedCashFlowStatements()
        {
        }

        public ExtractedCashFlowStatements(Guid id, DateTime createdAt, DateTime updatedAd) : base(id, createdAt, updatedAd)
        {
        }
    }
}
