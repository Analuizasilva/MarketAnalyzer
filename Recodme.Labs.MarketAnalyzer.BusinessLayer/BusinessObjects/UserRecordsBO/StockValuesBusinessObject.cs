using Recodme.Labs.MarketAnalyzer.DataAccessLayer;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer.Support;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.UserRecordsBO
{
    public class StockValuesBusinessObject
    {
        public StockValuePoco GetStockValuesPerYear(Guid companyId)
        {
            var dao = new UserTransactionDataAccessObject();
            var stockValues = dao.GetStockValuePerYear(companyId);
            return stockValues;
        }
    }
}
