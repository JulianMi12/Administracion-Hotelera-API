using System.Text.Json.Serialization;

namespace Administracion_Hotelera_API.Models
{
    public class Hotel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        [JsonIgnore]
        public Boolean status { get; set; }
        public string statusDesc
        {
            get
            {
                return status ? "Habilitado" : "Deshabilitado";
            }
        }

    }

    public class HotelForCreation
    {
        public int id { get; set; }
        public required string name { get; set; }
        public required string city { get; set; }
        public required Boolean status { get; set; }
    }
}
