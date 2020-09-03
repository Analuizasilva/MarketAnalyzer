using Microsoft.EntityFrameworkCore;
using Recodme.Labs.MarketAnalyzer.DataLayer.Context;
using Recodme.RD.FullStoQReborn.DataLayer.UserRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.FullStoQReborn.DataAccessLayer.Person
{
    public class ProfileDataAccessObject
    {
        private MarketAnalyzerDBContext _context;
        public ProfileDataAccessObject()
        {
            _context = new MarketAnalyzerDBContext();
        }

        #region C
        public void Create(Profile profile)
        {
            _context.Profiles.Add(profile);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Profile profile)
        {
            await _context.Profiles.AddAsync(profile);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region R
        public Profile Read(Guid id)
        {
            return _context.Profiles.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Profile> ReadAsync(Guid id)
        {
            return await _context.Profiles.FirstOrDefaultAsync(x => x.Id == id);
        }
        #endregion

        #region U
        public void Update(Profile profile)
        {
            _context.Entry(profile).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Profile profile)
        {
            _context.Entry(profile).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region D
        public void Delete(Profile profile)
        {
           profile.IsDeleted = true;
            Update(profile);
        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);
        }

        public async Task DeleteAsync(Profile profile)
        {
            profile.IsDeleted = true;
            await UpdateAsync(profile);
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = ReadAsync(id).Result;
            if (item == null) return;
            await DeleteAsync(item);
        }
        #endregion

        #region L
        public List<Profile> List()
        {
            return _context.Set<Profile>().ToList();
        }
        public async Task<List<Profile>> ListAsync()
        {
            return await _context.Set<Profile>().ToListAsync();
        }
        #endregion
    }
}
