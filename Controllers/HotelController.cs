using Administracion_Hotelera_API.Models;
using Administracion_Hotelera_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using System.ComponentModel.DataAnnotations;

namespace Administracion_Hotelera_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            return Ok(await _hotelRepository.GetAllHotels());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            return Ok(await _hotelRepository.GetHotelById(id));
        }

        [HttpPost]
        public async Task<IActionResult> InsertHotel([FromBody] HotelForCreation hotel)
        {
            if (hotel == null) { return BadRequest(); }

            if (!ModelState.IsValid) { return BadRequest(); }

            if (validar(hotel))
            {
                var result = await _hotelRepository.InsertHotel(hotel);

                if (result) { return Ok("Hotel insertado correctamente."); }
                else { return Ok("Ha ocurrido un error en la inserción."); }
            }
            else { return BadRequest("Valide los datos ingresados."); }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHotel([FromBody] HotelForCreation hotel)
        {
            if (hotel == null) { return BadRequest(); }

            if (!ModelState.IsValid) { return BadRequest(); }

            if (validar(hotel))
            {
                    var result = await _hotelRepository.UpdateHotel(hotel);

                if (result) { return Ok("Hotel modificado correctamente."); }
                else { return Ok("Ha ocurrido un error en la actualización."); }
            }
            else { return BadRequest("Valide los datos ingresados."); }
        }

        public bool validar(HotelForCreation hotel)
        {
            if (string.IsNullOrEmpty(hotel.name)) { return false; }
            if (string.IsNullOrEmpty(hotel.city)) { return false; }

            return true;
        }
    }
}
