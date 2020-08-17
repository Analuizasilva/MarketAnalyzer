using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.DataLayer
{
    public class Industries : NamedEntity
    {
        public virtual ICollection<Companies> Companies { get; set; }

        public Industries(string name) : base(name)
        {
            Companies = new HashSet<Companies>();
        }

        public Industries(Guid id, DateTime createdAt, DateTime updatedAt, string name) : base(id, createdAt, updatedAt, name)
        {
        }
    }
}
