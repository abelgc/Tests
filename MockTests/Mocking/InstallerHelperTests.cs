using NSubstitute;
using System.Net;
using TestNinja.Mocking;

namespace MockTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
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
            var customerName = "Suresha Das";
            var installerName = "admin";

            // Act
            _installerHelper.DownloadInstaller(customerName, installerName);

            // Assert
            _webClientMock.Received().DownloadFile(
                Arg.Is<string>(s => s == $"http://myurl.com/{customerName}/{installerName}"),
                Arg.Is<string>(s => s == _setupDestinationFile));
        }

        [Test]
        public void DownloadInstaller_DownloadFileFails_ReturnWebException()
        {
            // Arrange
            _webClientMock.When(x => x.DownloadFile(Arg.Any<string>(), Arg.Any<string>()))
                     .Do(x => { throw new WebException(); });

            var customerName = "Suresha Das";
            var installerName = "admin";
            var restult = _installerHelper.DownloadInstaller(customerName, installerName);

            // Act & Assert
            Assert.That(restult, Is.False);

        }

    }
}
