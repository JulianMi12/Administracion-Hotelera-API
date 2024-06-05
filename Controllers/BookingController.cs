using Administracion_Hotelera_API.Models;
using Administracion_Hotelera_API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Mysqlx.Crud;
using System.ComponentModel.DataAnnotations;

namespace Administracion_Hotelera_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private IPassengerRepository _passengerRepository;
        private IRoomRepository _roomRepository;

        public BookingController(IBookingRepository bookingRepository, 
            IPassengerRepository passengerRepository,
            IRoomRepository roomRepository)
        {
            _bookingRepository = bookingRepository;
            _passengerRepository = passengerRepository;
            _roomRepository = roomRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            return Ok(await _bookingRepository.GetAllBookings());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            return Ok(await _bookingRepository.GetBookingById(id));
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetAllBooking([FromQuery] DateTime date_start, [FromQuery] DateTime date_end,
            [FromQuery] string city = null, [FromQuery] string capacity = null)
        {
            if (date_start != DateTime.MinValue && date_end != DateTime.MinValue)
            {
                return Ok(await _roomRepository.GetAllBooking(date_start, date_end, city, capacity));
            }
            else { return BadRequest("Valide las fechas ingresadas."); }
            
        }

        [HttpPost]
        public async Task<IActionResult> InsertBooking([FromBody] BookingAndPassenger bp)
        {
            if (bp == null) { return BadRequest(); }

            if (!ModelState.IsValid) { return BadRequest(); }

            if (validar(bp))
            {
                var passenger = bp.passenger;
                var exist = await _passengerRepository.GetPassengerById(passenger.id);
                if (exist == null)
                {
                    await _passengerRepository.InsertPassenger(passenger);
                }
                else
                {
                    await _passengerRepository.UpdatePassenger(passenger);
                }

                BookingForCreation booking = new()
                {
                    id_hotel = bp.id_hotel,
                    id_passenger = passenger.id,
                    id_room = bp.id_room,
                    date_start = bp.date_start,
                    date_end = bp.date_end
                };

                var newBooking = await _bookingRepository.InsertBooking(booking);

                Booking book = (Booking)await _bookingRepository.GetBookingById(newBooking);

                Email email = new Email();
                var body = email.body(book.first_name_pssg, book.date_start, book.date_end, book.type_room, book.id_room, book.value_room, book.tax_room);
                email.sendEmail(book.email_pssg, "Información de tu Reserva", body);

                return Ok("Reserva creada correctamente.");
            }
            else { return BadRequest("Valide los datos ingresados."); }
        }

        public bool validar(BookingAndPassenger bp)
        {
            if (bp.id_room == 0) { return false; }
            if (bp.id_hotel == 0) { return false; }
            if (bp.date_start == DateTime.MinValue) {  return false; }
            if (bp.date_end == DateTime.MinValue) { return false; }

            if (bp.passenger.id == 0) { return false; }
            if (string.IsNullOrEmpty(bp.passenger.first_name)) { return false; }
            if (string.IsNullOrEmpty(bp.passenger.last_name)) { return false; }
            if (bp.passenger.date_birth == DateTime.MinValue) { return false; }
            if (string.IsNullOrEmpty(bp.passenger.gender)) { return false; }
            if (string.IsNullOrEmpty(bp.passenger.type_doc)) { return false; }
            if (string.IsNullOrEmpty(bp.passenger.email)) { return false; }
            if (string.IsNullOrEmpty(bp.passenger.phone)) { return false; }
            if (string.IsNullOrEmpty(bp.passenger.emergency_contact)) { return false; }

            return true;
        }
    }
}
