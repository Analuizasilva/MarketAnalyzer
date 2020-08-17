//using Recodme.Labs.MarketAnalyzer.DataAccessLayer.Base;
//using Recodme.Labs.MarketAnalyzer.DataLayer;
//using Recodme.Labs.MarketAnalyzer.Scraping.SlickChartsScrapers;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.SlickCharts
//{
//    public class SlickChartsBO
//    {
//        public async Task ScrapeAndStoreData()
//        {
//            var scrapper = new SlickChartsScraper();
//            var companies = scrapper.ScrapeCompanies();

//            var dataAccessDao = new BaseDataAccessObject<Company>();
//            var dbCompanies = dataAccessDao.GetDataBaseCompanies();

//            var companiesToAdd = companies.Where(c => !dbCompanies.Any(dbc => dbc.Ticker == c.Ticker)).ToList();
//            //var companiesToUpdate = companies.Where(c => dbCompanies.Any(dbc => dbc.Ticker == c.Ticker)).ToList();

//            await dataAccessDao.AddListAsync(companiesToAdd);

//            foreach (var dbCompany in dbCompanies)
//            {
//                dbCompany.Rank = 0;
//            }
//            var companiesToUpdate = new List<Company>();
//            foreach (var company in companies)
//            {
//                var companyToUpdate = dbCompanies.SingleOrDefault(c => c.Ticker == company.Ticker);
//                if (companyToUpdate != null)
//                {
//                    companyToUpdate.Price = company.Price;
//                    companyToUpdate.Rank = company.Rank;
//                }
//                companiesToUpdate.Add(companyToUpdate);
//            }
//            await dataAccessDao.UpdateListAsync(companiesToUpdate);
//        }
//    }
//}