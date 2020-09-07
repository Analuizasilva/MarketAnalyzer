using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
using Recodme.Labs.MarketAnalyzer.FrontEnd.Models;
using Recodme.Labs.MarketAnalyzer.FrontEnd.Models.Home;
using Recodme.Labs.MarketAnalyzer.FrontEnd.Models.Support;
using Recodme.Labs.MarketAnalyzer.FrontEnd.Models.UserRecords;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace Recodme.Labs.MarketAnalyzer.FrontEnd.Controllers
{
    public class UserTransactionController : Controller
    {
        private readonly UserTransaction userTransaction;


        public UserTransactionController()
        {
            this.userTransaction = new UserTransaction();
        }

        [HttpGet]
        public IActionResult UserTransactions()
        {
            var model = new UserTransactionViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult UserTransactions(UserTransactionViewModel vm)
        {
            var model = new UserTransactionViewModel();

            return View(model);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
