using DataAccessLayer.Contexts;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.Scrapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Recodme.Labs.MarketAnalyzer.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var _ctx = new Context();
            _ctx.Database.EnsureCreated();

            var scrap = new Scrap();
            scrap.GetInfo();
           
        }
    }
}
