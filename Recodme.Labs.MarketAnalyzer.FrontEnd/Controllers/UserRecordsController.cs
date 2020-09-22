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
using System.Data;
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
            var model = new UserTransactionViewModel();
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
            if (vm.ValueOfShares == null && vm.NumberOfShares != null)
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

            return View(model);
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

        [AllowAnonymous]
        [HttpPost]
        public void RedirectToUserTransactions()
        {
            Response.Redirect("UserTransactions");
        }

        #region Chart Transaction       
        [HttpPost]
        public JsonResult CanvasTransaction([FromBody] string userId)
        {
            var portfolioBO = new PortfolioBusinessObject();
            var userPortifolio = portfolioBO.GetUserPortfolio(userId);

            List<object> iDados = new List<object>();

            DataTable chartTransaction = new DataTable();
            chartTransaction.Columns.Add("Year", typeof(System.String));
            chartTransaction.Columns.Add("TotalGainLoss", typeof(System.Double));
            chartTransaction.Columns.Add("GrowthPercentage", typeof(System.Double));
            chartTransaction.Columns.Add("CurrentValue", typeof(System.Double));

            if (userPortifolio.PortfolioGraphInfo != null)
            {
                foreach (var data in userPortifolio.PortfolioGraphInfo)
                {
                    chartTransaction.Rows.Add(data.Year, Math.Round((double)(data.TotalGainLoss),2), Math.Round((double)(data.GrowthPercentage), 2), Math.Round((double)(data.CurrentValue), 2)); 
                }

                foreach (DataColumn dataColumn in chartTransaction.Columns)
                {
                    List<object> totalGainLossList = new List<object>();
                    totalGainLossList = (from DataRow dataRow in chartTransaction.Rows select dataRow[dataColumn.ColumnName]).ToList();
                    iDados.Add(totalGainLossList);
                }
            }
            return Json(iDados);
        }
        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
