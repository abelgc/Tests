using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private IFileReader _fileReader;

        public VideoService(IFileReader fileReader = null)
        {
            _fileReader = fileReader ?? new FileReader();  //if null means no mock, then nomral class
        }

        public string ReadVideoTitle()
        {
            // FileReader: Move what touches external resource to extenral class to decouple
            var str = _fileReader.ReadPath("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();

            using (var context = new VideoContext())
            {
                var videos =
                    (from video in context.Videos
                     where !video.IsProcessed
                     select video).ToList();

                foreach (var v in videos)
                    videoIds.Add(v.Id);

                return String.Join(",", videoIds);
            }
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}