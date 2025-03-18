using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService SocialMediaService, IMapper mapper)
        {
            _socialMediaService = SocialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult SocialMediaCreate(CreateSocialMediaDto create)
        {
            _socialMediaService.TAdd(new SocialMedia()
            {
                Title = create.Title,
                Url = create.Url,
                Icon = create.Icon,
             
            });
            return Ok(" SocialMedia eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult SocialMediaDelete(int id)
        {
            var values = _socialMediaService.TGetByID(id);
            _socialMediaService.TDelete(values);
            return Ok("Silme Başarılı");
        }
        [HttpPut]
        public IActionResult SocialMediaUpdate(UpdateSocialMediaDto create)
        {
            _socialMediaService.TUpdate(new SocialMedia()
            {
                SocialMediaID=create.SocialMediaID,
                Title = create.Title,
                Url = create.Url,
                Icon = create.Icon,

            });
            return Ok("SocialMedia güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult SocialMediaGet(int id)
        {
            var values = _socialMediaService.TGetByID(id);

            return Ok(values);
        }
    }
}
