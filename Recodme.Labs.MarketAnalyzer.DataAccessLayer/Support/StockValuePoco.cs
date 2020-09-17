using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.DataAccessLayer.Support
{
    public class StockValueComponents
    {
        public int Year { get; set; }
        public decimal? MarketCap { get; set; }
        public decimal? SharesBasic { get; set; }
    }
    public class StockValuePoco
    {
        public Guid CompanyId { get; set; }
        public List<StockValueComponents> Components { get; set; }
    }
}
