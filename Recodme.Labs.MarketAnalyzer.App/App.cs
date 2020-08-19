using Microsoft.Ajax.Utilities;
using Recodme.Labs.MarketAnalyzer.Analysis;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer.Base;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.App
{
    public class App
    {
        public async Task Run()
        {
            var dataAccessObjKeyRatios = new BaseDataAccessObject<ExtractedKeyRatio>();
            var keyRatiosDB = dataAccessObjKeyRatios.GetDataBaseKeyRatios();

            var companyDAO = new BaseDataAccessObject<Company>();
            var companyDB = companyDAO.GetDataBaseCompanies();



            foreach (var company in companyDB)
            {
                if (company.Ticker == "AAPL")
                {
                    var companyId = company.Id;

                    var financialAnalysis = new FinancialAnalysis();
                    var roic = (financialAnalysis.GetRoic(keyRatiosDB, companyId));
                }

            }

        }
    }
}