namespace TestNinja.Mocking
{
    public class Program
    {
        public void Main()
        {
            var service = new VideoService();
            var title = service.ReadVideoTitle();//DI method
        }
    }
}
