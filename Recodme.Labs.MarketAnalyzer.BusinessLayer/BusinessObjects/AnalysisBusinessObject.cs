using Recodme.Labs.MarketAnalyzer.Analysis;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects
{
    public class AnalysisBusinessObject
    {
        public List<Poco> GetStockFitness()
        {
            var dao = new CompanyDataAccessObject();
            var companiesDataPoco = dao.GetCompaniesInfo();
            var count = 1;
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
            }
            var rank = 1;
            foreach (var item in list.OrderByDescending(l => l.Fitness))
            {
                item.MarketAnalyzerRank = rank;
                Console.WriteLine(item.MarketAnalyzerRank + " "+ item.CP.Company.Ticker + " " + item.Fitness);
                rank++;
            }
            return list;
        }
        public class Poco
        {
            public CompanyDataPoco CP { get; set; }
            public double? Fitness { get; set; }
            public int MarketAnalyzerRank { get; set; }
        }
    }
}
