using Microsoft.EntityFrameworkCore;
using Recodme.Labs.MarketAnalyzer.DataLayer.Properties;

namespace Recodme.Labs.MarketAnalyzer.DataLayer.Context
{
    public partial class MarketAnalyzerDBContext : DbContext
    {
        private readonly string _connectionString = string.Empty;
        public MarketAnalyzerDBContext()
        {
        }

        public MarketAnalyzerDBContext(DbContextOptions<MarketAnalyzerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<DataSource> DataSources { get; set; }
        public virtual DbSet<ExtractedBalanceSheet> ExtractedBalanceSheets { get; set; }
        public virtual DbSet<ExtractedCashFlowStatementTtm> ExtractedCashFlowStatementTtms { get; set; }
        public virtual DbSet<ExtractedCashFlowStatement> ExtractedCashFlowStatements { get; set; }
        public virtual DbSet<ExtractedIncomeStatementTtm> ExtractedIncomeStatementTtms { get; set; }
        public virtual DbSet<ExtractedIncomeStatement> ExtractedIncomeStatements { get; set; }
        public virtual DbSet<ExtractedKeyRatio> ExtractedKeyRatios { get; set; }
        public virtual DbSet<Industry> Industries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (_connectionString == string.Empty)
                {
                    optionsBuilder.UseSqlServer(Resources.ConnectionString);
                }
                else
                {
                    optionsBuilder.UseSqlServer(_connectionString);
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Country)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("datetime2(3)");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime2(3)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SandPrank).HasColumnName("SAndPRank");

                entity.Property(e => e.StockPrice).HasColumnType("money");

