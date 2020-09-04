using Microsoft.EntityFrameworkCore;
using Recodme.Labs.MarketAnalyzer.DataLayer.Context;
using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.DataAccessLayer.UserRecordsDAO
{
    public class PortfolioDataAccessObject
    {

        private MarketAnalyzerDBContext _context;
        public PortfolioDataAccessObject()
        {
            _context = new MarketAnalyzerDBContext();
        }

        #region C
        public void Create(Portfolio portfolio)
        {
            _context.Portfolios.Add(portfolio);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Portfolio portfolio)
        {
            await _context.Portfolios.AddAsync(portfolio);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region R
        public Portfolio Read(Guid id)
        {
            return _context.Portfolios.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Portfolio> ReadAsync(Guid id)
        {
            return await _context.Portfolios.FirstOrDefaultAsync(x => x.Id == id);
        }
        #endregion

        #region U
        public void Update(Portfolio portfolio)
        {
            _context.Entry(portfolio).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Portfolio portfolio)
        {
            _context.Entry(portfolio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region D
        public void Delete(Portfolio portfolio)
        {
            portfolio.IsDeleted = true;
            Update(portfolio);
        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);
        }

        public async Task DeleteAsync(Portfolio portfolio)
        {
            portfolio.IsDeleted = true;
            await UpdateAsync(portfolio);
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = ReadAsync(id).Result;
            if (item == null) return;
            await DeleteAsync(item);
        }
        #endregion

        #region L
        public List<Portfolio> List()
        {
            return _context.Set<Portfolio>().ToList();
        }
        public async Task<List<Portfolio>> ListAsync()
        {
            return await _context.Set<Portfolio>().ToListAsync();
        }
        #endregion

    }
}
