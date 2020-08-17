using Microsoft.Ajax.Utilities;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.Context;
using System;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.App
{
    public class App
    {
        public async Task Run()
        {
            var ctx = new MarketAnalyzerDBContext();
            ctx.Database.EnsureCreated();

            var company = new Companies("Nova Empresa");
        }   
    }
}