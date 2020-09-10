//using Recodme.Labs.MarketAnalyzer.Analysis;
//using Recodme.Labs.MarketAnalyzer.Analysis.Support;
//using Recodme.Labs.MarketAnalyzer.BusinessLayer.Support;
//using Recodme.Labs.MarketAnalyzer.DataAccessLayer;
//using Recodme.Labs.MarketAnalyzer.DataLayer;
//using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects
//{
//    public class PortfolioBusinessObject
//    {
//        public PortfolioPoco GetUserPortfolio(string userId)
//        {
//            var porfolio = new PortfolioPoco();
//            var dao = new UserTransactionDataAccessObject();
//            var companiesUserTransactions = dao.GetUserCompanyTransactions(userId);

//            var analysis = new TransactionAnalysis();
//            var companiesTransactionsCalculusList = new List<CompanyTransactions>();

//            foreach (var companyTransactions in companiesUserTransactions)
//            {
//                var companyTransactionsCalculus = analysis.GetUserCompanyTransactions(companyTransactions.UserTransactions, companyTransactions.CompanyId);
//                companiesTransactionsCalculusList.Add(companyTransactionsCalculus);
//            }

//            var totals = analysis.GetTotalTransactions(companiesTransactionsCalculusList);

//            porfolio.UserId = userId;
//            porfolio.CompaniesTransactions = companiesTransactionsCalculusList;
//            porfolio.TotalTransactions = totals;

//            return porfolio;
//        }
//    }
//}
