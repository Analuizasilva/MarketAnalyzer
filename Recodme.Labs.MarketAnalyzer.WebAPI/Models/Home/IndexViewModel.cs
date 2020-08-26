using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.Pocos;
using Recodme.Labs.MarketAnalyzer.WebAPI.Models.Support;
using static Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.AnalysisBusinessObject;

namespace Recodme.Labs.MarketAnalyzer.WebAPI.Models.Home
{
    public class IndexViewModel
    {
        public List<HomeDataPoco> HomeDataPocos { get; set; }
        public IndexViewModel()
        {
            HomeDataPocos = new List<HomeDataPoco>();
        }


    }
}
