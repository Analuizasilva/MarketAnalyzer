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
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(new Cookie("AID=AJHaeXKWDDOAzSJWP3lKnb3bOdsUqVcsOmOZXHQN4_DSrvh8q1y6pPg; CONSENT=YES+PT.pt-PT+20150726-13-0; ANID=AHWqTUnJQNQbolHt8oDSt3dzWS_DlXfe_x38tiLQv0dJxuFVOHJSkyCeX2-z6k7O; __Secure-3PSID=0Ae6t7tRlALdiOczJHFkfc6EwpXFx-1HL_TrSxfJEkuP5cgnvFO7QORHEBJyA-nYkIYycw.; __Secure-3PAPISID=V3Ybdfo9OFrzou90/Ab0nf1cPpbl6eUaIb; __Secure-3PSIDCC=AJi4QfExT4_OFbWRL2Odcy8V8bFw0wIHYV7FvR6jstFXGMYSNCcYMSfyilnfExkXEOmuuYww8g; 1P_JAR=2020-08-13-15;","NID=204=l_mF7U9CdR2KAtj4lNhzLZvxxJoU2lrmyGm3O9UONaIKpKsy8IKjvzDVMSfxn7bLCJiWWRuTKZXJGPrIkk0MqVf0rZ40jN1zqurzOOwBcjA_g7QFnGh88OrfI7u0qzciIOdY0Rslm5bgyECeTzUIFO2RUwWIxfm1Pnmuco_jM-zZMJGPAQghVjX3BAPexQTORk3l5FOuRDc0gFh5_hsfIsqVYTDsvMWA1Zqf5nOg00B1d-1gi2sJXHh7"));
            //request.Headers.Add("_ga=GA1.2.1699669104.1596041339; __stripe_mid=b17c865a-e499-4e73-b6f1-59616c0784bf9a36f1; _gid=GA1.2.2016187418.1597047648");


            return request;
        }

        public async Task<string> CallWebRequest(HttpWebRequest httpWebRequest)
        {
            var response = (HttpWebResponse)httpWebRequest.GetResponse();
            return await new StreamReader(response.GetResponseStream()).ReadToEndAsync();
        }
    }
}
