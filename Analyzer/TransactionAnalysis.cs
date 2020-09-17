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
        public List<TotalsGraphInfoPoco> GetTotalsGraphInfo(List<UserTransactionsPoco> userTransactions)
        {
            var total = new TotalsGraphInfoPoco();
            var totals = new List<TotalsGraphInfoPoco>();
            var results = new List<PerYearResults>();
            var result = new PerYearResults();
            userTransactions.OrderBy(x => x.Year);

            for (var i = 0; i < userTransactions.Count; i++)
            {
                decimal totalInvested = 0;
                decimal totalWithdrawn = 0;
                foreach (var ut in userTransactions[i].UserTransactions)
                {
                    totalInvested += (decimal)((decimal)ut.NumberOfShares * ut.ValueOfShares);
                    totalWithdrawn += (decimal)((decimal)ut.NumberOfSharesWithdrawn * ut.ValueOfSharesWithdrawn);
                }
                result.Year = userTransactions[i].Year;
                result.Result = totalInvested + totalWithdrawn;
                result.Invested = totalInvested;
                results.Add(result);
            }
            for (var j = 0; j < results.Count; j++)
            {
                total.Year = results[j].Year;
                total.GrowthPercentage = (double)((results[j + 1].Result - results[j].Result) / results[j].Result) * 100;
                total.TotalInvested = results[j].Invested;
                total.TotalGainLossPercentage = null;
            }
            return null;
        }
        public CompanyTransactions GetUserCompanyTransactions(List<UserTransaction> userTransactions, Company company) //para um user, obter o portfolio das várias transações para uma empresa
        {
            var companyTotals = new CompanyTransactions();
            companyTotals.CompanyName = company.Name;
            companyTotals.Ticker = company.Ticker;
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
            else { totalTransactions.TotalGainLossPercentage = (double)(totalGainLoss / (totalValue + totalWithdrawn)) * 100; }

            totalTransactions.Balance = totalWithdrawn + totalValue;

            return totalTransactions;
        }
    }
}
