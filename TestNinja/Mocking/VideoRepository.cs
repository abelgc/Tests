using System.Collections.Generic;
using System.Linq;

namespace TestNinja.Mocking
{

    public class VideoRepository : IVideoRepository
    {
        IEnumerable<Video> IVideoRepository.GetUnprocessedVideos()
        {
            using (var context = new VideoContext())
            {
                var videos =
                    (from video in context.Videos
                     where !video.IsProcessed
                     select video).ToList();

                return videos;
            }
        }
    }
}
