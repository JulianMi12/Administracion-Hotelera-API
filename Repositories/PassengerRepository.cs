using Administracion_Hotelera_API.conection;
using Administracion_Hotelera_API.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace Administracion_Hotelera_API.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {
        private ConnectionMySQL _connectionString;

        public PassengerRepository(ConnectionMySQL connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection sqlConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<Object> GetPassengerById(int id)
        {
            var db = sqlConnection();

            var QUERY = @"SELECT * FROM passenger WHERE id = @id;";

            return await db.QueryFirstOrDefaultAsync<Hotel>(QUERY, new { id = id });
        }

        public async Task<bool> InsertPassenger(Passenger passenger)
        {
            var db = sqlConnection();

            var QUERY = @"INSERT INTO passenger (id, first_name, last_name, date_birth, gender, " +
                "type_doc, email, phone, emergency_contact) VALUES (@id, @first_name, @last_name, " +
                "@date_birth, @gender, @type_doc, @email, @phone, @emergency_contact);";

            var result = await db.ExecuteAsync(QUERY, new { passenger.id, passenger.first_name,
                passenger.last_name, passenger.date_birth, passenger.gender, passenger.type_doc,
                passenger.email, passenger.phone, passenger.emergency_contact });

            return result > 0;
        }

        public async Task<bool> UpdatePassenger(Passenger passenger)
        {
            var db = sqlConnection();

            var QUERY = @"UPDATE passenger SET " +
                "first_name=@first_name, " +
                "last_name=@last_name, " +
                "date_birth=@date_birth, " +
                "gender=@gender, " +
                "type_doc=@type_doc, " +
                "email=@email, " +
                "phone=@phone, " +
                "emergency_contact=@emergency_contact " +
                "WHERE id=@id;";

            var result = await db.ExecuteAsync(QUERY, new { passenger.first_name, passenger.last_name,
                passenger.date_birth, passenger.gender, passenger.type_doc, passenger.email,
                passenger.phone, passenger.emergency_contact, passenger.id});

            return result > 0;
        }
    }
}
