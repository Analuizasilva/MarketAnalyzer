using Recodme.Labs.MarketAnalyzer.DataAccessLayer.Base;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects
{
    public class DataBaseBusinessObject
    {

        public List<ExtractedBalanceSheet> GetBalanceSheets()
        {
            var dao = new BaseDataAccessObject<ExtractedBalanceSheet>();
            return dao.List();
        }

        public void GetDataBaseData()
        {



            var result = new BaseDataAccessObject<T>();

           // result.Create()

        }
    }
}
