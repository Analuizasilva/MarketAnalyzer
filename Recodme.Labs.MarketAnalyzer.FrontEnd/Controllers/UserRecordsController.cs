using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.UserRecordsBO;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.UserRecordsBusinessObject;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer.Support;
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
        private readonly NoteBusinessObject _noteBO = new NoteBusinessObject();
        private readonly UserTransactionBusinessObject _userTransactionBO = new UserTransactionBusinessObject();
        private readonly StockValuesBusinessObject _stockValuesBO = new StockValuesBusinessObject();

        public UserRecordsController()
        {
            this.userTransaction = new UserTransaction();
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult UserTransactions()
        {
            var model = new UserTransactionViewModel();
            model.AspNetUserId = User.Identity.GetUserId();

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

            if (vm.ValueOfShares != null)
            {
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



                Response.Redirect("UserTransactions");
            }
            //Caso seja introduzida uma transação e o utilizador não se lembrar do value da compra
            if(vm.ValueOfShares==null && vm.NumberOfShares != null)
            {
                var stockValues = _stockValuesBO.GetStockValuesPerYear(vm.CompanyId);
                var valueInYear = stockValues.Components.Where(x => x.Year == vm.DateOfMovement.Year);
                var marketCap = valueInYear.Select(x => x.MarketCap).SingleOrDefault();
                var sharesBasic = valueInYear.Select(x => x.SharesBasic).SingleOrDefault();
                var stockValue = marketCap / sharesBasic;


                model.CompanyId = vm.CompanyId;
                model.DateOfMovement = vm.DateOfMovement;

                userTransaction.CompanyId = vm.CompanyId;
                userTransaction.DateOfMovement = vm.DateOfMovement;

                if (vm.IsAPurchaseOrSale == 0)
                {
                    model.NumberOfShares = vm.NumberOfShares;
                    model.ValueOfShares = stockValue;

                    userTransaction.NumberOfShares = vm.NumberOfShares;
                    userTransaction.ValueOfShares = stockValue;
                    userTransaction.NumberOfSharesWithdrawn = 0;
                    userTransaction.ValueOfSharesWithdrawn = 0;
                }
                else
                {
                    model.NumberOfSharesWithdrawn = vm.NumberOfShares;
                    model.ValueOfSharesWithdrawn = stockValue;

                    userTransaction.NumberOfShares = 0;
                    userTransaction.ValueOfShares = 0;
                    userTransaction.NumberOfSharesWithdrawn = vm.NumberOfShares;
                    userTransaction.ValueOfSharesWithdrawn = stockValue;
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



                Response.Redirect("UserTransactions");
            }

            if (vm.ValueOfShares == null)
            {

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
                weightMultiplier.AspNetUserId = User.Identity.GetUserId();


                var createWeightMultiplierOperation = _weightMultiplierBO.Create(weightMultiplier);

                Response.Redirect("UserTransactions");


                //...
            }


            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public void RedirectToUserTransactions()
        {
            Response.Redirect("UserTransactions");
        }




        [HttpGet]
        public IActionResult UserSettings()
        {

            var model = new UserSettingsViewModel();

            model.AspNetUserId = User.Identity.GetUserId();
            var result = _noteBO.List().Result;

            model.Notes = result;


            //model.CompanyId = vm.CompanyId;
            //model.Note = vm.Note;


            //note.CompanyId = vm.CompanyId;
            //note.Description = vm.Note;

            //note.AspNetUserId = User.Identity.GetUserId();


            //var createNoteOperation = _noteBO.Create(note);

            //Response.Redirect("UserSettings");


            return View(model);
        }


        [HttpPost]
        public IActionResult UserSettings(UserSettingsViewModel vm)
        {

            var model = new UserSettingsViewModel();
            var note = new Note();


            model.AspNetUserId = vm.AspNetUserId;
            model.CompanyId = vm.CompanyId;
            model.Note = vm.Note;


            note.CompanyId = vm.CompanyId;
            note.Description = vm.Note;
            note.AspNetUserId = User.Identity.GetUserId();


            var createNoteOperation = _noteBO.Create(note);

            return View(model);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
