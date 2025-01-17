using System.Linq;

namespace TestNinja.Mocking
{
    public interface IBookingRepository
    {
        IQueryable<Booking> GetActiveBookings(int? excludedBookingId = null);
    }

    public class BookingRepository : IBookingRepository
    {
        private readonly UnitOfWork _unitOfWork;

        public BookingRepository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IQueryable<Booking> GetActiveBookings(int? excludedBookingId = null)
        {
            var bookings = _unitOfWork.DoQuery<Booking>()
            .Where(b => b.Status != "Cancelled");

            if (excludedBookingId.HasValue)
            {
                bookings = bookings.Where(b => b.Id != excludedBookingId.Value);
            }

            return bookings;
        }
    }
}
