using MySql.Data.MySqlClient;

namespace Administracion_Hotelera_API.conection
{
    public class ConnectionMySQL
    {
        public ConnectionMySQL(string connectionString) => ConnectionString = connectionString;

        public string ConnectionString { get; set; }
    }
}
