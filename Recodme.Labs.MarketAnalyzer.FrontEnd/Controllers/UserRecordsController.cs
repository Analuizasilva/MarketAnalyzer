using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.UserRecordsBO;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.UserRecordsBusinessObject;
using Recodme.Labs.MarketAnalyzer.DataLayer;
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
    [Authorize]
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
        public IActionResult UserTransactions(IndexViewModel vm)
        {
            var model = new UserTransactionViewModel();
            model.AspNetUserId = User.Identity.GetUserId();

            var portfolioBusiness = new PortfolioBusinessObject();
            var result = portfolioBusiness.GetUserPortfolio(User.Identity.GetUserId());

            model.CompaniesTransactions = result.CompaniesTransactions;
            model.TotalTransactions = result.TotalTransactions;

            var analysis = new AnalysisBusinessObject();
            var stockItemPocos = analysis.GetStockData(vm.WeightNumberRoic, vm.WeightNumberEquity, vm.WeightNumberEPS, vm.WeightNumberRevenue, vm.WeightNumberPERatio, vm.WeightNumberDebtToEquity, vm.WeightNumberAssetsToLiabilities);
            var companyList = new List<Company>();
            foreach(var item in stockItemPocos)
            {
                var company = item.CompanyDataPoco.Company;
                companyList.Add(company);
            }
            model.Companies = companyList;

            ViewBag.CompanyNames = model.Companies.Select(company => new SelectListItem() { Text = company.Name, Value = company.Id.ToString() });

            model.WeightNumberRoic = Convert.ToDouble(vm.WeightNumberRoic, CultureInfo.InvariantCulture);
            model.WeightNumberEquity = Convert.ToDouble(vm.WeightNumberEquity, CultureInfo.InvariantCulture);
            model.WeightNumberEPS = Convert.ToDouble(vm.WeightNumberEPS, CultureInfo.InvariantCulture);
            model.WeightNumberRevenue = Convert.ToDouble(vm.WeightNumberRevenue, CultureInfo.InvariantCulture);
            model.WeightNumberPERatio = Convert.ToDouble(vm.WeightNumberPERatio, CultureInfo.InvariantCulture);
            model.WeightNumberDebtToEquity = Convert.ToDouble(vm.WeightNumberDebtToEquity, CultureInfo.InvariantCulture);
            model.WeightNumberAssetsToLiabilities = Convert.ToDouble(vm.WeightNumberAssetsToLiabilities, CultureInfo.InvariantCulture);

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult UserTransactions(UserTransactionViewModel vm)
        {
            var model = new UserTransactionViewModel();
            var userTransaction = new UserTransaction();

            userTransaction.AspNetUserId = User.Identity.GetUserId();
            model.AspNetUserId = User.Identity.GetUserId();

            model.CompanyId = vm.CompanyId;
            model.DateOfMovement = vm.DateOfMovement;

            userTransaction.CompanyId = vm.CompanyId;
            userTransaction.DateOfMovement = vm.DateOfMovement;

            if (vm.IsAPurchaseOrSale == 0)
            {
                model.NumberOfShares = vm.NumberOfShares;
                model.ValueOfShares = vm.ValueOfShares;

                userTransaction.NumberOfShares = vm.NumberOfShares;
                userTransaction.ValueOfShares = vm.ValueOfShares;
                userTransaction.NumberOfSharesWithdrawn = 0;
                userTransaction.ValueOfSharesWithdrawn = 0;
            }
            else
            {
                model.NumberOfSharesWithdrawn = vm.NumberOfShares;
                model.ValueOfSharesWithdrawn = vm.ValueOfShares;

                userTransaction.NumberOfShares = 0;
                userTransaction.ValueOfShares = 0;
                userTransaction.NumberOfSharesWithdrawn = vm.NumberOfShares;
                userTransaction.ValueOfSharesWithdrawn = vm.ValueOfShares;
            }
            
            var portfolioBusiness = new PortfolioBusinessObject();
            var result = portfolioBusiness.GetUserPortfolio(User.Identity.GetUserId());

            model.CompaniesTransactions = result.CompaniesTransactions;
            model.TotalTransactions = result.TotalTransactions;

            var analysis = new AnalysisBusinessObject();
            var stockItemPocos = analysis.GetStockData();
            var companyList = new List<Company>();
            foreach (var item in stockItemPocos)
            {
                var company = item.CompanyDataPoco.Company;
                companyList.Add(company);
            }
            model.Companies = companyList;

            ViewBag.CompanyNames = model.Companies.Select(company => new SelectListItem() { Text = company.Name, Value = company.Id.ToString() });


            var createOperation = _userTransactionBO.Create(userTransaction);

            // Settings
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
            weightMultiplier.AspNetUserId = vm.AspNetUserId;

            var createWeightMultiplierOperation = _weightMultiplierBO.Create(weightMultiplier);

            //...


            return View(model);
        }

        //[HttpGet]
        //public IActionResult UserSettings()
        //{

        //    var model = new UserSettingsViewModel();

        //    return View(model);
        //}

        //[HttpPost]
        //public IActionResult UserSettings(UserSettingsViewModel vm)
        //{
        //    var model = new UserSettingsViewModel();
        //    var weightMultiplier = new WeightMultiplier();



        //    model.WeightNumberAssetsToLiabilities = vm.WeightNumberAssetsToLiabilities;
        //    model.WeightNumberDebtToEquity = vm.WeightNumberDebtToEquity;
        //    model.WeightNumberEPS = vm.WeightNumberEPS;
        //    model.WeightNumberEquity = vm.WeightNumberEquity;
        //    model.WeightNumberPERatio = vm.WeightNumberPERatio;
        //    model.WeightNumberRevenue = vm.WeightNumberRevenue;
        //    model.WeightNumberRoic = vm.WeightNumberRoic;


        //    weightMultiplier.WeightNumberAssetsToLiabilities = vm.WeightNumberAssetsToLiabilities;
        //    weightMultiplier.WeightNumberDebtToEquity = vm.WeightNumberDebtToEquity;
        //    weightMultiplier.WeightNumberEPS = vm.WeightNumberEPS;
        //    weightMultiplier.WeightNumberEquity = vm.WeightNumberEquity;
        //    weightMultiplier.WeightNumberPERatio = vm.WeightNumberPERatio;
        //    weightMultiplier.WeightNumberRevenue = vm.WeightNumberRevenue;
        //    weightMultiplier.WeightNumberRoic = vm.WeightNumberRoic;


        //    var createOperation = _weightMultiplierBO.Create(weightMultiplier);

        //    return View(model);
        //}




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
