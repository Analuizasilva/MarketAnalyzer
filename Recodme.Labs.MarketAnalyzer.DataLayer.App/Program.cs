using DataAccessLayer.Contexts;
using System;

namespace Recodme.Labs.MarketAnalyzer.DataLayer.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new Context();
            ctx.Database.EnsureCreated();
        }
    }
}
