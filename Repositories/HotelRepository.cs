using Administracion_Hotelera_API.conection;
using Administracion_Hotelera_API.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace Administracion_Hotelera_API.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private ConnectionMySQL _connectionString;

        public HotelRepository(ConnectionMySQL connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection sqlConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Object>> GetAllHotels()
        {
            var db = sqlConnection();

            var QUERY = @"SELECT * FROM hotels;";
            
            return await db.QueryAsync<Hotel>(QUERY, new {});
        }

        public async Task<Object> GetHotelById(int id)
        {
            var db = sqlConnection();

            var QUERY = @"SELECT * FROM hotels WHERE id = @id;";

            return await db.QueryFirstOrDefaultAsync<Hotel>(QUERY, new { id = id });
        }

        public async Task<bool> InsertHotel(HotelForCreation hotel)
        {
            var db = sqlConnection();

            var QUERY = @"INSERT INTO hotels (name, city, status) VALUES (" +
                "@name, @city, @status);";

            var result = await db.ExecuteAsync(QUERY, new { hotel.name, hotel.city, hotel.status });

            return result > 0;
        }

        public async Task<bool> UpdateHotel(HotelForCreation hotel)
        {
            var db = sqlConnection();

            var QUERY = @"UPDATE hotels SET " +
                "name=@name, " +
                "city=@city, " +
                "status=@status " +
                "WHERE id=@id;";

            var result = await db.ExecuteAsync(QUERY, new { hotel.name, hotel.city, hotel.status, hotel.id });

            return result > 0;
        }
    }
}
