using System.IO;

namespace TestNinja.Mocking
{
    public interface IFileReader
    {
        string ReadPath(string path);
    }

    public class FileReader : IFileReader
    {
        public string ReadPath(string path)
        {
            return File.ReadAllText("video.txt");
        }
    }
}
