using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult ContactCreate(CreateContactDto create)
        {
            _contactService.TAdd(new Contact()
            {
                Location = create.Location,
                Phone = create.Phone,
                Mail=create.Mail,
                FooterDescription=create.FooterDescription,
                FooterTitle=create.FooterTitle,
                OpenDays=create.OpenDays,
                OpenDaysDescription=create.OpenDaysDescription,
                OpenHours=create.OpenHours
            });
            return Ok("Contact eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult ContactDelete(int id)
        {
            var values = _contactService.TGetByID(id);
            _contactService.TDelete(values);
            return Ok("Silme Başarılı");
        }
        [HttpPut]
        public IActionResult ContactUpdate(UpdateContactDto create)
        {
            _contactService.TUpdate(new Contact()
            {
                ContactID = create.ContactID,
                Location = create.Location,
                Phone = create.Phone,
                Mail = create.Mail,
                FooterDescription = create.FooterDescription,
                FooterTitle = create.FooterTitle,
                OpenDays = create.OpenDays,
                OpenDaysDescription = create.OpenDaysDescription,
                OpenHours = create.OpenHours
            });
            return Ok("Contact güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult ContactGet(int id)
        {
            var values = _contactService.TGetByID(id);

            return Ok(values);
        }
    }
}
