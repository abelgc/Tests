using FluentAssertions;
using TestNinja.Mocking;
using TestNinja.UnitTests.Mock;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        [Test]
        public void ReadVideoTitleFromEmptyFileReturnErrorMessage()
        {
            var service = new VideoService();
            var title = service.ReadVideoTitle(new MockFileReader());

            title.Should().StartWith("Error");
            title.Should().ContainEquivalentOf("Error");

        }
    }
}
