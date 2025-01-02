using FluentAssertions;
using MockTests.Mocking;
using TestNinja.Mocking;


namespace MockTests
{
    [TestFixture]
    public class VideoServiceTests
    {


        [Test]
        public void ReadVideoTitleFromEmptyFileReturnErrorMessage()
        {
            var service = new VideoService(new MockFileReader());
            var title = service.ReadVideoTitle();

            title.Should().StartWith("Error");
            title.Should().ContainEquivalentOf("Error");

        }
    }
}

