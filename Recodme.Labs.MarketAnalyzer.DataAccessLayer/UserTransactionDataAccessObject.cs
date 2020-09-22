using Recodme.Labs.MarketAnalyzer.DataAccessLayer.Support;
using Recodme.Labs.MarketAnalyzer.DataLayer.Context;
using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recodme.Labs.MarketAnalyzer.DataAccessLayer
{
    public class UserTransactionDataAccessObject
    {
        public StockValuePoco GetStockValuePerYear(Guid companyId)
        {
            var _context = new MarketAnalyzerDBContext();
            var stockValue = (from k in _context.ExtractedKeyRatios
                              where k.CompanyId == companyId
                              join income in _context.ExtractedIncomeStatements
                              on new { k.CompanyId, k.Year } equals new { income.CompanyId, income.Year }

                              select new StockValueComponents
                              {
                                  Year = k.Year,
                                  MarketCap = k.MarketCapitalization,
                                  SharesBasic = income.SharesBasic
                              }
                              ).OrderBy(x => x.Year).ToList();

            var stockValuesPerCompany = new StockValuePoco();
            stockValuesPerCompany.Components = stockValue;
            stockValuesPerCompany.CompanyId = companyId;
            return stockValuesPerCompany;
        }
        public List<WeightMultiplier> GetWeightMultipliers(string userId)
        {
            var _context = new MarketAnalyzerDBContext();

            var weight = (from w in _context.WeightMultipliers
                          where w.AspNetUserId == userId
                          select new WeightMultiplier
                          {
                              WeightNumberRoic = w.WeightNumberRoic,
                              WeightNumberEquity = w.WeightNumberEquity,
                              WeightNumberEPS = w.WeightNumberEPS,
                              WeightNumberRevenue = w.WeightNumberRevenue,
                              WeightNumberPERatio = w.WeightNumberPERatio,
                              WeightNumberDebtToEquity = w.WeightNumberDebtToEquity,
                              WeightNumberAssetsToLiabilities = w.WeightNumberAssetsToLiabilities
                          }).ToList();
            return weight;
        }
        public List<CompanyUserTransactionsPoco> GetUserCompanyTransactions(string userId) //retorna a lista de UserTransactions para um determinado user e para uma empresa
        {
            var companiesUserTransactions = new List<CompanyUserTransactionsPoco>();

            var _context = new MarketAnalyzerDBContext();
            var transactionsList = new List<UserTransaction>();

            var transactions = (from transactionCompany in (from userTransaction in _context.UserTransactions
                                                            where userTransaction.AspNetUserId == userId
                                                            join company in _context.Companies
                                                            on userTransaction.CompanyId equals company.Id
                                                            select new { UserTransaction = userTransaction, Company = company }).ToList()
                                    //select new { UserTransactionId = userTransaction.Id, UserTransaction}
                                group transactionCompany by transactionCompany.Company into grouped
                                select new CompanyUserTransactionsPoco
                                {
                                    Company = grouped.Key,
                                    UserTransactions = grouped.Select(u => u.UserTransaction).ToList(),
                                    UserId = userId,
                                }).ToList();

            return transactions;
        }

        public List<Note> GetUserNotes(string userId)
        {
            var _context = new MarketAnalyzerDBContext();

            var notes = _context.Notes.Where(n => n.AspNetUserId == userId).ToList();

            return notes;
        }
    }
}