using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.DataLayer
{
    public class ExtractedIncomeStatementTtms : Entity
    {
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
        

        public virtual Companies Company { get; set; }
        public Guid CompanyId { get; set; }
        public virtual DataSources DataSource { get; set; }
        public Guid DataSourceId { get; set; }

        public ExtractedIncomeStatementTtms()
        {
        }

        public ExtractedIncomeStatementTtms(Guid id, DateTime createdAt, DateTime updatedAd) : base(id, createdAt, updatedAd)
        {
        }
    }
}
