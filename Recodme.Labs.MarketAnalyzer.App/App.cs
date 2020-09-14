using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.Context;
using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
using Recodme.Labs.MarketAnalyzer.Scraping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.App
{
    public class App
    {
        public async Task Run()
        {
            //var curId = new Guid("C8F69E60-5DD3-4940-A200-C5F03EC33DB4");
            var userId = "d7370f8b-bc60-45ed-b8b4-53e57ba43c56";

            var dao = new UserTransactionDataAccessObject();
           var result=dao.GetWeightMultipliers(userId);

            //var bo = new PortfolioBusinessObject();
            //bo.GetUserPortfolio(userId);

            //using var _ctx = new MarketAnalyzerDBContext();
            //_ctx.Database.EnsureCreated();
            //var aircanada = Guid.Parse("764C80B1-6084-4EA9-A282-0010F14C0C69");
            //var fibrauno = Guid.Parse("E8D2583B-4806-4B3A-BF41-003F80866AD4");
            //var toppan = Guid.Parse("4E98576D-FCAE-4F7B-9BBE-00502B494D2F");

            //var _userTransactions = new List<UserTransaction>()
            //{
            //    new UserTransaction(1,23, 1, 234,DateTime.Now,aircanada, userId),
            //    new UserTransaction(2,234, 1, 234,DateTime.Now,aircanada, userId),
            //    new UserTransaction(5,23, 1, 234,DateTime.Now,fibrauno, userId),
            //    new UserTransaction(1,23, 1, 234,DateTime.Now,fibrauno, userId),
            //    new UserTransaction(6,23, 1, 234,DateTime.Now,toppan, userId),
            //    new UserTransaction(1,23, 1, 234,DateTime.Now,toppan, userId),
            //    new UserTransaction(4,23, 1, 234,DateTime.Now,aircanada, userId),
            //    new UserTransaction(2,23, 1, 234,DateTime.Now,aircanada, userId)

            //};
            //_ctx.UserTransactions.AddRange(_userTransactions);
            //_ctx.SaveChanges();
        }
    }
}