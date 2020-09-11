using Recodme.Labs.MarketAnalyzer.FrontEnd.Models.Support;
using System.Collections.Generic;

namespace Recodme.Labs.MarketAnalyzer.FrontEnd.Models.CompanyDetails
{
    public class CompanyDetailsViewModel
    {
        public CompanyDetailsViewModel()
        {
            this.DetailsDataPocos = new List<DetailsDataPoco>();
        }

        public List<DetailsDataPoco> DetailsDataPocos { get; set; }
    }
}

