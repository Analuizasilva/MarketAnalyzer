using Recodme.Labs.MarketAnalyzer.BusinessLayer.OperationResults;
using Recodme.RD.FullStoQReborn.DataAccessLayer.Person;
using Recodme.RD.FullStoQReborn.DataLayer.UserRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.UserBusinessObject
{
    public class ProfileBusinessObject
    {
        private readonly ProfileDataAccessObject _dao;

        public ProfileBusinessObject()
        {
            _dao = new ProfileDataAccessObject();
        }

        #region C
        public OperationResult<bool> Create(Profile item)
        {
            try
            {
                if (_dao.List().Any(x => x.Email == item.Email && !x.IsDeleted)) return new OperationResult<bool>() { Success = true, Result = false, Message = "Email already exists" };

                if (_dao.List().Any(x => x.Email == item.Email && !x.Email.ToString().Contains("@"))) return new OperationResult<bool>() { Success = true, Result = false, Message = "Email must contain @" };

                return new OperationResult<bool>() { Success = true, Result = true };
            }
            catch (Exception e)
            {
                return new OperationResult<bool>() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult<bool>> CreateAsync(Profile item)
        {
            try
            {
                if (_dao.ListAsync().Result.Any(x => x.Email == item.Email && !x.IsDeleted)) return new OperationResult<bool>() { Success = true, Result = false, Message = "Email already exists" };

                if (_dao.ListAsync().Result.Any(x => x.Email == item.Email && !x.Email.ToString().Contains("@"))) return new OperationResult<bool>() { Success = true, Result = false, Message = "Email must contain @" };

                await _dao.CreateAsync(item);

                return new OperationResult<bool>() { Success = true, Result = true };
            }
            catch (Exception e)
            {
                return new OperationResult<bool>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region R
        public OperationResult<Profile> Read(Guid id)
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = _dao.Read(id);
                transactionScope.Complete();
                return new OperationResult<Profile>() { Success = true, Result = result };
            }
            catch (Exception e)
            {
                return new OperationResult<Profile>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<Profile>> ReadAsync(Guid id)
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)

                };
                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var res = await _dao.ReadAsync(id);
                transactionScope.Complete();
                return new OperationResult<Profile>() { Success = true, Result = res };
            }
            catch (Exception e)
            {
                return new OperationResult<Profile>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region U
        public OperationResult<bool> Update(Profile item)
        {
            try
            {
                if (_dao.List().Any(x => x.Email == item.Email && item.Id != x.Id && !x.IsDeleted)) return new OperationResult<bool>() { Success = true, Result = false, Message = "Vat number already exists" };

                if (_dao.List().Any(x => x.Email == item.Email && !x.Email.ToString().Contains("@"))) return new OperationResult<bool>() { Success = true, Result = false, Message = "Email must contain @" };

                _dao.Update(item);
                return new OperationResult<bool>() { Success = true, Result = true };
            }
            catch (Exception e)
            {
                return new OperationResult<bool>() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult<bool>> UpdateAsync(Profile item)
        {
            try
            {
                if (_dao.List().Any(x => x.Email == item.Email && item.Id != x.Id && !x.IsDeleted)) return new OperationResult<bool>() { Success = true, Result = false, Message = "Vat number already exists" };

                if (_dao.List().Any(x => x.Email == item.Email && !x.Email.ToString().Contains("@"))) return new OperationResult<bool>() { Success = true, Result = false, Message = "Email must contain @" };

                await _dao.UpdateAsync(item);
                return new OperationResult<bool>() { Success = true, Result = true };
            }
            catch (Exception e)
            {
                return new OperationResult<bool>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region D
        public OperationResult Delete(Profile item)
        {
            try
            {
                _dao.Delete(item);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult> DeleteAsync(Guid id)
        {
            try
            {
                await _dao.DeleteAsync(id);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        public OperationResult Delete(Guid id)
        {
            try
            {
                _dao.Delete(id);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult> DeleteAsync(Profile item)
        {
            try
            {
                await _dao.DeleteAsync(item);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region L
        public OperationResult<List<Profile>> List()
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };

                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = _dao.List();

                transactionScope.Complete();

                return new OperationResult<List<Profile>>() { Success = true, Result = result };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Profile>>() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult<List<Profile>>> ListAsync()
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };

                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var res = await _dao.ListAsync();
                transactionScope.Complete();
                return new OperationResult<List<Profile>>() { Success = true, Result = res };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Profile>>() { Success = false, Exception = e };
            }
        }
        #endregion
        
    }
}

