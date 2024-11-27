using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mock
{
    public class MockFileReader : IFileReader
    {
        public string ReadPath(string path)
        {
            return "";
        }
    }
}
