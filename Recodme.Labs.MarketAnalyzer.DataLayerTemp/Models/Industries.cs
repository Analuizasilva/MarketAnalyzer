using System;
using System.Collections.Generic;

namespace Recodme.Labs.MarketAnalyzer.DataLayerTemp.Models
{
    public partial class Industries
    {
        public Industries()
        {
            Companies = new HashSet<Companies>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Companies> Companies { get; set; }
    }
}
