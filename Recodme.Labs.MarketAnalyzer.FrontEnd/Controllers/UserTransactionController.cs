using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.UserRecordsBO;
using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
using Recodme.Labs.MarketAnalyzer.FrontEnd.Models;
using Recodme.Labs.MarketAnalyzer.FrontEnd.Models.Home;
using Recodme.Labs.MarketAnalyzer.FrontEnd.Models.Support;
using Recodme.Labs.MarketAnalyzer.FrontEnd.Models.UserRecords;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.FrontEnd.Controllers
{
    public class UserTransactionController : Controller
    {
        private readonly UserTransaction userTransaction;

        private readonly WeightMultiplierBusinessObject _bo = new WeightMultiplierBusinessObject();



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

        //[HttpGet]
        //public IActionResult UserSettings()
        //{
        //    var model = new UserSettingsViewModel();

        //    return View(model);
        //}


        [HttpGet]
        public async Task<IActionResult> UserSettings()
        {

            var model = new UserSettingsViewModel();

            return View(model);
        }

            //[HttpPost]
            //public IActionResult UserSettings(UserSettingsViewModel vm)
            //{
            //    var model = new UserSettingsViewModel();
            //    model.WeightNumberAssetsToLiabilities = vm.WeightNumberAssetsToLiabilities;
            //    model.WeightNumberDebtToEquity = vm.WeightNumberDebtToEquity;
            //    model.WeightNumberEPS = vm.WeightNumberEPS;
            //    model.WeightNumberEquity = vm.WeightNumberEquity;
            //    model.WeightNumberPERatio = vm.WeightNumberPERatio;
            //    model.WeightNumberRevenue = vm.WeightNumberRevenue;
            //    model.WeightNumberRoic = vm.WeightNumberRoic;

            //    return View(model);
            //}

        [HttpPost]
        public IActionResult UserSettings(UserSettingsViewModel vm)
        {
            var model = new UserSettingsViewModel();
            var weightMultiplier = new WeightMultiplier();



            model.WeightNumberAssetsToLiabilities = vm.WeightNumberAssetsToLiabilities;
            model.WeightNumberDebtToEquity = vm.WeightNumberDebtToEquity;
            model.WeightNumberEPS = vm.WeightNumberEPS;
            model.WeightNumberEquity = vm.WeightNumberEquity;
            model.WeightNumberPERatio = vm.WeightNumberPERatio;
            model.WeightNumberRevenue = vm.WeightNumberRevenue;
            model.WeightNumberRoic = vm.WeightNumberRoic;



            weightMultiplier.WeightNumberAssetsToLiabilities = vm.WeightNumberAssetsToLiabilities;
            weightMultiplier.WeightNumberDebtToEquity = vm.WeightNumberDebtToEquity;
            weightMultiplier.WeightNumberEPS = vm.WeightNumberEPS;
            weightMultiplier.WeightNumberEquity = vm.WeightNumberEquity;
            weightMultiplier.WeightNumberPERatio = vm.WeightNumberPERatio;
            weightMultiplier.WeightNumberRevenue = vm.WeightNumberRevenue;
            weightMultiplier.WeightNumberRoic = vm.WeightNumberRoic;



            var createOperation = _bo.Create(weightMultiplier);

            return View(model);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
