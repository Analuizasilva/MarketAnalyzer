using DataAccessLayer.Contexts;
using Recodme.Labs.MarketAnalyzer.BusinessLayer;
using Recodme.Labs.MarketAnalyzer.Scrapping;

namespace Recodme.Labs.MarketAnalyzer.App
{
    class Program
    {
        static void Main(string[] args)
        {

            var _ctx = new Context();
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();

            var scrap = new Scrap();
            scrap.GetInfo();

            var verification = new Verification();
            verification.CompanyVerification();

        }
    }
}
