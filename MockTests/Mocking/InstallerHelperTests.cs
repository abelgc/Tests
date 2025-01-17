using NSubstitute;
using System.Net;
using TestNinja.Mocking;

namespace MockTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private const string CustomerName = "Suresha Das";
        private const string InstallerName = "admin";
        private IWebClient _webClientMock;
        private InstallerHelper _installerHelper;
        private string _setupDestinationFile;

        [SetUp]
        public void SetUp()
        {
            _webClientMock = Substitute.For<IWebClient>();
            _setupDestinationFile = "setup.exe";
            _installerHelper = new InstallerHelper(_webClientMock, _setupDestinationFile);
        }

        [Test]
        public void DownloadInstaller_WhenCalled_DownloadsFileFromUrl()
        {
            // Arrange
            // Act
            _installerHelper.DownloadInstaller(CustomerName, InstallerName);

            // Assert
            _webClientMock.Received().DownloadFile(
                Arg.Is<string>(s => s == $"http://myurl.com/{CustomerName}/{InstallerName}"),
                Arg.Is<string>(s => s == _setupDestinationFile));
        }

        [Test]
        public void DownloadInstaller_DownloadFileFails_ReturnWebException()
        {
            // Arrange
            _webClientMock.When(x => x.DownloadFile(Arg.Any<string>(), Arg.Any<string>()))
                     .Do(x => { throw new WebException(); });

            var restult = _installerHelper.DownloadInstaller(CustomerName, InstallerName);

            // Act & Assert
            Assert.That(restult, Is.False);

        }

    }
}
