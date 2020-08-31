using Recodme.Labs.MarketAnalyzer.DataLayer.Pocos;
using Recodme.Labs.MarketAnalyzer.WebAPI.Models.Support;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Recodme.Labs.MarketAnalyzer.WebAPI.Models.Company
{
    public class CompanyViewModel
    {
        public CompanyViewModel()
        {
            this.DetailsDataPocos = new List<DetailsDataPoco>();
        }

        public List<DetailsDataPoco> DetailsDataPocos { get; set; } 
    }
}

