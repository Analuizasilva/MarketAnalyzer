namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects
{
    public class SlickChartsBO
    {
        public async Task ScrapeAndStoreData()
        {
            var scrapper = new SlickChartsScrapper();
            var companies = scrapper.ScrapeCompanies();

            var dataAccessDao = new BaseDataAccessObject<Company>();
            var dbCompanies = dataAccessDao.GetDataBaseCompanies();

            var companiesToAdd = companies.Where(c => !dbCompanies.Any(dbc => dbc.Ticker == c.Ticker)).ToList();
            var companiesToUpdate = companies.Where(c => dbCompanies.Any(dbc => dbc.Ticker == c.Ticker)).ToList();

            dataAccessDao.AddListAsync(companiesToAdd);

            foreach (var company in dbCompanies)
            {
                company.Rank = 0;
            }

            foreach (var company in companies)
            {
                var companyToUpdate = dbCompanies.SingleOrDefault(c => c.Ticker == company.Ticker);
                if (companyToUpdate != null)
                {
                    companyToUpdate.Price = company.Price;
                    companyToUpdate.Rank = company.Rank;
                }
            }

            dataAccessDao.UpdateListAsync(dbCompanies);
        }
    }
}