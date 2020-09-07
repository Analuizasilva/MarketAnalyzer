using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Recodme.Labs.MarketAnalyzer.FrontEnd.Areas.Identity.IdentityHostingStartup))]
namespace Recodme.Labs.MarketAnalyzer.FrontEnd.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}