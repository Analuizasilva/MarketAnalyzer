using Recodme.Labs.MarketAnalyzer.Analysis.Support;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.Analysis
{
    public class TransactionAnalysis
    {
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

            companyTotals.ShareValue = company.StockPrice;

            companyTotals.Invested = totalInvested;

            companyTotals.Withdrawn = totalWithdrawn;

            companyTotals.TotalSharesValue = (decimal)companyTotals.SharesOwned * companyTotals.ShareValue;

            companyTotals.TotalGainLoss = totalWithdrawn + companyTotals.TotalSharesValue - totalInvested;

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
                totalInvested += companyTransactions.Invested;
                totalWithdrawn += companyTransactions.Withdrawn;
                totalValue += companyTransactions.TotalSharesValue;
                totalGainLoss += companyTransactions.TotalGainLoss;
            }

            totalTransactions.TotalInvested = totalInvested;
            totalTransactions.TotalWithdrawn = totalWithdrawn;
            totalTransactions.TotalValue = totalValue;
            totalTransactions.TotalGainLoss = totalGainLoss;
            totalTransactions.Balance = totalWithdrawn + totalValue;

            return totalTransactions;
        }
    }
}
