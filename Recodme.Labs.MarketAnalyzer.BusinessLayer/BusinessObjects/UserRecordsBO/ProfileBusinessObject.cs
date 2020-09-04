using Recodme.Labs.MarketAnalyzer.BusinessLayer.OperationResults;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer.Base;
using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.UserRecordsBO
{
    public class ProfileBusinessObject
    {
        protected readonly BaseDataAccessObject<Profile> _dao;

        TransactionOptions transactionOptions = new TransactionOptions
        {
            IsolationLevel = IsolationLevel.ReadCommitted,
            Timeout = TimeSpan.FromSeconds(30)
        };


        public ProfileBusinessObject()
        {
            _dao = new BaseDataAccessObject<Profile>();
        }

        #region Create
        public virtual OperationResult Create(Profile profile)
        {
            try
            {
                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                _dao.Create(profile);
                transactionScope.Complete();
                return new OperationResult<List<Profile>> { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Profile>>() { Success = false, Exception = e };
            }
        }

        public async virtual Task<OperationResult> CreateAsync(Profile profile)
        {
            try
            {
                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                await _dao.CreateAsync(profile);
                transactionScope.Complete();
                return new OperationResult<List<Profile>> { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Profile>>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Read 
        public virtual OperationResult<Profile> Read(Guid id)
        {
            try
            {
                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = _dao.Read(id);
                transactionScope.Complete();
                return new OperationResult<Profile> { Result = result, Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<Profile>() { Success = false, Exception = e };
            }
        }

        public async virtual Task<OperationResult<Profile>> ReadAsync(Guid id)
        {
            try
            {
                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = await _dao.ReadAsync(id);
                transactionScope.Complete();
                return new OperationResult<Profile> { Result = result, Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<Profile>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Update
        public virtual OperationResult Update(Profile profile)
        {
            try
            {
                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                _dao.Update(profile);
                transactionScope.Complete();
                return new OperationResult<List<Profile>> { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Profile>>() { Success = false, Exception = e };
            }
        }

        public async virtual Task<OperationResult> UpdateAsync(Profile profile)
        {
            try
            {
                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                await _dao.UpdateAsync(profile);
                transactionScope.Complete();
                return new OperationResult<List<Profile>> { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Profile>>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Delete
        //public virtual OperationResult Delete(Profile profile)
        //{
        //    try
        //    {
        //        using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
        //        _dao.Update(profile);
        //        transactionScope.Complete();
        //        return new OperationResult { Success = true };
        //    }
        //    catch (Exception e)
        //    {
        //        return new OperationResult() { Success = false, Exception = e };
        //    }
        //}

        //public async virtual Task<OperationResult> DeleteAsync(Profile profile)
        //{
        //    try
        //    {
        //        using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
        //        await _dao.DeleteAsync(profile);
        //        transactionScope.Complete();
        //        return new OperationResult { Success = true };
        //    }
        //    catch (Exception e)
        //    {
        //        return new OperationResult() { Success = false, Exception = e };
        //    }
        //}

        //public virtual OperationResult Delete(Guid id)
        //{
        //    try
        //    {

        //        using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
        //        _dao.Delete(id);
        //        transactionScope.Complete();
        //        return new OperationResult { Success = true };
        //    }
        //    catch (Exception e)
        //    {
        //        return new OperationResult() { Success = false, Exception = e };
        //    }
        //}

        //public async virtual Task<OperationResult> DeleteAsync(Guid id)
        //{
        //    try
        //    {
        //        using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
        //        await _dao.DeleteAsync(id);
        //        transactionScope.Complete();
        //        return new OperationResult { Success = true };
        //    }
        //    catch (Exception e)
        //    {
        //        return new OperationResult() { Success = false, Exception = e };
        //    }
        //}
        #endregion

    }
}
