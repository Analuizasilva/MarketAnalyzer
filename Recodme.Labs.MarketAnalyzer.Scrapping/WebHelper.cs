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
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.105 Safari/537.36";
            //request.Connection = "keep-alive";
            request.Host = "api.quickfs.net";
            request.Accept = "application/json, text/plain, */*";
            //request.CookieContainer = new CookieContainer();
            //request.CookieContainer.Add(new Cookie("");


            return request;
        }

        public async Task<string> CallWebRequest(HttpWebRequest httpWebRequest)
        {
            var response = (HttpWebResponse)httpWebRequest.GetResponse();
            return await new StreamReader(response.GetResponseStream()).ReadToEndAsync();
        }
    }
}
