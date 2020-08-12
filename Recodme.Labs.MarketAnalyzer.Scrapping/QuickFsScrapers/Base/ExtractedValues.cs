using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.Scrapping.QuickFsScrapers.Base
{
    public class ExtractedValues
    {
        public string Year { get; set; }
        public List<BaseItem> Items { get; set; }

        public ExtractedValues()
        {
            Items = new List<BaseItem>();
        }
    }
}
