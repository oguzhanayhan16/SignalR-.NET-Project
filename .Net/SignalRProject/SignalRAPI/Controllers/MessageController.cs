using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService messageService;

        public MessageController(IMessageService messageService)
        {
            this.messageService = messageService;
        }
        [HttpGet]
        public IActionResult MessageList()
        {
            var values = messageService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto dto)
        {
            Message message = new Message()
            {

                Mail = dto.Mail,
                MessageContent = dto.MessageContent,
                MessageSendDate=dto.MessageSendDate,
                NameSurname = dto.NameSurname,
                Phone=dto.Phone,
                Status=false,
                Subject=dto.Subject
            };
            messageService.TAdd(message);
            return Ok("Hakkımda başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var values = messageService.TGetByID(id);
            messageService.TDelete(values);
            return Ok("Silme Başarılı");
        }
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto dto)
        {
            Message message = new Message()
            {
                MessageID=dto.MessageID,
                Mail = dto.Mail,
                MessageContent = dto.MessageContent,
                MessageSendDate = dto.MessageSendDate,
                NameSurname = dto.NameSurname,
                Phone = dto.Phone,
                Status = false,
                Subject = dto.Subject
            };
            messageService.TUpdate(message);
            return Ok("Update başarılı");
        }
        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var values = messageService.TGetByID(id);

            return Ok(values);
        }
    }
}
