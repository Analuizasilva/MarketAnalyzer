using Microsoft.Ajax.Utilities;
using Recodme.Labs.MarketAnalyzer.Analysis;
using Recodme.Labs.MarketAnalyzer.Analysis.Support;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer.Base;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.App
{
    public class App
    {
        public async Task Run()
        {
            var dao = new CompanyDataAccessObject();
            var companiesDataPoco = dao.GetCompaniesInfo();
            var count = 0;
            var list = new List<Poco>();
            foreach (var companyDataPoco in companiesDataPoco)
            {
                var stockAnalysis = new StockAnalysis(companyDataPoco);
                var stockFitness = new StockFitness(stockAnalysis);
                var total = stockFitness.TotalFitness;
                if (total != null)
                {
                    list.Add(new Poco { CP = companyDataPoco, Fitness = total });
                    count++;
                }
                //Console.WriteLine(companyDataPoco.Company.Ticker + " " + total);
            }
            foreach (var item in list.OrderBy(l => l.Fitness))
            {
                Console.WriteLine(item.CP.Company.Ticker + " " + item.Fitness);
            }
            Console.WriteLine(count + " " + "Companies");
        }
        public class Poco
        {
            public CompanyDataPoco CP { get; set; }
            public double? Fitness { get; set; }
        }
    }
    }
}