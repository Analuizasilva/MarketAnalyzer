using Recodme.Labs.MarketAnalyzer.Analysis;
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

                var total = stockFitness.TotalFitness;

                if (total != null)
                {
                    list.Add(new StockItemPoco
                    {
                        StockFitness = stockFitness,
                        CompanyDataPoco = companyDataPoco,
                        Fitness = total,
                        StockPrice = companyDataPoco.Company.StockPrice,
                        Marketcap = stockAnalysis.MarketCapSlopeInfo.NominalValues,
                        StockAnalysis = stockAnalysis

                    }); ;
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

        public List<StockItemPoco> GetStockData(double? weightRoic, double? weightEquity, double? weightEPS, double? weightRevenue, double? weightPERatio, double? weightDebtToEquity, double? weightAssetsToLiabilities)
        {

            var dao = new CompanyDataAccessObject();
            var companiesDataPoco = dao.GetCompaniesInfo();
            var count = 1;
            var list = new List<StockItemPoco>();

            foreach (var companyDataPoco in companiesDataPoco)
            {
                var stockAnalysis = new StockAnalysis(companyDataPoco);
                var stockFitness = new StockFitness(stockAnalysis);
                stockFitness.WeightNumberRoic = weightRoic;
                stockFitness.WeightNumberEquity = weightEquity;
                stockFitness.WeightNumberEPS = weightEPS;
                stockFitness.WeightNumberRevenue = weightRevenue;
                stockFitness.WeightNumberPERatio = weightPERatio;
                stockFitness.WeightNumberDebtToEquity = weightDebtToEquity;
                stockFitness.WeightNumberAssetsToLiabilities = weightAssetsToLiabilities;

                var total = stockFitness.RoicFitness * weightRoic + stockFitness.EquityFitness * weightEquity + stockFitness.EPSFitness * weightEPS + stockFitness.RevenueFitness * weightRevenue + stockFitness.PERatioFitness * weightPERatio + stockFitness.DebtToEquityFitness * weightDebtToEquity + stockFitness.AssetsToLiabilitiesFitness * weightAssetsToLiabilities;

                if (total != null)
                {
                    list.Add(new StockItemPoco
                    {
                        StockFitness = stockFitness,
                        CompanyDataPoco = companyDataPoco,
                        Fitness = total,
                        StockPrice = companyDataPoco.Company.StockPrice,
                        Marketcap = stockAnalysis.MarketCapSlopeInfo.NominalValues,
                        StockAnalysis = stockAnalysis

                    }); ;
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
