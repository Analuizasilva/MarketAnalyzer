//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
//using Recodme.Labs.MarketAnalyzer.DataAccessLayer.Properties;
//using Recodme.Labs.MarketAnalyzer.DataLayer;

//namespace DataAccessLayer.Contexts
//{
//    public class Context : IdentityDbContext
//    {
//        private readonly string _connectionString = string.Empty;

//        public Context() : base() { }

//        public Context(DbContextOptions<Context> options) : base(options)
//        {

//        }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//                if (_connectionString == string.Empty)
//                {
//                    optionsBuilder.UseSqlServer(Resources.ConnectionString);
//                }
//                else
//                {
//                    optionsBuilder.UseSqlServer(_connectionString);
//                }
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);
//        }

//        public DbSet<Company> Companies { get; set; }
//        public DbSet<BalanceSheet> BalanceSheets { get; set; }
//        public DbSet<CashFlowStatement> CashFlowStatements { get; set; }
//        public DbSet<CashFlowStatementTTM> CashFlowStatementsTTM { get; set; }
//        public DbSet<IncomeStatement> IncomeStatements { get; set; }
//        public DbSet<IncomeStatementTTM> IncomeStatementsTTM { get; set; }
//        public DbSet<KeyRatio> KeyRatios { get; set; }

//    }
//}
