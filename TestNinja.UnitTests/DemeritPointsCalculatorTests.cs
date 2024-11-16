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
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new DemeritPointsCalculator();
        }

        [Test]
        public void CalculateDemeritPointsWhenSpeedEqualToSpeedLimitReturnsZero()
        {
            var result = calculator.CalculateDemeritPoints(65);
            result.Should().BeOneOf(0);
        }

        [Test]
        public void CalculateDemeritPointsWhenSpeedJustAboveLimitReturns0()
        {
            var result = calculator.CalculateDemeritPoints(66);
            result.Should().BeOneOf(0);
        }

        [Test]
        public void CalculateDemeritPointsWhenSpeedWellAboveLimitReturnsCorrectDemeritPoints3()
        {
            var result = calculator.CalculateDemeritPoints(80);
            result.Should().BeOneOf(3);
        }

        [Test]
        public void CalculateDemeritPointsWhenSpeedAtMaximumReturnsCorrectDemeritPoints()
        {
            calculator.Invoking(c => c.CalculateDemeritPoints(301)).Should().Throw<ArgumentOutOfRangeException>();
            //Assert.Throws<ArgumentOutOfRangeException>(() => calculator.CalculateDemeritPoints(301));
        }

        [Test]
        public void CalculateDemeritPointsWhenSpeedBelowZeroThrowsArgumentOutOfRangeException()
        {
            calculator.Invoking(c => c.CalculateDemeritPoints(-1)).Should().Throw<ArgumentOutOfRangeException>();

            Assert.Throws<ArgumentOutOfRangeException>(() => calculator.CalculateDemeritPoints(-1));
        }

        [Test]
        public void CalculateDemeritPointsWhenSpeedSlightlyAboveLimitNoDemeritPoints()
        {
            var result = calculator.CalculateDemeritPoints(67);
            result.Should().BeOneOf(0);
        }
    }

}
