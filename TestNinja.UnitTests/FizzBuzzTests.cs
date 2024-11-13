using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
     
        [Test]
        public void GetOutputInputIsDivisibleFor3And5ReturnFizzBuzz()
        {
            //Arrange

            //Act
            var result = FizzBuzz.GetOutput(30);
            //Assert
            result.Should().BeSameAs("FizzBuzz");
        }

        [Test]
        public void GetOutputInputIsDivisibleFor3OnlyReturnFizz()
        {
            //Arrange

            //Act
            var result = FizzBuzz.GetOutput(6);
            //Assert
            result.Should().BeSameAs("Fizz");
        }

        [Test]
        public void GetOutputInputIsDivisibleFor5OnlyReturnBuzz()
        {
            //Arrange

            //Act
            var result = FizzBuzz.GetOutput(10);
            //Assert
            result.Should().BeSameAs("Buzz");
        }

        [Test]
        public void GetOutputInputIsNotDivisibleFor3And5ReturnSameNumber()
        {
            //Arrange

            //Act
            var result = FizzBuzz.GetOutput(17);
            //Assert
            result.Should().Be("17");
        }
    }
}
