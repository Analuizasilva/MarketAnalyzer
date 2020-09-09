using Microsoft.AspNetCore.Identity;
using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords
{
    public class Note : Entity
    {
        public string Description { get; set; }

        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public string AspNetUserId { get; set; }
       


    }
}
