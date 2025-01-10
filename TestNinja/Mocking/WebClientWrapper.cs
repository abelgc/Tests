using System.Net;

namespace TestNinja.Mocking
{
    public class WebClientWrapper : IWebClient
    {
        private readonly WebClient _webClient;

        public WebClientWrapper()
        {
            _webClient = new WebClient();
        }

        public void DownloadFile(string url, string path)
        {
            _webClient.DownloadFile(url, url);
        }
    }

}
