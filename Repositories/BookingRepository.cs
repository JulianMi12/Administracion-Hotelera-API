
using Administracion_Hotelera_API.conection;
using Administracion_Hotelera_API.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace Administracion_Hotelera_API.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        public ConnectionMySQL _connectionString;

        public BookingRepository(ConnectionMySQL connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection sqlConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Object>> GetAllBookings()
        {
            var db = sqlConnection();

            var QUERY = @"SELECT b.*, h.name AS name_hotel, h.city AS  city_hotel, " +
                " r.type AS type_room, p.first_name AS first_name_pssg, p.last_name AS last_name_pssg" +
                " FROM bookings b " +
                "JOIN hotels h ON b.id_hotel = h.id " +
                "JOIN rooms r ON b.id_room = r.id " +
                "JOIN passenger p ON b.id_passenger = p.id;";

            return await db.QueryAsync<BookingView>(QUERY, new { });
        }

        public async Task<object> GetBookingById(int id)
        {
            var db = sqlConnection();

            var QUERY = "SELECT b.*, " +
                "h.name AS name_hotel, h.city AS  city_hotel, " +
                "r.location AS location_room, r.type AS type_room, r.capacity AS capacity_room, " +
                "r.value AS value_room, r.tax AS tax_room, " +
                "p.type_doc AS type_doc_pssg, p.id AS doc_pssg, p.first_name AS first_name_pssg, " +
                "p.last_name AS last_name_pssg, p.phone AS phone_pssg, p.email AS email_pssg " +
                "FROM bookings b " +
                "JOIN hotels h ON b.id_hotel = h.id " +
                "JOIN rooms r ON b.id_room = r.id " +
                "JOIN passenger p ON b.id_passenger = p.id " +
                "WHERE b.id = @id";

            return await db.QueryFirstOrDefaultAsync<Booking>(QUERY, new { id });
        }

        public async Task<int> InsertBooking(BookingForCreation booking)
        {
            var db = sqlConnection();

            var QUERY = @"INSERT INTO bookings (id_hotel, id_room, id_passenger, date_start, " +
                "date_end) VALUES (@id_hotel, @id_room, @id_passenger, @date_start, @date_end); " +
                "SELECT LAST_INSERT_ID();";

            var result = await db.ExecuteScalarAsync<int>(QUERY, new { booking.id_hotel, booking.id_room,
                booking.id_passenger, booking.date_start, booking.date_end });

            return result;
        }
    }
}
