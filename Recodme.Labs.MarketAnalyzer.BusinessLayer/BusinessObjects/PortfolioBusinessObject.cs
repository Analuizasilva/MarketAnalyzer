using Recodme.Labs.MarketAnalyzer.BusinessLayer.Support;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects
{
    public class PortfolioBusinessObject
    {
        public PortfolioPoco GetUserPortfolio(string userId)
        {
            var portfolioPoco = new PortfolioPoco();
            //portfolioPoco.UserId = userId;
            //var dao = new UserTransactionDataAccessObject();

            //var relashionships = dao.GetUserCompanyRelashionships(userId);
            //var userTransactionsList = new List<UserTransaction>();
            //foreach(var r in relashionships)
            //{
            //    portfolioPoco.CompanyId = r.CompanyId;
            //    portfolioPoco.UserTransactions.AddRange(r.UserTransactions);
            //}




            return portfolioPoco;
        }
    }
}
