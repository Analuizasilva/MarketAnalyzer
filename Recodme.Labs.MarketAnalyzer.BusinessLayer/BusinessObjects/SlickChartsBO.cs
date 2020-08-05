using Recodme.Labs.MarketAnalyzer.DataAccessLayer.Base;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.Scrapping;
using System.Linq;
using System.Threading.Tasks;

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

            await dataAccessDao.AddListAsync(companiesToAdd);

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
            await dataAccessDao.UpdateListAsync(dbCompanies);
        }
    }
}