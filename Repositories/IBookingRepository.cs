using Administracion_Hotelera_API.Models;

namespace Administracion_Hotelera_API.Repositories
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Object>> GetAllBookings();
        Task<Object> GetBookingById(int id);
        Task<int> InsertBooking(BookingForCreation booking);
    }
}
