﻿using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using System;

namespace Recodme.Labs.MarketAnalyzer.DataLayer
{
    public class ExtractedBalanceSheet : Entity
    {
        public Guid DataSourceId { get; set; }
        public int Year { get; set; }
        public decimal? CashEquivalents { get; set; }
        public decimal? ShortTermInvestments { get; set; }
        public decimal? AccountsReceivable { get; set; }
        public decimal? OtherCurrentAssets { get; set; }
        public decimal? TotalCurrentAssets { get; set; }
        public decimal? Investments { get; set; }
        public decimal? PropertyPlanEquipmentNet { get; set; }
        public decimal? Goodwill { get; set; }
        public decimal? OtherIntangibleAssets { get; set; }
        public decimal? OtherAssets { get; set; }
        public decimal? TotalAssets { get; set; }
        public decimal? AccountsPayable { get; set; }
        public decimal? TaxPayable { get; set; }
        public decimal? AccruedLiabilities { get; set; }
        public decimal? ShortTermDebt { get; set; }
        public decimal? DeferedRevenue1 { get; set; }
        public decimal? OtherCurrentLiabilities { get; set; }
        public decimal? TotalCurrentLiabilities { get; set; }
        public decimal? LongTermDebt { get; set; }
        public decimal? CapitalLeases { get; set; }
        public decimal? DeferredRevenue2 { get; set; }
        public decimal? OtherLiabilities { get; set; }
        public decimal? TotalLiabilities { get; set; }
        public decimal? RetainedEarnings { get; set; }
        public decimal? PaidInCapital { get; set; }
        public decimal? CommonStock { get; set; }
        public decimal? Aoci { get; set; }
        public decimal? TreasuryStock { get; set; }
        public decimal? Other { get; set; }
        public decimal? ShareholdersEquity { get; set; }
        public decimal? LiabilitiesAndEquity { get; set; }
        public Guid CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual DataSource DataSource { get; set; }

        public ExtractedBalanceSheet()
        {
        }

        public ExtractedBalanceSheet(Guid id, DateTime createdAt, DateTime updatedAd) : base(id, createdAt, updatedAd)
        {
        }
    }
}
