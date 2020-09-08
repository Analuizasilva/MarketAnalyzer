using Recodme.Labs.MarketAnalyzer.DataLayer.Context;
using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Recodme.Labs.MarketAnalyzer.DataAccessLayer
{
    public class UserTransactionDataAccessObject
    {
        //public List<UserTransaction> GetUserCompanyTransactions() //retorna a lista de UserTransactions para um determinado user e para uma empresa
        //{
        //    var userTransactions = new List<UserTransaction>();
        //    var userTransaction = new UserTransaction();
        //    var _context = new MarketAnalyzerDBContext();

        //    foreach(var t in _context.UserTransactions)
        //    {
        //        userTransaction.NumberOfShares = t.NumberOfShares;
        //        userTransaction.ValueOfShares = t.ValueOfShares;
        //        userTransaction.NumberOfSharesWithdrawn = t.NumberOfSharesWithdrawn;
        //        userTransaction.ValueOfSharesWithdrawn = t.ValueOfSharesWithdrawn;
        //        userTransaction.DateOfMovement = t.DateOfMovement;
        //        userTransaction.CompanyUserRelationship = t.CompanyUserRelationship;
        //        userTransaction.CompanyUserRelationshipId = t.CompanyUserRelationshipId;
        //        userTransactions.Add(userTransaction);
        //    }
            
        //    return userTransactions;
        //}
    }
}
