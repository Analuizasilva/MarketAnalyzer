using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using System;
using System.Collections.Generic;

namespace Recodme.Labs.MarketAnalyzer.DataLayer
{
    public class Industry : NamedEntity
    {
        public virtual ICollection<Company> Companies { get; set; }

        public Industry(string name) : base(name)
        {
            Companies = new HashSet<Company>();
        }

        public Industry(Guid id, DateTime createdAt, DateTime updatedAt, string name) : base(id, createdAt, updatedAt, name)
        {
        }
    }
}
