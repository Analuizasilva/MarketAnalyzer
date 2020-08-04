using DataAccessLayer.Contexts;
using Recodme.Labs.MarketAnalyzer.BusinessLayer;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.Scrapping;

namespace Recodme.Labs.MarketAnalyzer.App
{
    class Program
    {
        static void Main(string[] args)
        {

            var ctx = new Context();
            ctx.Database.EnsureCreated();

            var scrap = new Scrap();
            scrap.GetInfo();

            var bo = new  BusinessObject<Company>();
            bo.CompanyVerification();
        }
    }
}
