using System.Text.Json.Serialization;

namespace Administracion_Hotelera_API.Models
{
    public class Booking
    {
        public int id { get; set; }
        [JsonIgnore]
        public int id_hotel { get; set; }
        [JsonIgnore]
        public int id_room { get; set; }
        [JsonIgnore]
        public int id_passenger { get; set; }
        public DateTime date_start { get; set; }
        public DateTime date_end { get; set; }
        public string name_hotel { get; set; }
        public string city_hotel { get; set; }
        public string location_room { get; set; }
        public string type_room { get; set; }
        public int capacity_room { get; set; }
        public float value_room { get; set; }
        public float tax_room { get; set; }
        public string type_doc_pssg { get; set; }
        public string doc_pssg { get; set; }
        public string first_name_pssg { get; set; }
        public string last_name_pssg { get; set; }
        public string phone_pssg { get; set; }
        public string email_pssg { get; set; }
    }

    public class BookingView
    {
        public int id { get; set; }
        public int id_hotel { get; set; }
        public string name_hotel { get; set; }
        public string city_hotel { get; set; }
        public int id_room { get; set; }
        public string type_room { get; set; }
        public int id_passenger { get; set; }
        public string first_name_pssg { get; set; }
        public string last_name_pssg { get; set; }
        public DateTime date_start { get; set; }
        public DateTime date_end { get; set; }
    }

    public class BookingForCreation
    {
        public int id { get; set; }
        public required int id_hotel { get; set; }
        public required int id_room { get; set; }
        [JsonIgnore]
        public int id_passenger { get; set; }
        public required DateTime date_start { get; set; }
        public required DateTime date_end { get; set; }
    }

    public class BookingAndPassenger
    {
        public required int id_hotel { get; set; }
        public required int id_room { get; set; }
        public required DateTime date_start { get; set; }
        public required DateTime date_end { get; set; }
        public Passenger passenger { get; set; }
    }
}