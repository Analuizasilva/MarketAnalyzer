using Microsoft.EntityFrameworkCore;
using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using Recodme.Labs.MarketAnalyzer.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.DataAccessLayer.Base
{
    public class BaseDataAccessObject<T> where T : Entity
    {
        private MarketAnalyzerDBContext _context;
        public BaseDataAccessObject()
        {
            _context = new MarketAnalyzerDBContext();
        }

        #region Create
        public void Create(T item)
        {
            using (var _context = new MarketAnalyzerDBContext())
            {
                _context.Set<T>().Add(item);
                _context.SaveChanges();
            }
        }

        public async Task CreateAsync(T item)
        {
            using (var _ctx = new MarketAnalyzerDBContext())
            {
                await _context.Set<T>().AddAsync(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddListAsync(List<T> items)
        {
            using (var _ctx = new MarketAnalyzerDBContext())
            {
                await _context.Set<T>().AddRangeAsync(items);
                await _context.SaveChangesAsync();
            }
        }

        #endregion Create

        #region Read

        public T Read(Guid id)
        {
            return _context.Set<T>().SingleOrDefault(x => x.Id == id);
        }

        public async Task<T> ReadAsync(Guid id)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
        }

        #endregion Read

        #region Update
        public void Update(T item)
        {
            using (var _context = new MarketAnalyzerDBContext())
            {
                _context.Entry(item).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public async Task UpdateAsync(T item)
        {
            using (var _context = new MarketAnalyzerDBContext())
            {
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateListAsync(List<T> items)
        {
            using (var _context = new MarketAnalyzerDBContext())
            {
                foreach (var item in items)
                    _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        #endregion Update

        #region List
        public List<T> List()
        {
            using (var _context = new MarketAnalyzerDBContext())
            {
                return _context.Set<T>().ToList();
            }

        }

        public async Task<List<T>> ListAsync()
        {
            using (var _context = new MarketAnalyzerDBContext())
            {
                return await _context.Set<T>().ToListAsync();
            }
        }
        #endregion List

        #region Delete
        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
            _context.SaveChangesAsync();
        }
        #endregion Delete

    }
}