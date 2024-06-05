
using Administracion_Hotelera_API.conection;
using Administracion_Hotelera_API.Models;
using Dapper;
using MySql.Data.MySqlClient;
using Mysqlx.Cursor;

namespace Administracion_Hotelera_API.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private ConnectionMySQL _connectionString;

        public RoomRepository(ConnectionMySQL connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection sqlConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Object>> GetAllByHotel(int id_hotel)
        {
            var db = sqlConnection();

            var QUERY = @"SELECT * FROM rooms WHERE id_hotel = @id_hotel;";

            return await db.QueryAsync<Room>(QUERY, new { id_hotel });
        }

        public async Task<IEnumerable<Object>> GetAllBooking(DateTime date_start, DateTime date_end, string city,
            string capacity)
        {
            var db = sqlConnection();

            string start = date_start.ToString("yyyy-MM-dd"),
                end = date_end.ToString("yyyy-MM-dd");

            var QUERY = @"SELECT r.*, h.name AS hotel, h.city, @date_start AS date_start, " +
                "@date_end AS date_end FROM rooms r JOIN hotels h ON r.id_hotel = h.id WHERE r.id NOT IN " +
                "(SELECT b.id_room FROM bookings b WHERE " +
                "(@date_start BETWEEN b.date_start AND b.date_end OR @date_end " +
                "BETWEEN b.date_start AND b.date_end OR b.date_start BETWEEN @date_start " +
                "AND @date_end OR b.date_end BETWEEN @date_start AND @date_end))" +
                "AND r.status = true";

            if(city != null) { QUERY = QUERY + " AND h.city = @city"; }
            if (capacity != null) { QUERY = QUERY + " AND r.capacity >= @capacity"; }

            return await db.QueryAsync<RoomForBooking>(QUERY, new { date_start = start, date_end = end,
                city = city, capacity = capacity});
        }

        public async Task<Object> GetRoomById(int id)
        {
            var db = sqlConnection();

            var QUERY = @"SELECT * FROM rooms WHERE id = @id;";

            return await db.QueryFirstOrDefaultAsync<Room>(QUERY, new { id = id });
        }

        public async Task<bool> InsertRoom(RoomForCreation room)
        {
            var db = sqlConnection();

            var QUERY = "INSERT INTO rooms (id_hotel, status, value, tax, type, capacity, " +
                "location) VALUES (@id_hotel, @status, @value, @tax, @type, @capacity, @location);";

            var result = await db.ExecuteAsync(QUERY, new { room.id_hotel, room.status, room.value, 
                room.tax, room.type, room.capacity, room.location});

            return result > 0;
        }

        public async Task<bool> UpdateRoom(RoomForCreation room)
        {
            var db = sqlConnection();

            var QUERY = "UPDATE rooms SET " +
                "status=@status, " +
                "value=@value, " +
                "tax=@tax, " +
                "type=@type, " +
                "capacity=@capacity, " +
                "location=@location " +
                "WHERE id=@id;";

            var result = await db.ExecuteAsync(QUERY, new { room.status, room.value, 
                room.tax, room.type, room.capacity, room.location, room.id});
            return result > 0;
        }
    }
}
