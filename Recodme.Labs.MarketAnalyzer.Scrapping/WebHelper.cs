using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.Scraping
{
    public class WebHelper
    {
        public async Task<HttpWebRequest> ComposeWebRequestGet(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.125 Safari/537.36";
            request.Host = "api.quickfs.net";
            request.Accept = "application/json, text/plain, */*";
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(new Cookie("_ga=GA1.2.1699669104.1596041339; __stripe_mid=b17c865a-e499-4e73-b6f1-59616c0784bf9a36f1", "_gid=GA1.2.2016187418.1597047648"));

            return request;
        }

        public async Task<string> CallWebRequest(HttpWebRequest httpWebRequest)
        {
            var response = (HttpWebResponse)httpWebRequest.GetResponse();
            return await new StreamReader(response.GetResponseStream()).ReadToEndAsync();
        }
    }
}
