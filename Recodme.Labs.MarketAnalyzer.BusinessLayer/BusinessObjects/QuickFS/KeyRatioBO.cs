using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.QuickFS
{
    public class KeyRatioBO
    {
        public async Task ScrapeAndStoreData()
        {
            var scrapper = new ();
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
