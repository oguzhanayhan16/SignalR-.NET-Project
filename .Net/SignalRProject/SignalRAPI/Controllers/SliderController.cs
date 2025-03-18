using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _SliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService SliderService, IMapper mapper)
        {
            _SliderService = SliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            var values = _mapper.Map<List<ResultSliderDto>>(_SliderService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult SliderCreate(CreateSliderDto create)
        {
            _SliderService.TAdd(new Slider()
            {
                Title1 = create.Title1,
                Description1 = create.Description1,
                Description2 = create.Description2,
                Description3 = create.Description3,
                Title2 = create.Title2,
                Title3 = create.Title3,
                
            });
            return Ok(" Slider eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult SliderDelete(int id)
        {
            var values = _SliderService.TGetByID(id);
            _SliderService.TDelete(values);
            return Ok("Silme Başarılı");
        }
        [HttpPut]
        public IActionResult SliderUpdate(UpdateSliderDto create)
        {
            _SliderService.TUpdate(new Slider()
            {
                SliderID=create.SliderID,
                Title1 = create.Title1,
                Description1 = create.Description1,
                Description2 = create.Description2,
                Description3 = create.Description3,
                Title2 = create.Title2,
                Title3 = create.Title3,

            });
            return Ok("Slider güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult SliderGet(int id)
        {
            var values = _SliderService.TGetByID(id);

            return Ok(values);
        }
    }
}
