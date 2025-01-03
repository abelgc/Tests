using FluentAssertions;
using Newtonsoft.Json;
using NSubstitute;
using TestNinja.Mocking;


namespace MockTests
{
    [TestFixture]
    public class VideoServiceTests
    {
        private IFileReader _fileReader;
        private VideoService _videoService;

        [SetUp]
        public void SetUp()
        {
            _fileReader = Substitute.For<IFileReader>();
            _videoService = new VideoService(_fileReader);
        }


        [Test]
        public void ReadVideoTitleFromEmptyFileReturnErrorMessage()
        {
            // Arrange
            _fileReader.ReadPath(Arg.Any<string>()).Returns("");

            //Act
            var title = _videoService.ReadVideoTitle();

            //Assert
            title.Should().StartWith("Error");
            title.Should().ContainEquivalentOf("Error");

        }

        [Test]
        public void ReadVideoTitleFromVideoObjectFileReturnTitle()
        {
            // Arrange
            var video = new Video { Id = 1, Title = "Title Suresha Das", IsProcessed = true };
            var videoJson = JsonConvert.SerializeObject(video);
            _fileReader.ReadPath(Arg.Any<string>()).Returns(videoJson);

            //Act
            var title = _videoService.ReadVideoTitle();

            //Assert
            // Assert
            title.Should().Be("Title Suresha Das");

        }
    }
}

