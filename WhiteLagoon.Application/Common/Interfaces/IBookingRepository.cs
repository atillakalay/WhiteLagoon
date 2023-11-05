using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Application.Common.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        void Update(Booking booking);
        void UpdateStatus(int bookingId,string bookingStatus);
        void UpdateStripePaymentID(int bookingId,string sessionId,string paymentIntentId);
    }
}
