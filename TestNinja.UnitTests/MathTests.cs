using FluentAssertions;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {    //Setup will be called bf run every test
        //teardown is gonna be called after each test
        private TestNinja.Fundamentals.Math _math;
        [SetUp]
        public void SetUp()
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

        [Test]
        public void Max_FirstArgIsGreater_ReturnFirstArg()
        {
            //Arrange

            //Act
            var result = _math.Max(100, 50);
            //Assert
            result.Should().Be(100);
        }

        [Test]
        public void Max_FirstArgIsSmaller_ReturnSecondArg()
        {
            //Arrange

            //Act
            var result = _math.Max(50, 100);
            //Assert
            result.Should().Be(100);
        }

        [Test]
        public void Max_FirstArgIsEqual_ReturnFirstArg()
        {
            //Arrange

            //Act
            var result = _math.Max(100, 100);
            //Assert
            result.Should().Be(100);
        }
    }
}
