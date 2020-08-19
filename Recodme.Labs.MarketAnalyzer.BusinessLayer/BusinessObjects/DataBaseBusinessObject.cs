using Recodme.Labs.MarketAnalyzer.DataAccessLayer.Base;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects
{
    public class DataBaseBusinessObject
    {
        public async Task<List<ExtractedBalanceSheet>> GetBalanceSheets()
        {
            var dao = new BaseDataAccessObject<ExtractedBalanceSheet>();
            return await dao.ListAsync();
        }

        public async Task<List<Company>> GetCompanies()
        {
            var dao = new BaseDataAccessObject<Company>();
            return await dao.ListAsync();
        }

        public async Task<List<ExtractedCashFlowStatement>> GetCashFlowStatements()
        {
            var dao = new BaseDataAccessObject<ExtractedCashFlowStatement>();
            return await dao.ListAsync();
        }

        public async Task<List<ExtractedCashFlowStatementTtm>> GetCashFlowStatementTtms()
        {
            var dao = new BaseDataAccessObject<ExtractedCashFlowStatementTtm>();
            return await dao.ListAsync();
        }

        public async Task<List<ExtractedIncomeStatement>> GetIncomeStatements()
        {
            var dao = new BaseDataAccessObject<ExtractedIncomeStatement>();
            return await dao.ListAsync();
        }

        public async Task<List<ExtractedIncomeStatementTtm>> GetIncomeStatementTtms()
        {
            var dao = new BaseDataAccessObject<ExtractedIncomeStatementTtm>();
            return await dao.ListAsync();
        }

        public async Task<List<ExtractedKeyRatio>> GetKeyRatios()
        {
            var dao = new BaseDataAccessObject<ExtractedKeyRatio>();
            return await dao.ListAsync();
        }
    }
}
