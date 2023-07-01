using API.DTOs.Booking;
using API.Models;

namespace API.Contracts
{
    public interface IBookingRepository : IGeneralRepository<Booking>
    {
        IEnumerable<BookingDetailsDto> GetBookingDetails();
        /*ICollection<Booking> GetAll();
        Booking? GetByGuid(Guid guid);
        Booking Create(Booking booking);
        bool Update(Booking booking);
        bool Delete(Guid guid);*/
    }
}
