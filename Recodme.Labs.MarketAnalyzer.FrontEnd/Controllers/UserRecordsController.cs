using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.UserRecordsBO;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.UserRecordsBusinessObject;
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
    public class UserRecordsController : Controller
    {
        private readonly UserTransaction userTransaction;

        private readonly WeightMultiplierBusinessObject _weightMultiplierBO = new WeightMultiplierBusinessObject();
        private readonly UserTransactionBusinessObject _userTransactionBO = new UserTransactionBusinessObject();


        public UserRecordsController()
        {
            this.userTransaction = new UserTransaction();
        }
        

        [AllowAnonymous]
        [HttpGet]
        public IActionResult UserTransactions()
        {
            var model = new UserTransactionViewModel();
            var analysis = new AnalysisBusinessObject();
            var stockFitnessAnalysis = analysis.GetStockData();
            foreach (var stockAnalysis in stockFitnessAnalysis)
            {
                var company = stockAnalysis.CompanyDataPoco.Company;
                model.Companies.Add(company);
            }

            ViewBag.CompanyNames = model.Companies.Select(company => new SelectListItem() { Text = company.Name, Value =company.Id.ToString() });

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult UserTransactions(UserTransactionViewModel vm)
        {
            var model = new UserTransactionViewModel();
            var userTransaction = new UserTransaction();

            model.CompanyId = vm.CompanyId;
            model.NumberOfShares = vm.NumberOfShares;
            model.ValueOfShares = vm.ValueOfShares;
            model.NumberOfSharesWithdrawn = vm.NumberOfSharesWithdrawn;
            model.ValueOfSharesWithdrawn = vm.ValueOfSharesWithdrawn;
            model.DateOfMovement = vm.DateOfMovement;

            userTransaction.CompanyId = vm.CompanyId;
            userTransaction.NumberOfShares = vm.NumberOfShares;
            userTransaction.ValueOfShares = vm.ValueOfShares;
            userTransaction.NumberOfSharesWithdrawn = vm.NumberOfSharesWithdrawn;
            userTransaction.ValueOfSharesWithdrawn = vm.ValueOfSharesWithdrawn;
            userTransaction.DateOfMovement = vm.DateOfMovement;


            var createOperation = _userTransactionBO.Create(userTransaction);

            return View(model);
        }


        [HttpGet]
        public IActionResult UserSettings()
        {

            var model = new UserSettingsViewModel();

            return View(model);
        }

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


            var createOperation = _weightMultiplierBO.Create(weightMultiplier);

            return View(model);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
