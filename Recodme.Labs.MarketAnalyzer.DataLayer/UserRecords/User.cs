using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords
{
    public class User : IdentityUser<int>
    {
        [ForeignKey("Profile")]
        public Guid ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
