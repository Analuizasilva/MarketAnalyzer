using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.UserRecordsBO;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.UserRecordsBusinessObject;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
using Recodme.Labs.MarketAnalyzer.FrontEnd.Models;
using Recodme.Labs.MarketAnalyzer.FrontEnd.Models.UserRecords;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Recodme.Labs.MarketAnalyzer.FrontEnd.Controllers
{
    [Authorize]
    public class UserRecordsController : Controller
    {
        private readonly UserTransaction userTransaction;

        private readonly WeightMultiplierBusinessObject _weightMultiplierBO;
        private readonly NoteBusinessObject _noteBO;
        private readonly UserTransactionBusinessObject _userTransactionBO;
        private readonly UserTransactionViewModel model;
        private readonly AnalysisBusinessObject analysis; 


        public UserRecordsController()
        {
            this.userTransaction = new UserTransaction();
            this._noteBO = new NoteBusinessObject();
            this._weightMultiplierBO = new WeightMultiplierBusinessObject();
            this.model = new UserTransactionViewModel();
            this.analysis = new AnalysisBusinessObject();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult UserTransactions()
        {
            model.AspNetUserId = User.Identity.GetUserId();

            var portfolioBusiness = new PortfolioBusinessObject();
            var result = portfolioBusiness.GetUserPortfolio(User.Identity.GetUserId());

            model.CompaniesTransactions = result.CompaniesTransactions;
            model.TotalTransactions = result.TotalTransactions;
            var weightModel = _weightMultiplierBO.List().Result.Where(w => w.AspNetUserId == model.AspNetUserId).FirstOrDefault();

            if (weightModel != null)
            {
                model.WeightNumberAssetsToLiabilities = weightModel.WeightNumberAssetsToLiabilities;
                model.WeightNumberDebtToEquity = weightModel.WeightNumberDebtToEquity;
                model.WeightNumberEPS = weightModel.WeightNumberEPS;
                model.WeightNumberEquity = weightModel.WeightNumberEquity;
                model.WeightNumberPERatio = weightModel.WeightNumberPERatio;
                model.WeightNumberRevenue = weightModel.WeightNumberRevenue;
                model.WeightNumberRoic = weightModel.WeightNumberRoic;
            }

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

            return RedirectToAction("UserTransactions");
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WeightMultiplier(UserTransactionViewModel vm)
        {
            var weightMultiplier = new WeightMultiplier();

            var id = User.Identity.GetUserId();

            var weightModel = _weightMultiplierBO.List().Result.Where(w => w.AspNetUserId == id).FirstOrDefault();

            if (weightModel == null)
            {
                weightMultiplier.WeightNumberAssetsToLiabilities = vm.WeightNumberAssetsToLiabilities;
                weightMultiplier.WeightNumberDebtToEquity = vm.WeightNumberDebtToEquity;
                weightMultiplier.WeightNumberEPS = vm.WeightNumberEPS;
                weightMultiplier.WeightNumberEquity = vm.WeightNumberEquity;
                weightMultiplier.WeightNumberPERatio = vm.WeightNumberPERatio;
                weightMultiplier.WeightNumberRevenue = vm.WeightNumberRevenue;
                weightMultiplier.WeightNumberRoic = vm.WeightNumberRoic;
                weightMultiplier.AspNetUserId = User.Identity.GetUserId();
                _weightMultiplierBO.Create(weightMultiplier);
            }
            else
            {
                weightModel.WeightNumberAssetsToLiabilities = vm.WeightNumberAssetsToLiabilities;
                weightModel.WeightNumberDebtToEquity = vm.WeightNumberDebtToEquity;
                weightModel.WeightNumberEPS = vm.WeightNumberEPS;
                weightModel.WeightNumberEquity = vm.WeightNumberEquity;
                weightModel.WeightNumberPERatio = vm.WeightNumberPERatio;
                weightModel.WeightNumberRevenue = vm.WeightNumberRevenue;
                weightModel.WeightNumberRoic = vm.WeightNumberRoic;
                _weightMultiplierBO.Update(weightModel);
            }
            return RedirectToAction("UserTransactions");
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
