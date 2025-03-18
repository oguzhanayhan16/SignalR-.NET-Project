using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService aboutService;
        private readonly IMapper mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            this.aboutService = aboutService;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult AboutList()
        {
            var values = aboutService.TGetListAll();
            return Ok(mapper.Map<List<ResultAboutDto>>(values));
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            var value = mapper.Map<About>(createAboutDto);
            aboutService.TAdd(value);

          
            return Ok("Hakkımda başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var values = aboutService.TGetByID(id);
            aboutService.TDelete(values);    
            return Ok("Silme Başarılı");
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto update)
        {
            var value = mapper.Map<About>(update);
            aboutService.TUpdate(value);

            return Ok("Update başarılı");
        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var values = aboutService.TGetByID(id);
            
            return Ok(mapper.Map<List<GetAboutDto>>(values));
        }
    }
}
