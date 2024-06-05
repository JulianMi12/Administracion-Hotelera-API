using Administracion_Hotelera_API.Models;

namespace Administracion_Hotelera_API.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Object>> GetAllByHotel(int id);
        Task<Object> GetRoomById(int id);
        Task<IEnumerable<Object>> GetAllBooking(DateTime date_start, DateTime date_end, 
            string city, string capacity);
        Task<bool> InsertRoom(RoomForCreation room);
        Task<bool> UpdateRoom (RoomForCreation room);
    }
}
