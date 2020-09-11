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

            var transactions3 = (from userTransaction in _context.UserTransactions
                                 where userTransaction.AspNetUserId == userId
                                 group userTransaction.Id by userTransaction.CompanyId into grouped
                                 select new { CompanyId = grouped.Key, Count = grouped.Count() }).ToList();

            var transactions2 = (from u in (from userTransaction in _context.UserTransactions
                                            where userTransaction.AspNetUserId == userId
                                            select userTransaction).ToList()
                                 group u by u.CompanyId into grouped
                                 select new CompanyUserTransactionsPoco
                                 {
                                     UserId = userId,
                                     CompanyId = grouped.Key,
                                     UserTransactions = grouped.ToList()
                                 });

            //group userTransaction by userTransaction.CompanyId into grouped
            //select new CompanyUserTransactionsPoco
            //{
            //    UserId = userId,
            //    CompanyId = grouped.Key,
            //    UserTransactions = grouped.ToList()
            //}
            //);

            var transactions = (from a in _context.UserTransactions.AsEnumerable()
                                where a.AspNetUserId == userId

                                group a by a.CompanyId into grouped
                                select new CompanyUserTransactionsPoco
                                {
                                    UserId = userId,
                                    CompanyId = grouped.Key,
                                    UserTransactions = grouped.ToList()
                                }
                              );

            var completed = (from a in transactions.ToList()
                             join company in _context.Companies.ToList()
                             on a.CompanyId equals company.Id
                             select new CompanyUserTransactionsPoco
                             {
                                 CompanyId = a.CompanyId,
                                 CompanyName = company.Name,
                                 UserTransactions = a.UserTransactions,
                                 Ticker = company.Ticker,
                                 UserId = a.UserId,
                                 StockPrice = company.StockPrice
                             }
                             ).ToList();

            return completed;
        }
    }
}