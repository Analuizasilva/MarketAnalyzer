using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.Scrapping.QuickFsScrapers.Base
{
    public class ExtractedStatement
    {
        public string Year { get; set; }
        public List<BaseItem> Items { get; set; }

        public ExtractedStatement()
        {
            Items = new List<BaseItem>();
        }
    }
}
