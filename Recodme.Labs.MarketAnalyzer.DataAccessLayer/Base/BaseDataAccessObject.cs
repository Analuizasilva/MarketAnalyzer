using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Recodme.Labs.MarketAnalyzer.DataAccessLayer.Base
{
    public class BaseDataAccessObject<T> where T : Entity
    {
        private Context _context;
        public BaseDataAccessObject()
        {
            _context = new Context();
        }
        
        public List<Company> GetDataBaseCompanies()
        {
            var ctx = new Context();
            var dataBaseCompanies = ctx.Companies.ToList();
            return dataBaseCompanies;
        }

        public List<Company> GetUpdateCompaniesAndUpdateDataBase(List<Company> listScrapedCompanies)
        {
            var dataBaseCompanies = this.GetDataBaseCompanies();
            var newCompaniesList = listScrapedCompanies
            .Where(x => !dataBaseCompanies.Any(c => x.Ticker == c.Ticker)).ToList();

            foreach (var company in dataBaseCompanies)
            {
                company.Rank = 0;

                var scrapCompany = listScrapedCompanies.SingleOrDefault(sc => sc.Ticker == company.Ticker);

                if (scrapCompany == null)
                {
                    continue;
                }

                if (scrapCompany.Price != company.Price)
                    company.Price = scrapCompany.Price;

                if (scrapCompany.Rank != company.Rank)
                    company.Rank = scrapCompany.Rank;
            }

            dataBaseCompanies.AddRange(newCompaniesList);
            foreach (var item in dataBaseCompanies)
            {
                Console.WriteLine(item.Rank + item.Ticker + item.Name);
            }
            return dataBaseCompanies;
        }

        #region Create
        public void Create(T item)
        {
            using (var _ctx = new Context())
            {
                _ctx.Set<T>().Add(item);
                _ctx.SaveChanges();
            }
        }
        public async Task CreateAsync(T item)
        {
            using (var _ctx = new Context())
            {
                await _context.Set<T>().AddAsync(item);
                await _context.SaveChangesAsync();
            }
        }
        #endregion

        #region Read
        public T Read(Guid id)
        {
            return _context.Set<T>().SingleOrDefault(x => x.Id == id);
        }
        public async Task<T> ReadAsync(Guid id)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
        }
        #endregion

        #region Update
        public void Update(T item)
        {
            using (var _ctx = new Context())
            {
                _ctx.Entry(item).State = EntityState.Modified;
                _ctx.SaveChanges();
            }
        }
        public async Task UpdateAsync(T item)
        {
            using (var _ctx = new Context())
            {
                _ctx.Entry(item).State = EntityState.Modified;
                await _ctx.SaveChangesAsync();
            }
        }
        #endregion

        #region Delete
        public void Delete(T item)
        {
            item.IsDeleted = true;
            Update(item);
        }
        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);
        }
        public async Task DeleteAsync(T item)
        {
            item.IsDeleted = true;
            await UpdateAsync(item);
        }
        public async Task DeleteAsync(Guid id)
        {
            var item = await ReadAsync(id);
            if (item == null) return;
            await DeleteAsync(item);
        }
        #endregion

        #region List
        public List<T> List()
        {
            return _context.Set<T>().ToList();
        }
        public async Task<List<T>> ListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        #endregion
    }
}
