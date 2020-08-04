using DataAccessLayer.Contexts;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.OperationResults;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer.Base;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using Recodme.Labs.MarketAnalyzer.Scrapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects
{
    public class BusinessObject<T> where T : Entity
    {
        private BaseDataAccessObject<T> _dao = new BaseDataAccessObject<T>();

        public BusinessObject()
        {
            _dao = new BaseDataAccessObject<T>();
        }

        private TransactionOptions opts = new TransactionOptions()
        {
            IsolationLevel = IsolationLevel.ReadCommitted,
            Timeout = TimeSpan.FromSeconds(30)
        };

        #region Create
        public OperationResult Create(T item)
        {
            try
            {
                _dao.Create(item);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }

        }

        public async Task<OperationResult> CreateAsync(T item)
        {
            try
            {
                var transactionOptions = new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions,
                                                 TransactionScopeAsyncFlowOption.Enabled);
                await _dao.CreateAsync(item);
                scope.Complete();
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Read
        public OperationResult<T> Read(Guid id)
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var result = _dao.Read(id);
                    ts.Complete();
                    return new OperationResult<T>() { Success = true, Result = result };
                }

            }
            catch (Exception e)
            {
                return new OperationResult<T>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<T>> ReadAsync(Guid id)
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var result = await _dao.ReadAsync(id);
                    ts.Complete();
                    return new OperationResult<T>() { Success = true, Result = result };
                }

            }
            catch (Exception e)
            {
                return new OperationResult<T>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Update
        public OperationResult Update(T item)
        {
            try
            {
                _dao.Update(item);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }

        }

        public async Task<OperationResult> UpdateAsync(T item)
        {
            try
            {
                await _dao.UpdateAsync(item);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Delete
        public OperationResult Delete(T item)
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

        public async Task<OperationResult> DeleteAsync(T item)
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
        #endregion

        #region List
        public OperationResult<List<T>> List()
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var res = _dao.List();
                    ts.Complete();
                    return new OperationResult<List<T>>() { Success = true, Result = res };
                }
            }
            catch (Exception e)
            {
                return new OperationResult<List<T>>() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<List<T>>> ListAsync()
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required, opts, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var res = await _dao.ListAsync();
                    ts.Complete();
                    return new OperationResult<List<T>>() { Success = true, Result = res };
                }
            }
            catch (Exception e)
            {
                return new OperationResult<List<T>>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Verification
        public List<Company> CompanyVerification()
        {
            var ctx = new Context();

            var dataBaseList = ctx.Companies.ToList();

            var scrap = new Scrap();
            var scrapList = scrap.GetInfo();

            var updatedList = new List<Company>();

            var addedList = new List<Company>();

            foreach (var item in scrapList)
            {
                foreach (var data in dataBaseList)
                {
                    if (item.Ticker == data.Ticker)
                    {
                        if (item.Price != data.Price)
                        {
                            item.Price = data.Price;
                        }

                        if (item.Rank != data.Rank)
                        {
                            item.Rank = data.Rank;
                        }
                    }

                    else
                    {
                        addedList.Add(item);
                    }
                }
               updatedList.Add(item);
            }

            ctx.Companies.AddRange(updatedList);
            ctx.SaveChanges();
            return updatedList;
            //ctx.Companies.SingleOrDefault(x => x.Ticker == ticker);      
        }
        #endregion
    }
}
