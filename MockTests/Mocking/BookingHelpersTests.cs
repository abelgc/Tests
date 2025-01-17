using FluentAssertions;
using NSubstitute;
using TestNinja.Mocking;

namespace MockTests.Mocking
{
    public class BookingHelpersTests
    {
        private IBookingRepository _bookingRepository;

        [SetUp]
        public void SetUp()
        {
            _bookingRepository = Substitute.For<IBookingRepository>();
        }

        [Test]
        public void OverlappingBookingsExist_BookingIsCancelled_ReturnsEmptyString()
        {
            // Arrange
            var booking = new Booking { Status = "Cancelled" };

            // Act
            var result = BookingHelper.OverlappingBookingsExist(booking, _bookingRepository);

            // Assert
            result.Should().BeEmpty();
        }
    }
}
