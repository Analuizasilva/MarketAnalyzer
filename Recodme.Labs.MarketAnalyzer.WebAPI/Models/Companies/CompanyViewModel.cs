using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.WebAPI.Models.Companies
{
    public class CompanyViewModel
    {
        public IActionResult CompanyInfo(Guid companyId)
        {
            //vai buscar info da company ao business
            //cria viewModel e preenche com dados
            //passa viewModel para a view
            return View();
        }
    }
}
