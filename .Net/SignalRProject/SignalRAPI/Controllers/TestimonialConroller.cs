using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialConroller : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialConroller(ITestimonialService TestimonialService, IMapper mapper)
        {
            _testimonialService = TestimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult TestimonialCreate(CreateTestimonialDto create)
        {
            _testimonialService.TAdd(new Testimonial()
            {
                Name = create.Name,
                Title = create.Title,
                Description = create.Description,
                Status = true,
                ImageUrl = create.ImageUrl
            });
            return Ok(" Testimonial eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult TestimonialDelete(int id)
        {
            var values = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(values);
            return Ok("Silme Başarılı");
        }
        [HttpPut]
        public IActionResult TestimonialUpdate(UpdateTestimonialDto create)
        {
            _testimonialService.TUpdate(new Testimonial()
            {
                TestimonialID = create.TestimonialID,
                Name = create.Name,
                Title = create.Title,
                Description = create.Description,
                Status = true,
                ImageUrl = create.ImageUrl
            });
            return Ok("Testimonial güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult TestimonialGet(int id)
        {
            var values = _testimonialService.TGetByID(id);

            return Ok(values);
        }
    }
}
