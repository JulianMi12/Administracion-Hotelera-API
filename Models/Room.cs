using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace Administracion_Hotelera_API.Models
{
    public class Room
    {
        public int id { get; set; }
        public int id_hotel { get; set; }
        [JsonIgnore]
        public Boolean status { get; set; }
        public float value { get; set; }
        public float tax { get; set; }
        public string type { get; set; }
        [JsonIgnore]
        public int capacity { get; set; }
        public string location { get; set; }
        public string statusDescAdmin
        {
            get
            {
                return status ? "Habilitado" : "Deshabilitado";
            }
        }

        public string capacityView
        {
            get
            {
                return capacity + " Personas";
            }

        }
    }

    public class RoomForCreation()
    {
        public int id { get; set; }
        public required int id_hotel { get; set; }
        public required Boolean status { get; set; }
        public required float value { get; set; }
        public required float tax { get; set; }
        public required string type { get; set; }
        public required int capacity { get; set; }
        public required string location { get; set; }
    }

    public class RoomForBooking()
    {
        public int id { get; set; }
        public int id_hotel { get; set; }
        public string hotel { get; set; }
        public string city { get; set; }
        [JsonIgnore]
        public  Boolean status { get; set; }
        public required float value { get; set; }
        public required float tax { get; set; }
        public required string type { get; set; }
        public string capacityView
        {
            get
            {
                return capacity + " Personas";
            }

        }
        [JsonIgnore]
        public  int capacity { get; set; }
        public required string location { get; set; }
        public DateTime date_start { get; set; }
        public DateTime date_end { get; set; }
    }
}
