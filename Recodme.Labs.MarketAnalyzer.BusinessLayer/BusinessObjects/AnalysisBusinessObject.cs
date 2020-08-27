using Recodme.Labs.MarketAnalyzer.Analysis;
using Recodme.Labs.MarketAnalyzer.Analysis.Support;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.Support;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer;
using System.Collections.Generic;
using System.Linq;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects
{
    public class AnalysisBusinessObject
    {
        public List<StockItemPoco> GetStockData()
        {
            var dao = new CompanyDataAccessObject();
            var companiesDataPoco = dao.GetCompaniesInfo();
            var count = 1;
            var list = new List<StockItemPoco>();

            foreach (var companyDataPoco in companiesDataPoco)
            {
                var stockAnalysis = new StockAnalysis(companyDataPoco);
                var stockFitness = new StockFitness(stockAnalysis);
                var extractedValues = new List<ExtractedValue>();
                var slopeInfo = new SlopeInfo(extractedValues);
                var total = stockFitness.TotalFitness;

                if (total != null)
                {
                    list.Add(new StockItemPoco
                    {
                        StockFitness = stockFitness,
                        CompanyDataPoco = companyDataPoco,
                        Fitness = total,
                        NominalValues = stockAnalysis,
                        StockPrice = companyDataPoco.Company.StockPrice
                    });
                    count++;
                }
            }

            var rank = 1;

            foreach (var item in list.OrderByDescending(l => l.Fitness))
            {
                item.MarketAnalyzerRank = rank;
                rank++;
            }

            return list;
        }

    }
}
