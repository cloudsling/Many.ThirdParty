using Windows.Web.Http;

namespace Many.ThirdParty.Core.Tools
{
    public static class HttpHelper
    {
        /// <summary>
        /// 伪装成安卓useragent的httpclient，管不管用不知道
        /// </summary>
        /// <returns></returns>
        public static HttpClient CreateHttpClientWithUserAgent()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("UserAgent", "Mozilla/5.0 (Linux; Android 4.1.1; Nexus 7 Build/JRO03D) AppleWebKit/535.19 (KHTML, like Gecko) Chrome/18.0.1025.166  Safari/535.19");
            client.DefaultRequestHeaders.Add("ContentType", "application/x-www-form-urlencoded");
            return client;
        }
    }
}

