using FluentAssertions;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {    //Setup will be called bf run every test
        //teardown is gonna be called after each test
        private TestNinja.Fundamentals.Math _math;

        [SetUp]
        public void MathSetUp()
        {
            _math = new TestNinja.Fundamentals.Math();
        }

        [Test]
        public void Add_WhenCalled_ReturnAdditionOfTwoNumbers()
        {
            //Arrange

            //Act
            var result = _math.Add(8, 100);
            //Assert
            result.Should().Be(108);
        }

        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(2, 2, 2)]
        public void MaxWhenCalledReturnGreatherArgument(int a, int b, int expected)
        {
            //Arrange

            //Act
            var result = _math.Max(a, b);
            //Assert
            result.Should().Be(expected);
        }

        [Test]
        [Ignore("Not using TestCase")]
        public void Max_FirstArgIsGreater_ReturnFirstArg()
        {
            //Arrange

            //Act
            var result = _math.Max(100, 50);
            //Assert
            result.Should().Be(100);
        }

        [Test]
        [Ignore("Not using TestCase")]
        public void Max_FirstArgIsSmaller_ReturnSecondArg()
        {
            //Arrange

            //Act
            var result = _math.Max(50, 100);
            //Assert
            result.Should().Be(100);
        }

        [Test]
        [Ignore("Not using TestCase")]
        public void Max_ArgsAreEqual_ReturnSameArg()
        {
            //Arrange

            //Act
            var result = _math.Max(100, 100);
            //Assert
            result.Should().Be(100);
        }

        [Test]
        public void GetOddNumbersWhenLimitIsGreatherThanZeroReturnsNumbersUpToLimit()
        {
            //Arrange

            //Act
            var result = _math.GetOddNumbers(5);

            //Assert
            result.Should().NotBeEmpty().And.HaveCount(3);


        }
    }
}
