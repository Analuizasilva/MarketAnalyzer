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

        public DbSet<Company> Companies { get; set; }
        public DbSet<DataSource> DataSources { get; set; }
        public DbSet<ExtractedBalanceSheet> ExtractedBalanceSheets { get; set; }
        public DbSet<ExtractedCashFlowStatementTtm> ExtractedCashFlowStatementTtms { get; set; }
        public DbSet<ExtractedCashFlowStatement> ExtractedCashFlowStatements { get; set; }
        public DbSet<ExtractedIncomeStatementTtm> ExtractedIncomeStatementTtms { get; set; }
        public DbSet<ExtractedIncomeStatement> ExtractedIncomeStatements { get; set; }
        public DbSet<ExtractedKeyRatio> ExtractedKeyRatios { get; set; }
        public DbSet<Industry> Industries { get; set; }
        //public DbSet<UserTransaction> UserTransactions { get; set; }

    }
}
