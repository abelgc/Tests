using FluentAssertions;
using NSubstitute;
using TestNinja.Mocking;

namespace MockTests.Mocking
{
    public class BookingHelpersTests
    {
        private IBookingRepository _bookingRepository;
        private Booking _booking;

        [SetUp]
        public void SetUp()
        {
            _bookingRepository = Substitute.For<IBookingRepository>();
            _booking = new Booking
            {
                Id = 1,
                Status = "Approved",
                ArrivalDate = new DateTime(2023, 10, 1),
                DepartureDate = new DateTime(2023, 10, 10),
                Reference = "Active"
            };
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

        [Test]
        public void OverlappingBookingsExist_NoOverlappingBooking_ReturnsEmptyString()
        {
            // Arrange
            // Arrange
            _bookingRepository.GetActiveBookings(_booking.Id).Returns(new List<Booking>
            {
                new Booking
                {
                    Id = 2,
                    Status = "Approved",
                    ArrivalDate = new DateTime(2023, 10, 11),
                    DepartureDate = new DateTime(2023, 10, 20),
                    Reference = "Active"
                },
                new Booking
                {
                    Id = 3,
                    Status = "Approved",
                    ArrivalDate = new DateTime(2023, 10, 25),
                    DepartureDate = new DateTime(2023, 10, 30),
                    Reference = "Active"
                },

            }.AsQueryable());

            // Act
            var result = BookingHelper.OverlappingBookingsExist(_booking, _bookingRepository);

            // Assert
            result.Should().BeEmpty();

        }

        [Test]
        public void OverlappingBookingsExist_WithOverlappingBooking_ReturnsReferenceBookingsString()
        {
            // Arrange
            var overlappingBooking = new Booking
            {
                Id = 2,
                ArrivalDate = new DateTime(2023, 10, 5),
                DepartureDate = new DateTime(2023, 10, 15),
                Status = "Active",
                Reference = "Overlapped booking"
            };

            _bookingRepository.GetActiveBookings(_booking.Id).Returns(new List<Booking> { overlappingBooking }.AsQueryable());

            // Act
            var result = BookingHelper.OverlappingBookingsExist(_booking, _bookingRepository);

            // Assert
            result.Should().NotBeEmpty();
            result.Should().Be(overlappingBooking.Reference);
        }
    }
}
