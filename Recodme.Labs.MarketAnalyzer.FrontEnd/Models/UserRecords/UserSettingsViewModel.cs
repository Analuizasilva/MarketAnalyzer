using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords;
using Recodme.Labs.MarketAnalyzer.FrontEnd.Models.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.FrontEnd.Models.UserRecords
{
    public class UserSettingsViewModel
    {

        
        public Guid CompanyId { get; set; }

        public string AspNetUserId { get; set; }

        
        public string Note { get; set; }

        public List<Note> Notes { get; set; }

    }
}