                entity.Property(e => e.Ticker)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Industry)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.IndustryId)
                    .HasConstraintName("FK_Companies_Industries");
            });

            modelBuilder.Entity<DataSource>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ExtractedBalanceSheet>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AccountsPayable).HasColumnType("money");

                entity.Property(e => e.AccountsReceivable).HasColumnType("money");

                entity.Property(e => e.AccruedLiabilities).HasColumnType("money");

                entity.Property(e => e.Aoci)
                    .HasColumnName("AOCI")
                    .HasColumnType("money");

                entity.Property(e => e.CapitalLeases).HasColumnType("money");

                entity.Property(e => e.CashEquivalents).HasColumnType("money");

                entity.Property(e => e.CommonStock).HasColumnType("money");

                entity.Property(e => e.DateCreated).HasColumnType("datetime2(3)");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime2(3)");

                entity.Property(e => e.DeferedRevenue1).HasColumnType("money");

                entity.Property(e => e.DeferredRevenue2).HasColumnType("money");

                entity.Property(e => e.Goodwill).HasColumnType("money");

                entity.Property(e => e.Investments).HasColumnType("money");

                entity.Property(e => e.LiabilitiesAndEquity).HasColumnType("money");

                entity.Property(e => e.LongTermDebt).HasColumnType("money");

                entity.Property(e => e.Other).HasColumnType("money");

                entity.Property(e => e.OtherAssets).HasColumnType("money");

                entity.Property(e => e.OtherCurrentAssets).HasColumnType("money");

                entity.Property(e => e.OtherCurrentLiabilities).HasColumnType("money");

                entity.Property(e => e.OtherIntangibleAssets).HasColumnType("money");

                entity.Property(e => e.OtherLiabilities).HasColumnType("money");

                entity.Property(e => e.PaidInCapital).HasColumnType("money");

                entity.Property(e => e.PropertyPlanEquipmentNet).HasColumnType("money");

                entity.Property(e => e.RetainedEarnings).HasColumnType("money");

                entity.Property(e => e.ShareholdersEquity).HasColumnType("money");

                entity.Property(e => e.ShortTermDebt).HasColumnType("money");

                entity.Property(e => e.ShortTermInvestments).HasColumnType("money");

                entity.Property(e => e.TaxPayable).HasColumnType("money");

                entity.Property(e => e.TotalAssets).HasColumnType("money");

                entity.Property(e => e.TotalCurrentAssets).HasColumnType("money");

                entity.Property(e => e.TotalCurrentLiabilities).HasColumnType("money");

                entity.Property(e => e.TotalLiabilities).HasColumnType("money");

                entity.Property(e => e.TreasuryStock).HasColumnType("money");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.ExtractedBalanceSheets)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExtractedBalanceSheets_Companies");

                entity.HasOne(d => d.DataSource)
                    .WithMany(p => p.ExtractedBalanceSheets)
                    .HasForeignKey(d => d.DataSourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExtractedBalanceSheets_DataSources");
            });

            modelBuilder.Entity<ExtractedCashFlowStatementTtm>(entity =>
            {
                entity.ToTable("ExtractedCashFlowStatementTTMs");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Acquisitions).HasColumnType("money");

                entity.Property(e => e.CashFromFinancing).HasColumnType("money");

                entity.Property(e => e.CashFromInvesting).HasColumnType("money");

                entity.Property(e => e.CashFromOperations).HasColumnType("money");

                entity.Property(e => e.CashPaidForDividends).HasColumnType("money");

                entity.Property(e => e.ChangeInDeferredTax).HasColumnType("money");

                entity.Property(e => e.ChangeInWorkCapital).HasColumnType("money");

                entity.Property(e => e.DateCreated).HasColumnType("datetime2(3)");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime2(3)");

                entity.Property(e => e.DepreciationAmortization).HasColumnType("money");

                entity.Property(e => e.FinancingOther).HasColumnType("money");

                entity.Property(e => e.Intangibles).HasColumnType("money");

                entity.Property(e => e.InvestingOther).HasColumnType("money");

                entity.Property(e => e.Investments).HasColumnType("money");

                entity.Property(e => e.IssuanceCommonStockNet).HasColumnType("money");

                entity.Property(e => e.IssuanceDebtNet).HasColumnType("money");

                entity.Property(e => e.IssuancePreferredStockNet).HasColumnType("money");

                entity.Property(e => e.OperationsOther).HasColumnType("money");

                entity.Property(e => e.PropertyPlanEquipment).HasColumnType("money");

                entity.Property(e => e.StockBasedCompensation).HasColumnType("money");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.ExtractedCashFlowStatementTtms)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExtractedCashFlowStatementTTMs_Companies");

                entity.HasOne(d => d.DataSource)
                    .WithMany(p => p.ExtractedCashFlowStatementTtms)
                    .HasForeignKey(d => d.DataSourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExtractedCashFlowStatementTTMs_DataSources");
            });

            modelBuilder.Entity<ExtractedCashFlowStatement>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Acquisitions).HasColumnType("money");

                entity.Property(e => e.CashFromFinancing).HasColumnType("money");

                entity.Property(e => e.CashFromInvesting).HasColumnType("money");

                entity.Property(e => e.CashFromOperations).HasColumnType("money");

                entity.Property(e => e.CashPaidForDividends).HasColumnType("money");

                entity.Property(e => e.ChangeInDeferredTax).HasColumnType("money");

                entity.Property(e => e.ChangeInWorkCapital).HasColumnType("money");

                entity.Property(e => e.DateCreated).HasColumnType("datetime2(3)");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime2(3)");

                entity.Property(e => e.DepreciationAmortization).HasColumnType("money");

                entity.Property(e => e.FinancingOther).HasColumnType("money");

                entity.Property(e => e.Intangibles).HasColumnType("money");

                entity.Property(e => e.InvestingOther).HasColumnType("money");

                entity.Property(e => e.Investments).HasColumnType("money");

                entity.Property(e => e.IssuanceCommonStockNet).HasColumnType("money");

                entity.Property(e => e.IssuanceDebtNet).HasColumnType("money");

                entity.Property(e => e.IssuancePreferredStockNet).HasColumnType("money");

                entity.Property(e => e.OperationsOther).HasColumnType("money");

                entity.Property(e => e.PropertyPlanEquipment).HasColumnType("money");

                entity.Property(e => e.StockBasedCompensation).HasColumnType("money");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.ExtractedCashFlowStatements)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExtractedCashFlowStatements_Companies");

                entity.HasOne(d => d.DataSource)
                    .WithMany(p => p.ExtractedCashFlowStatements)
                    .HasForeignKey(d => d.DataSourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExtractedCashFlowStatements_DataSources");
            });

            modelBuilder.Entity<ExtractedIncomeStatementTtm>(entity =>
            {
                entity.ToTable("ExtractedIncomeStatementTTMs");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CostOfGoodsSold).HasColumnType("money");

                entity.Property(e => e.DateCreated).HasColumnType("datetime2(3)");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime2(3)");

                entity.Property(e => e.EpsBasic).HasColumnType("money");

                entity.Property(e => e.EpsDiluted).HasColumnType("money");

                entity.Property(e => e.GrossProfit).HasColumnType("money");

                entity.Property(e => e.IncomeTax).HasColumnType("money");

                entity.Property(e => e.NetIncome).HasColumnType("money");

                entity.Property(e => e.NetInterestIncome).HasColumnType("money");

                entity.Property(e => e.OperatingProfit).HasColumnType("money");

                entity.Property(e => e.OtherExpenses).HasColumnType("money");

                entity.Property(e => e.OtherNonOperatingIncome).HasColumnType("money");

                entity.Property(e => e.PreTaxIncome).HasColumnType("money");

                entity.Property(e => e.Rd)
                    .HasColumnName("RD")
                    .HasColumnType("money");

                entity.Property(e => e.Revenue).HasColumnType("money");

                entity.Property(e => e.Sales).HasColumnType("money");

                entity.Property(e => e.SharesBasic).HasColumnType("money");

                entity.Property(e => e.SharesDiluted).HasColumnType("money");

                entity.Property(e => e.SpecialCharges).HasColumnType("money");

                entity.Property(e => e.TotalOperatingExpenses).HasColumnType("money");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.ExtractedIncomeStatementTtms)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExtractedIncomeStatementTTMs_Companies");

                entity.HasOne(d => d.DataSource)
                    .WithMany(p => p.ExtractedIncomeStatementTtms)
                    .HasForeignKey(d => d.DataSourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExtractedIncomeStatementTTMs_DataSources");
            });

            modelBuilder.Entity<ExtractedIncomeStatement>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CostOfGoodsSold).HasColumnType("money");

                entity.Property(e => e.DateCreated).HasColumnType("datetime2(3)");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime2(3)");

                entity.Property(e => e.EpsBasic).HasColumnType("money");

                entity.Property(e => e.EpsDiluted).HasColumnType("money");

                entity.Property(e => e.GrossProfit).HasColumnType("money");

                entity.Property(e => e.IncomeTax).HasColumnType("money");

                entity.Property(e => e.NetIncome).HasColumnType("money");

                entity.Property(e => e.NetInterestIncome).HasColumnType("money");

                entity.Property(e => e.OperatingProfit).HasColumnType("money");

                entity.Property(e => e.OtherExpenses).HasColumnType("money");

                entity.Property(e => e.OtherNonOperatingIncome).HasColumnType("money");

                entity.Property(e => e.PreTaxIncome).HasColumnType("money");

                entity.Property(e => e.Rd)
                    .HasColumnName("RD")
                    .HasColumnType("money");

                entity.Property(e => e.Revenue).HasColumnType("money");

                entity.Property(e => e.Sales).HasColumnType("money");

                entity.Property(e => e.SharesBasic).HasColumnType("money");

                entity.Property(e => e.SharesDiluted).HasColumnType("money");

                entity.Property(e => e.SpecialCharges).HasColumnType("money");

                entity.Property(e => e.TotalOperatingExpenses).HasColumnType("money");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.ExtractedIncomeStatements)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExtractedIncomeStatements_Companies");

                entity.HasOne(d => d.DataSource)
                    .WithMany(p => p.ExtractedIncomeStatements)
                    .HasForeignKey(d => d.DataSourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExtractedIncomeStatements_DataSources");
            });

            modelBuilder.Entity<ExtractedKeyRatio>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BookValue).HasColumnType("money");

                entity.Property(e => e.DateCreated).HasColumnType("datetime2(3)");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime2(3)");

                entity.Property(e => e.FreeCashFlow).HasColumnType("money");

                entity.Property(e => e.MarketCapitalization).HasColumnType("money");

                entity.Property(e => e.TangibleBookValue).HasColumnType("money");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.ExtractedKeyRatios)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExtractedKeyRatios_Companies");

                entity.HasOne(d => d.DataSource)
                    .WithMany(p => p.ExtractedKeyRatios)
                    .HasForeignKey(d => d.DataSourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExtractedKeyRatios_DataSources");
            });

            modelBuilder.Entity<Industry>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
