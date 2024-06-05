using Administracion_Hotelera_API.Models;
using Administracion_Hotelera_API.Repositories;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;

namespace Administracion_Hotelera_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllByHotel(int id)
        {
            return Ok(await _roomRepository.GetAllByHotel(id));
        }

        [HttpPost]
        public async Task<IActionResult> InsertRoom([FromBody] RoomForCreation room)
        {
            if (room == null) { return BadRequest(); }

            if (!ModelState.IsValid) { return BadRequest(); }

            if (validar(room))
            {
                var result = await _roomRepository.InsertRoom(room);
                if (result) { return Ok("Habitación insertada correctamente."); }
                else { return Ok("Ha ocurrido un error en la actualización."); }
            }
            else { return BadRequest("Valide los datos ingresados."); }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRoom([FromBody] RoomForCreation room)
        {
            if (room == null) { return BadRequest(); }

            if (!ModelState.IsValid) { return BadRequest(); }

            if (validar(room))
            {
                var result = await _roomRepository.UpdateRoom(room);
                if (result) { return Ok("Habitación modificada correctamente."); }
                else { return Ok("Ha ocurrido un error en la actualización."); }
            }
            else { return BadRequest("Valide los datos ingresados."); }
        }

        public bool validar(RoomForCreation room)
        {
            if (room.value == 0) { return false; }
            if (room.tax == 0) { return false; }
            if (string.IsNullOrEmpty(room.type)) { return false; }
            if (room.capacity == 0) { return false; }
            if (string.IsNullOrEmpty(room.location)) { return false; }

            return true;
        }
    }
}
