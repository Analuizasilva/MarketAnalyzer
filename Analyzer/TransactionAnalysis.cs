using Recodme.Labs.MarketAnalyzer.Analysis.Support;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer.Support;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.Pocos;
using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.Analysis
{
    public class TransactionAnalysis
    {
        public class Graph
        {
            public int Year { get; set; }
            public decimal? GainLoss { get; set; }
            public decimal? CurrentValue { get; set; }
            public double? GrowthPercentage { get; set; }
        }
        public CompanyTransactions GetUserCompanyTransactions(List<UserTransaction> userTransactions, Company company) //para um user, obter o portfolio das várias transações para uma empresa
        {
            var companyTotals = new CompanyTransactions();
            companyTotals.CompanyName = company.Name;
            companyTotals.Ticker = company.Ticker;
            companyTotals.CompanyId = company.Id;
            companyTotals.UserTransactions = userTransactions;

            double? totalSharesBought = 0;
            double? totalSharesSold = 0;

            decimal? totalInvested = 0;
            decimal? totalWithdrawn = 0;

            foreach (var transaction in userTransactions)
            {
                if (transaction.NumberOfShares == null) transaction.NumberOfShares = 0;
                if (transaction.ValueOfShares == null) transaction.NumberOfShares = 0;
                if (transaction.NumberOfSharesWithdrawn == null) transaction.NumberOfShares = 0;
                if (transaction.ValueOfSharesWithdrawn == null) transaction.NumberOfShares = 0;

                totalSharesBought += transaction.NumberOfShares;
                totalSharesSold += transaction.NumberOfSharesWithdrawn;

                var invested = (decimal)transaction.NumberOfShares * transaction.ValueOfShares;
                totalInvested += invested;

                var withdrawn = (decimal)transaction.NumberOfSharesWithdrawn * transaction.ValueOfSharesWithdrawn;
                totalWithdrawn += withdrawn;
            }

            companyTotals.SharesBought = totalSharesBought;
            companyTotals.SharesSold = totalSharesSold;
            companyTotals.SharesOwned = totalSharesBought - totalSharesSold;

            companyTotals.CurrentShareValue = company.StockPrice;

            companyTotals.TotalInvested = totalInvested;

            companyTotals.TotalWithdrawn = totalWithdrawn;

            companyTotals.TotalCurrentSharesValue = (decimal)companyTotals.SharesOwned * companyTotals.CurrentShareValue;

            companyTotals.TotalGainLoss = totalWithdrawn + companyTotals.TotalCurrentSharesValue - totalInvested;

            var allReceived = totalWithdrawn + companyTotals.TotalCurrentSharesValue;

            if (allReceived - totalInvested == 0) companyTotals.TotalGainLossPercentage = 0;

            if (allReceived > totalInvested) companyTotals.TotalGainLossPercentage = (double)((allReceived - totalInvested) * 100 / totalInvested);
            if (allReceived < totalInvested)
            {
                var percentage = (double)((allReceived - totalInvested) / totalInvested) * 100;
                if (percentage < -100)
                {
                    companyTotals.TotalGainLossPercentage = -100;
                }
                else
                {
                    companyTotals.TotalGainLossPercentage = percentage;
                }
            }
            return companyTotals;
        }

        public TotalTransactions GetTotalTransactions(List<CompanyTransactions> companiesTransactionsList) //para um utilizador, obter o portfolio, com o resultado total das transações
        {
            var totalTransactions = new TotalTransactions();

            decimal? totalInvested = 0;
            decimal? totalWithdrawn = 0;
            decimal? totalValue = 0;
            decimal? totalGainLoss = 0;


            foreach (var companyTransactions in companiesTransactionsList)
            {
                totalInvested += companyTransactions.TotalInvested;
                totalWithdrawn += companyTransactions.TotalWithdrawn;
                totalValue += companyTransactions.TotalCurrentSharesValue;
                totalGainLoss += companyTransactions.TotalGainLoss;
            }

            totalTransactions.TotalInvested = totalInvested;
            totalTransactions.TotalWithdrawn = totalWithdrawn;
            totalTransactions.TotalValue = totalValue;
            totalTransactions.TotalGainLoss = totalGainLoss;
            if ((totalValue + totalWithdrawn) == 0) totalTransactions.TotalGainLossPercentage = 0;
            else { totalTransactions.TotalGainLossPercentage = (Math.Abs(((double)totalInvested - ((double)totalWithdrawn + (double)totalValue))) / (double)totalInvested)*100; }

            totalTransactions.Balance = totalWithdrawn + totalValue;

            return totalTransactions;
        }


        public class StuffForGraph
        {
            public int Year { get; set; }
            public Guid CompanyId { get; set; }
            public double? NumberStocksInvested { get; set; }
            public double? NumberStocksWithdrawn { get; set; }
            public decimal? StocksInvested { get; set; }
            public decimal? StocksWithdrawn { get; set; }
            public decimal? CurrentValue { get; set; }
            public decimal? CurrentValueWithdrawn { get; set; }
            public decimal? StockPrice { get; set; }
            public List<StockPriceHistoryForCompany>StockPriceHistory{get;set;}

        }
        public class StockPriceHistoryForCompany
        {
            public int Year { get; set; }
            public Guid CompanyId { get; set; }
            public decimal? StockValue { get; set; }
            public double? NumberStocks { get; set; }
        }
        public List<StuffForGraph> GetGraphTotalsPerCompany(List<UserTransaction> userTransactions, Company company, StockValuePoco stockValuePoco)
        {
            var stuffForGraphList = new List<StuffForGraph>();
            var firstYear = 2009;
            var lastYear = DateTime.Now.Year;
            var priceHistory = new List<StockPriceHistoryForCompany>();
            var yearsList = new List<int>();
            foreach (var transaction in userTransactions)
            {
                if (stockValuePoco.Components.Where(x => x.Year == transaction.DateOfMovement.Year).SingleOrDefault() != null)
                {
                    var stuffForGraph = new StuffForGraph();

                    decimal? valueOfShare = 0;
                    
                    var stockValueInfo = stockValuePoco.Components.Where(x => x.Year == transaction.DateOfMovement.Year).SingleOrDefault();
                    valueOfShare = stockValueInfo.MarketCap / stockValueInfo.SharesBasic;
                    
                    var numberOfShares = transaction.NumberOfShares;
                    var numberOfSharesWithdrawn = transaction.NumberOfSharesWithdrawn;
                    var invested = (decimal)transaction.NumberOfShares * transaction.ValueOfShares;
                    var withdrawn = (decimal)transaction.NumberOfSharesWithdrawn * transaction.ValueOfSharesWithdrawn;

                    stuffForGraph.Year = transaction.DateOfMovement.Year;
                    stuffForGraph.CompanyId = transaction.CompanyId;

                    stuffForGraph.NumberStocksInvested = transaction.NumberOfShares;
                    stuffForGraph.NumberStocksWithdrawn = transaction.NumberOfSharesWithdrawn;

                    stuffForGraph.StocksInvested = invested;
                    stuffForGraph.StocksWithdrawn = withdrawn;

                    stuffForGraph.CurrentValue = valueOfShare*(decimal)numberOfShares;
                    stuffForGraph.CurrentValueWithdrawn = valueOfShare * (decimal)numberOfSharesWithdrawn;
                    stuffForGraph.StockPrice = company.StockPrice;
                    stuffForGraphList.Add(stuffForGraph);
                    
                }
                else
                {
                    var stuffForGraph = new StuffForGraph();
                    decimal? valueOfShare = company.StockPrice;

                    var numberOfShares = transaction.NumberOfShares;
                    var numberOfSharesWithdrawn = transaction.NumberOfSharesWithdrawn;
                    var invested = (decimal)transaction.NumberOfShares * transaction.ValueOfShares;
                    var withdrawn = (decimal)transaction.NumberOfSharesWithdrawn * transaction.ValueOfSharesWithdrawn;

                    stuffForGraph.Year = transaction.DateOfMovement.Year;
                    stuffForGraph.CompanyId = transaction.CompanyId;

                    stuffForGraph.NumberStocksInvested = transaction.NumberOfShares;
                    stuffForGraph.NumberStocksWithdrawn = transaction.NumberOfSharesWithdrawn;

                    stuffForGraph.StocksInvested = invested;
                    stuffForGraph.StocksWithdrawn = withdrawn;

                    stuffForGraph.CurrentValue = valueOfShare*(decimal)numberOfShares;
                    stuffForGraph.CurrentValueWithdrawn = valueOfShare * (decimal)numberOfSharesWithdrawn;
                    stuffForGraph.StockPrice= company.StockPrice;
                    stuffForGraphList.Add(stuffForGraph);
                }
            }
            for (var i = 0; i < (lastYear - firstYear)+1; i++)
            {
                yearsList.Add(firstYear + i);
            }
            var stuffForGraphHistory = new StuffForGraph();
            foreach (var item in yearsList)
            {

                if(stockValuePoco.Components.Where(x => x.Year == item).SingleOrDefault() != null)
                {
                    var stockValueInfo = stockValuePoco.Components.Where(x => x.Year == item).SingleOrDefault();
                    var valueOfShare = stockValueInfo.MarketCap / stockValueInfo.SharesBasic;
                    var history = new StockPriceHistoryForCompany();
                    history.Year = item;
                    history.CompanyId = company.Id;
                    history.StockValue = valueOfShare;

                    var withdrawnThatYear = userTransactions.Where(x => x.DateOfMovement.Year == item).Where(x => x.NumberOfSharesWithdrawn != 0).ToList();

                    var yearsBefore = new List<StuffForGraph>();
                    if (withdrawnThatYear.Count != 0)
                    {
                        yearsBefore = stuffForGraphList.OrderBy(x => x.Year).Where(x => x.Year <= item).ToList();
                    }
                    else
                    {
                        yearsBefore = stuffForGraphList.OrderBy(x => x.Year).Where(x => x.Year < item).ToList();
                    }


                    double? numberOfShares = 0;
                    foreach (var data in yearsBefore)
                    {
                        var result = data.NumberStocksInvested - data.NumberStocksWithdrawn;
                        numberOfShares += result;
                    }
                    history.NumberStocks = numberOfShares;
                    priceHistory.Add(history);
                }
                else
                {
                    var valueOfShare = company.StockPrice;
                    var history = new StockPriceHistoryForCompany();
                    history.Year = item;
                    history.CompanyId = company.Id;
                    history.StockValue = valueOfShare;

                    var yearsBefore = stuffForGraphList.OrderBy(x => x.Year).Where(x => x.Year <= item).ToList();
                    double? numberOfShares = 0;
                    foreach (var data in yearsBefore)
                    {
                        var result = data.NumberStocksInvested - data.NumberStocksWithdrawn;
                        numberOfShares += result;
                    }
                    history.NumberStocks = numberOfShares;
                    priceHistory.Add(history);
                }
                
            }
            stuffForGraphHistory.CompanyId = company.Id;
            stuffForGraphHistory.StockPriceHistory = priceHistory;
            stuffForGraphList.Add(stuffForGraphHistory);

            var orderedList = stuffForGraphList.OrderBy(x => x.Year).ToList();
            
            

            return orderedList;
        }


        public class GraphTotal
        {
            public int Year { get; set; }
            public double? TotalNumberOfStocksOwned { get; set; }
            public decimal? TotalInvested { get; set; }
            public decimal? TotalWithdrawn { get; set; }
            public decimal? TotalValue { get; set; }
            public decimal? TotalGainLoss { get; set; }
            public double? GrowthPercentage { get; set; }
            public decimal? CurrentValue { get; set; }
        }

        public List<GraphTotal> GetGraphTotals(List<StuffForGraph> graphPerCompanies, TotalTransactions totalTransactions)
        {
            if (graphPerCompanies.Count == 0 || graphPerCompanies == null) return null;
            decimal? currentV = 0;
            var currentValueFromCompanies = graphPerCompanies.GroupBy(x => x.CompanyId);
            foreach(var company in currentValueFromCompanies)
            {
                foreach(var item in company)
                {
                    if (item.StockPriceHistory != null)
                    {
                        var history = item.StockPriceHistory;
                        var info = history.Where(x => x.Year == DateTime.Now.Year).SingleOrDefault();
                        currentV += (decimal)info.NumberStocks * info.StockValue;
                    }
                    
                }
            }




            var firstYear = graphPerCompanies.Where(x=>x.Year!=0).Min(x => x.Year);
            var lastYear = DateTime.Now.Year;


            var totals = new List<GraphTotal>();
            double? stocksOwned = 0;
            decimal? investment = 0;
            decimal? withdraw = 0;
            decimal? totalValue = 0;
            
            for (var i = 0; i <= (lastYear - firstYear); i++)
            {
                var total = new GraphTotal();
                total.Year = firstYear + i;

                var transactionsForYear = graphPerCompanies.Where(x => x.Year == total.Year).ToList();
                if (transactionsForYear.Count != 0)
                {
                    
                    foreach (var item in transactionsForYear)
                    {
                        
                        if (transactionsForYear.Count > 1)
                        {
                            stocksOwned += (item.NumberStocksInvested - item.NumberStocksWithdrawn);
                            investment += item.StocksInvested;
                            withdraw += item.StocksWithdrawn;
                            decimal? count = 0;
                            //count += item.CurrentValue-item.CurrentValueWithdrawn;
                            totalValue = count;
                        }
                        else
                        {
                            stocksOwned += (item.NumberStocksInvested - item.NumberStocksWithdrawn);
                            investment += item.StocksInvested;
                            withdraw += item.StocksWithdrawn;
                            totalValue = item.CurrentValue;
                        }
                        
                    }
                    var stockHistory = graphPerCompanies.Where(x => x.Year == 0);
                    decimal? value = 0;
                    foreach (var data in stockHistory)
                    {
                        foreach (var year in data.StockPriceHistory)
                        {
                            if (year.Year == total.Year)
                            {
                                value += (decimal)year.NumberStocks * year.StockValue;
                            }
                        }

                    }
                    total.TotalValue = totalValue+value;


                }
                else
                {
                    var stockHistory = graphPerCompanies.Where(x => x.Year == 0);
                    decimal? value=0;
                    foreach(var data in stockHistory)
                    {
                        foreach(var year in data.StockPriceHistory)
                        {
                            if(year.Year == total.Year)
                            {
                                value += (decimal)year.NumberStocks * year.StockValue;
                            }
                        }

                    }

                    total.TotalValue = value;

                }
                total.TotalNumberOfStocksOwned = stocksOwned;
                total.TotalInvested = investment;
                total.TotalWithdrawn = withdraw;
                total.TotalGainLoss = total.TotalValue + withdraw - investment;
                total.CurrentValue = currentV;

                var allReceived = withdraw + total.TotalValue;

                if (allReceived - investment == 0) total.GrowthPercentage = 0;

                if (allReceived > investment) total.GrowthPercentage = (double)((allReceived - investment) * 100 / investment);
                if (allReceived < investment)
                {
                    var percentage = (double)((allReceived - investment) / investment) * 100;
                    if (percentage < -100)
                    {
                        total.GrowthPercentage = -100;
                    }
                    else
                    {
                        total.GrowthPercentage = percentage;
                    }
                }

                totals.Add(total);
            }

            return totals;
        }
    }
}

