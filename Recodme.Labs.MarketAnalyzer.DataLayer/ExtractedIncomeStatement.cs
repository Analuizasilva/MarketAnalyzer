﻿using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using System;

namespace Recodme.Labs.MarketAnalyzer.DataLayer
{
    public class ExtractedIncomeStatement : Entity
    {
        public int Year { get; set; }
        public decimal? Revenue { get; set; }
        public decimal? CostOfGoodsSold { get; set; }
        public decimal? GrossProfit { get; set; }
        public decimal? Sales { get; set; }
        public decimal? Rd { get; set; }
        public decimal? SpecialCharges { get; set; }
        public decimal? OtherExpenses { get; set; }
        public decimal? TotalOperatingExpenses { get; set; }
        public decimal? OperatingProfit { get; set; }
        public decimal? NetInterestIncome { get; set; }
        public decimal? OtherNonOperatingIncome { get; set; }
        public decimal? PreTaxIncome { get; set; }
        public decimal? IncomeTax { get; set; }
        public decimal? NetIncome { get; set; }
        public decimal? EpsBasic { get; set; }
        public decimal? EpsDiluted { get; set; }
        public decimal? SharesBasic { get; set; }
        public decimal? SharesDiluted { get; set; }

        public virtual Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public virtual DataSource DataSource { get; set; }
        public Guid DataSourceId { get; set; }

        public ExtractedIncomeStatement()
        {
        }

        public ExtractedIncomeStatement(Guid id, DateTime createdAt, DateTime updatedAd, bool isDeleted) : base(id, createdAt, updatedAd)
        {
        }
    }
}
