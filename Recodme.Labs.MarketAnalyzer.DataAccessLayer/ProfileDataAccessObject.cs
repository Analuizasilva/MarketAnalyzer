using Recodme.Labs.MarketAnalyzer.DataLayer.Context;
using System.Linq;

namespace Recodme.Labs.MarketAnalyzer.DataAccessLayer
{
    public class ProfileDataAccessObject
    {
        public bool ValidateEmail(string email)
        {
            if (!email.Contains("@")) return false;           

            var _context = new MarketAnalyzerDBContext();

            var emailExist = _context.Profiles.Where(p => p.Email == email).FirstOrDefault();

            if (emailExist != null) return false;

            return true;
        }
    }
}

