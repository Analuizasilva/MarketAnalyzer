using Recodme.Labs.MarketAnalyzer.DataAccessLayer;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer.Base;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects
{
    public class AnalysisBusinessObject
    {         
        public void AnalyseStocks()
        {
            var dao = new CompanyDataAccessObject();
            //var companies = await dao.ListAsync();
            var result = dao.GetCompaniesInfo();


        }
    }
}
