using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.UserRecordsBO;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer;
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




            var dao = new UserTransactionDataAccessObject();
            //var result=dao.GetWeightMultipliers(userId);

            //_ctx.Database.EnsureCreated();


            //var bo = new PortfolioBusinessObject();
            //bo.GetUserPortfolio(userId);
            //var aircanada = Guid.Parse("764C80B1-6084-4EA9-A282-0010F14C0C69");
            //var fibrauno = Guid.Parse("E8D2583B-4806-4B3A-BF41-003F80866AD4");
            //var toppan = Guid.Parse("4E98576D-FCAE-4F7B-9BBE-00502B494D2F");

            using var _ctx = new MarketAnalyzerDBContext();

            //var newBO = new NoteBusinessObject();
            //var listOfNotes = newBO.List();


            //var userId = "d7370f8b-bc60-45ed-b8b4-53e57ba43c56";
            var newcompanyId = Guid.Parse("390E3C86-A52B-4FAA-97DD-30D9EBE65236");
            var result = dao.GetStockValuePerYear(newcompanyId);

            //var _userNote = new List<Note>()
            //{
            //    new Note("Very good", newcompanyId , userId),
            //    new Note("Not so good", newcompanyId , userId),
            //    new Note("Yes!", newcompanyId , userId)
            //};
            //_ctx.Notes.AddRange(_userNote);
            //_ctx.SaveChanges();

            
        }
    }
}