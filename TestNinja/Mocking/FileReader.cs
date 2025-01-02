using System.IO;

namespace TestNinja.Mocking
{
    public class FileReader : IFileReader
    {
        public string ReadPath(string path)
        {
            return File.ReadAllText("video.txt");
        }
    }
}
