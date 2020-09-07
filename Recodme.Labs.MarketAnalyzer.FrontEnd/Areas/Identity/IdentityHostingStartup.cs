using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recodme.Labs.MarketAnalyzer.FrontEnd.Data;

[assembly: HostingStartup(typeof(Recodme.Labs.MarketAnalyzer.FrontEnd.Areas.Identity.IdentityHostingStartup))]
namespace Recodme.Labs.MarketAnalyzer.FrontEnd.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}