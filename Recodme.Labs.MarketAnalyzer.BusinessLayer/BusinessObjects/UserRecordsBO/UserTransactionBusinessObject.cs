﻿using Recodme.Labs.MarketAnalyzer.BusinessLayer.OperationResults;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer.Base;
using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.UserRecordsBusinessObject
{
    public class UserTransactionBusinessObject
    {
        private readonly BaseDataAccessObject<UserTransaction> _dao;

        TransactionOptions transactionOptions = new TransactionOptions
        {
            IsolationLevel = IsolationLevel.ReadCommitted,
            Timeout = TimeSpan.FromSeconds(30)
        };

        public UserTransactionBusinessObject()
        {
            _dao = new BaseDataAccessObject<UserTransaction>();
        }

        #region List
        public OperationResult<List<UserTransaction>> List()
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
                    return new OperationResult<List<UserTransaction>>() { Success = true, Result = result };
                }
            }
            catch (Exception e)
            {
                return new OperationResult<List<UserTransaction>>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<List<UserTransaction>>> ListAsync()
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
                    return new OperationResult<List<UserTransaction>>() { Success = true, Result = result };
                }
            }
            catch (Exception e)
            {
                return new OperationResult<List<UserTransaction>>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Create
        public OperationResult Create(UserTransaction userTransaction)
        {
            try
            {

                _dao.Create(userTransaction);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult> CreateAsync(UserTransaction userTransaction)
        {
            try
            {
                await _dao.CreateAsync(userTransaction);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Read
        public OperationResult<UserTransaction> Read(Guid id)
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
                    return new OperationResult<UserTransaction>() { Success = true, Result = res };
                }
            }
            catch (Exception e)
            {
                return new OperationResult<UserTransaction>() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult<UserTransaction>> ReadAsync(Guid id)
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
                    return new OperationResult<UserTransaction>() { Success = true, Result = res };
                }
            }
            catch (Exception e)
            {
                return new OperationResult<UserTransaction>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Update
        public OperationResult Update(UserTransaction userTransaction)
        {
            try
            {
                _dao.Update(userTransaction);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult> UpdateAsync(UserTransaction userTransaction)
        {
            try
            {
                await _dao.UpdateAsync(userTransaction);
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
