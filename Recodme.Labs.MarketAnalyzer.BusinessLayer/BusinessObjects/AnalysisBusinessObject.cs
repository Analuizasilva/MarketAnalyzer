using Recodme.Labs.MarketAnalyzer.DataAccessLayer;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects
{
    public class AnalysisBusinessObject
    {
        public void AnalyseStocks()
        {
            var dao = new CompanyDataAccessObject();
            var result = dao.GetCompaniesInfo();
        }
    }
}
