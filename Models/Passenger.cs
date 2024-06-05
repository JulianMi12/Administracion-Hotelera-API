namespace Administracion_Hotelera_API.Models
{
    public class Passenger
    {
        public required int id { get; set; }
        public required string first_name { get; set; }
        public required string last_name { get; set; }
        public required DateTime date_birth { get; set; }
        public required string gender { get; set; }
        public required string type_doc { get; set; }
        public required string email { get; set; }
        public required string phone { get; set; }
        public required string emergency_contact { get; set; }
    }
}
