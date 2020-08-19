using Microsoft.EntityFrameworkCore;
using Recodme.Labs.MarketAnalyzer.DataLayer;
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
            using (var _ctx = new MarketAnalyzerDBContext())
            {
                _ctx.Set<T>().Add(item);
                _ctx.SaveChanges();
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
            using (var _ctx = new MarketAnalyzerDBContext())
            {
                _ctx.Entry(item).State = EntityState.Modified;
                _ctx.SaveChanges();
            }
        }

        public async Task UpdateAsync(T item)
        {
            using (var _ctx = new MarketAnalyzerDBContext())
            {
                _ctx.Entry(item).State = EntityState.Modified;
                await _ctx.SaveChangesAsync();
            }
        }

        public async Task UpdateListAsync(List<T> items)
        {
            using (var _ctx = new MarketAnalyzerDBContext())
            {
                foreach (var item in items)
                    _ctx.Entry(item).State = EntityState.Modified;
                await _ctx.SaveChangesAsync();
            }
        }

        #endregion Update

        #region List

        public List<T> List()
        {
            using (var _ctx = new MarketAnalyzerDBContext())
            {
                return _ctx.Set<T>().ToList();
            }
                
        }

        public async Task<List<T>> ListAsync()
        {
            using (var _ctx = new MarketAnalyzerDBContext())
            {
                return await _ctx.Set<T>().ToListAsync();
            }
               
        }

        #endregion List
    }
}