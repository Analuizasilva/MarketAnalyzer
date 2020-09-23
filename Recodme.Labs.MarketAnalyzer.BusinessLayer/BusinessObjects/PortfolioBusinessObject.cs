using Recodme.Labs.MarketAnalyzer.Analysis;
using Recodme.Labs.MarketAnalyzer.Analysis.Support;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.UserRecordsBO;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.Support;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer.Support;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
using System;
using System.Collections.Generic;
using System.Text;
using static Recodme.Labs.MarketAnalyzer.Analysis.TransactionAnalysis;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects
{
    public class PortfolioBusinessObject
    {
        public PortfolioPoco GetUserPortfolio(string userId)
        {
            var porfolio = new PortfolioPoco();
            var dao = new UserTransactionDataAccessObject();
            var companiesUserTransactions = dao.GetUserCompanyTransactions(userId);

            var analysis = new TransactionAnalysis();
            var companiesTransactionsCalculusList = new List<CompanyTransactions>();

            var graphInfoForCompanies = new List<StuffForGraph>();

            foreach (var companyTransactions in companiesUserTransactions)
            {
                var stocks = dao.GetStockValuePerYear(companyTransactions.Company.Id);

                var companyTransactionsCalculus = analysis.GetUserCompanyTransactions(companyTransactions.UserTransactions, companyTransactions.Company);
                companiesTransactionsCalculusList.Add(companyTransactionsCalculus);

                var graphInfoForCompany = analysis.GetGraphTotalsPerCompany(companyTransactions.UserTransactions, companyTransactions.Company, stocks);
                graphInfoForCompanies.AddRange(graphInfoForCompany);
            }

            var totals = analysis.GetTotalTransactions(companiesTransactionsCalculusList);
            var graphInfo = analysis.GetGraphTotals(graphInfoForCompanies);

            porfolio.UserId = userId;
            porfolio.CompaniesTransactions = companiesTransactionsCalculusList;
            porfolio.TotalTransactions = totals;
            porfolio.PortfolioGraphInfo = graphInfo;

            return porfolio;
        }
    }
}
