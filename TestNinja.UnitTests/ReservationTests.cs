using FluentAssertions;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            //Arrange
            var reservation = new Reservation();
            //Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });
            //Assert
            //Assert.IsTrue(result);
            result.Should().Be(true);
        }

        [Test]
        public void CanBeCancelledBy_SameUserCanellReservation_ReturnsTrue()
        {
            //Arrange
            var madeByuser = new User();
            var reservation = new Reservation { MadeBy = madeByuser };
            //Act
            var restult = reservation.CanBeCancelledBy(madeByuser);
            //Assert
            restult.Should().Be(true);
        }

        [Test]
        public void CanBeCancelledBy_DifferentUserCanellReservation_ReturnsFalse()
        {
            //Arrange
            var madeByuser = new User();
            var reservation = new Reservation { MadeBy = madeByuser };
            //Act
            var restult = reservation.CanBeCancelledBy(new User());
            //Assert
            restult.Should().NotBe(true);

        }
    }
}