using Recodme.Labs.MarketAnalyzer.DataAccessLayer.Base;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.Scraping.QuickFsScrapers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.QuickFS
{
    public class KeyRatioBO
    {
        public async Task<List<List<KeyRatio>>> ScrapKeyRatios()
        {
            var dataAccessDao = new BaseDataAccessObject<Company>();
            var keyRDataAccessDao = new BaseDataAccessObject<KeyRatio>();
            var dbCompanies = dataAccessDao.GetDataBaseCompanies();
            var allKeyRatios = new List<List<KeyRatio>>();
            var keyRatioScraper = new KeyRatioScraper();

            foreach (var company in dbCompanies)
            {

                var ticker = company.Ticker;

                await Task.Delay(TimeSpan.FromSeconds(2));
                var keyRatio = await keyRatioScraper.ScrapeKeyRatio(ticker, HelperVars.QuickFsApiKey);

                foreach (var incs in keyRatio)
                {
                    incs.CompanyId = company.Id;
                    Console.WriteLine(ticker + " " + incs.Year + " " + incs.Revenue);
                }
                await keyRDataAccessDao.AddListAsync(keyRatio);
                allKeyRatios.Add(keyRatio);

            }
            return allKeyRatios;
        }

    }
}
