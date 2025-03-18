using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService bookingService;
        private readonly IMapper mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            this.bookingService = bookingService;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var values = bookingService.TGetListAll();
            return Ok(mapper.Map<List<BookingResultDto>>(values));
        }
        [HttpPost]
        public IActionResult BookingCreate(CreateBookingDto create)
        {
            var value = mapper.Map<Booking>(create);
            bookingService.TAdd(value);

            return Ok("Hakkımda başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult BookingDelete(int id)
        {
            var values = bookingService.TGetByID(id);
            bookingService.TDelete(values);
            return Ok("Silme Başarılı");
        }
        [HttpPut]
        public IActionResult BookingUpdate(UpdateBookingDto create)
        {
            var value = mapper.Map<Booking>(create);
            bookingService.TUpdate(value);
            return Ok("Update başarılı");
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var values = bookingService.TGetByID(id);

            return Ok(mapper.Map<List<GetBookingDto>>(values));
        }
        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookBookingStatusApprovedingList(int id)
        {
            bookingService.TBookingStatusApproved(id);
            return Ok("Rezervasyon alındı");
        }
        [HttpGet("BookingStatusCancelled/{id}")]
        public IActionResult BookingStatusCancelled(int id)
        {
            bookingService.TBookingStatusCancelled(id);
            return Ok("Rezervasyon iptal edildi");
        }
    }
}
