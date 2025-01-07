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
        private IVideoRepository _videoRepository;
        private VideoService _videoService;

        [SetUp]
        public void SetUp()
        {
            //Mocking external dependencies
            _fileReader = Substitute.For<IFileReader>();
            _videoRepository = Substitute.For<IVideoRepository>();
            _videoService = new VideoService(_fileReader, _videoRepository);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnsEmptyString()
        {
            // Arrange
            var videos = new List<Video>
            {
                new() { Id = 1, Title = "Title Suresha Das1", IsProcessed = true },
                new() { Id = 2, Title = "Title Suresha Das2", IsProcessed = true },
                new() { Id = 3, Title = "Title Suresha Das3", IsProcessed = true }
            };

            _videoRepository.GetUnprocessedVideos().Returns(videos.Where(v => !v.IsProcessed));

            // Act
            var result = _videoService.GetUnprocessedVideosAsCsv();

            // Assert
            result.Should().BeEmpty();
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_SomeVideosAreUnprocessed_ReturnsCsvString()
        {
            // Arrange
            var videos = new List<Video>
            {
                new() { Id = 1, Title = "Title Suresha Das1", IsProcessed = false },
                new() { Id = 2, Title = "Title Suresha Das2", IsProcessed = true },
                new() { Id = 3, Title = "Title Suresha Das3", IsProcessed = false }
            };

            _videoRepository.GetUnprocessedVideos().Returns(videos.Where(v => !v.IsProcessed));

            // Act
            var result = _videoService.GetUnprocessedVideosAsCsv();

            // Assert
            result.Should().Be("1,3");
        }

        [Test]
        public void ReadVideoTitleFromEmptyFileReturnErrorMessage()
        {
            //Arrange
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
            //Arrange
            var video = new Video { Id = 1, Title = "Title Suresha Das", IsProcessed = true };
            var videoJson = JsonConvert.SerializeObject(video);
            _fileReader.ReadPath(Arg.Any<string>()).Returns(videoJson);

            //Act
            var title = _videoService.ReadVideoTitle();

            //Assert
            title.Should().Be("Title Suresha Das");
        }


    }
}

