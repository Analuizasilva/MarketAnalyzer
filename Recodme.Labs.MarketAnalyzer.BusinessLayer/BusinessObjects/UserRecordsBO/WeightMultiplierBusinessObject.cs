using Recodme.Labs.MarketAnalyzer.BusinessLayer.OperationResults;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer.Base;
using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.UserRecordsBO
{
    public class WeightMultiplierBusinessObject
    {

        private readonly BaseDataAccessObject<WeightMultiplier> _dao;

        TransactionOptions transactionOptions = new TransactionOptions
        {
            IsolationLevel = IsolationLevel.ReadCommitted,
            Timeout = TimeSpan.FromSeconds(30)
        };

        public WeightMultiplierBusinessObject()
        {
            _dao = new BaseDataAccessObject<WeightMultiplier>();
        }

        #region List
        public OperationResult<List<WeightMultiplier>> List()
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                using (var ts = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var result = _dao.List();
                    ts.Complete();
                    return new OperationResult<List<WeightMultiplier>>() { Success = true, Result = result };
                }
            }
            catch (Exception e)
            {
                return new OperationResult<List<WeightMultiplier>>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<List<WeightMultiplier>>> ListAsync()
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                using (var ts = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var result = await _dao.ListAsync();
                    ts.Complete();
                    return new OperationResult<List<WeightMultiplier>>() { Success = true, Result = result };
                }
            }
            catch (Exception e)
            {
                return new OperationResult<List<WeightMultiplier>>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Create
        public OperationResult Create(WeightMultiplier weightMultiplier)
        {
            try
            {

                _dao.Create(weightMultiplier);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult> CreateAsync(WeightMultiplier weightMultiplier)
        {
            try
            {
                await _dao.CreateAsync(weightMultiplier);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Read
        public OperationResult<WeightMultiplier> Read(Guid id)
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var res = _dao.Read(id);
                    transactionScope.Complete();
                    return new OperationResult<WeightMultiplier>() { Success = true, Result = res };
                }
            }
            catch (Exception e)
            {
                return new OperationResult<WeightMultiplier>() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult<WeightMultiplier>> ReadAsync(Guid id)
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var res = await _dao.ReadAsync(id);
                    transactionScope.Complete();
                    return new OperationResult<WeightMultiplier>() { Success = true, Result = res };
                }
            }
            catch (Exception e)
            {
                return new OperationResult<WeightMultiplier>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Update
        public OperationResult Update(WeightMultiplier weightMultiplier)
        {
            try
            {
                _dao.Update(weightMultiplier);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult> UpdateAsync(WeightMultiplier weightMultiplier)
        {
            try
            {
                await _dao.UpdateAsync(weightMultiplier);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = true, Exception = e };
            }
        }
        #endregion       
    }
}
