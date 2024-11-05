using FluentAssertions;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {

        [Test]
        public void LogWhenCalledSetLastErrorProperty()
        {
            var errorLog = new ErrorLogger();

            errorLog.Log("abc");
            errorLog.Log("xyz");

            errorLog.LastError.Should().BeSameAs("xyz");

        }
    }
}
