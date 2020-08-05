namespace Recodme.Labs.MarketAnalyzer.App
{
    public class App
    {
        public async Task Run()
        {
            var ctx = new Context();
            ctx.Database.EnsureCreated();

            var scrap = new ScrapedCompanies();

            var bo = new BusinessObject<Company>();
            bo.AddAndUpdateCompanies(scrap.GetInfoSlick());
        }
    }
}