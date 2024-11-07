using FluentAssertions;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        private ErrorLogger errorLog;

        [SetUp]
        public void SetUp()
        {
            errorLog = new ErrorLogger();
        }

        [Test]
        public void LogWhenCalledSetLastErrorProperty()
        {   //Arrange
            //Act
            errorLog.Log("abc");
            errorLog.Log("xyz");
            //Assert
            errorLog.LastError.Should().BeSameAs("xyz");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void WhenErrorThrowArgumentNullException(string error)
        {    //Arrange
             //Act
            errorLog.Log(error);
            //Assert
            Assert.That(() => errorLog.Log(error), Throws.ArgumentNullException);
            //Assert.That(() => errorLog.Log(error), Throws.Exception.TypeOf<ArgumentNullException>);
        }

        [Test]
        public void WhenValidLogErrorRaiseErrorLoggedEvent()
        {   //Arrange
            var id = Guid.Empty;
            errorLog.ErrorLoggedEvent += (sourceEvent, eventArgs) => { id = eventArgs; };
            //Act
            errorLog.Log("abc");
            //Assert
            id.Should().NotBeEmpty();
        }
    }
}
