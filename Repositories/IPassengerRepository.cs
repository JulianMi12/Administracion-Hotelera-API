using Administracion_Hotelera_API.Models;

namespace Administracion_Hotelera_API.Repositories
{
    public interface IPassengerRepository
    {
        Task<Object> GetPassengerById(int id);
        Task<bool> InsertPassenger(Passenger passenger);
        Task<bool> UpdatePassenger(Passenger passenger);
    }
}
