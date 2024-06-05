using Administracion_Hotelera_API.Models;

namespace Administracion_Hotelera_API.Repositories
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Object>> GetAllHotels();
        Task<Object> GetHotelById(int id);
        Task<bool> InsertHotel(HotelForCreation hotel);
        Task<bool> UpdateHotel(HotelForCreation hotel);
    }
}
