using FluentAssertions;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        private HtmlFormatter _htmlFormater;

        [SetUp]
        public void MathSetUp()
        {
            _htmlFormater = new HtmlFormatter();
        }

        [TestCase("this text must be bold")]
        public void FormatsBoldWhenCalledAndEnclosesWithStrongElement(string content)
        {
            //Arrange
            //Act

            var restult = _htmlFormater.FormatAsBold(content);
            //Assert
            restult.Should().StartWith("<strong>").And.EndWith("</strong>").And.Contain("bold");

        }

    }
}
