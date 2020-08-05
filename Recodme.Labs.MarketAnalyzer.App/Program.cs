using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var app = new App();
            Task.WaitAll(app.Run());
        }
    }
}