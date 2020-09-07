using Recodme.Labs.MarketAnalyzer.FrontEnd.Models.Support;
using System.Collections.Generic;

namespace Recodme.Labs.MarketAnalyzer.FrontEnd.Models.Company
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

