using Recodme.Labs.MarketAnalyzer.DataLayer.Context;
using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer.Support;

namespace Recodme.Labs.MarketAnalyzer.DataAccessLayer
{
    public class UserTransactionDataAccessObject
    {
        public List<CompanyUserTransactionsPoco> GetUserCompanyTransactions(string userId) //retorna a lista de UserTransactions para um determinado user e para uma empresa
        {
            
            var companiesUserTransactions = new List<CompanyUserTransactionsPoco>();

            var _context = new MarketAnalyzerDBContext();
            var transactionsList = new List<UserTransaction>();

            var transactions = (from a in _context.UserTransactions.AsEnumerable()

                                join company in _context.Companies.AsEnumerable()
                                on a.CompanyId equals company.Id

                                where a.AspNetUserId == userId
                                
                                group a by company into grouped
                                select new CompanyUserTransactionsPoco
                                {
                                    UserId = userId,
                                    CompanyId = grouped.Key.Id,
                                    CompanyName = grouped.Key.Name,
                                    Ticker = grouped.Key.Ticker,
                                    StockPrice = grouped.Key.StockPrice,
                                    UserTransactions = grouped.ToList()
                                }
                                

                              ).ToList() ;
            
            return transactions;
        }
    }
}
