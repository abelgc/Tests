using System;
using System.Net;

namespace TestNinja.Mocking
{

    public class InstallerHelper : IInstallerHelper
    {
        private readonly IWebClient _webClient;
        private readonly string _setupDestinationFile;

        public InstallerHelper(IWebClient webClient, string setupDestinationFile)
        {
            _webClient = webClient ?? throw new ArgumentNullException(nameof(webClient));
            _setupDestinationFile = setupDestinationFile ?? throw new ArgumentNullException(nameof(setupDestinationFile));
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                _webClient.DownloadFile($"http://myurl.com/{customerName}/{installerName}", _setupDestinationFile);

                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }
    }

}