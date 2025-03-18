using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService notificationService;

        public NotificationController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }
        [HttpGet]
        public IActionResult NotificationList()
        {
            return Ok(notificationService.TGetListAll());

        }
        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            return Ok(notificationService.TNotificationCountByStatusFalse());

        }
        [HttpGet("GetAllNotificationByFalse")]
        public IActionResult GetAllNotificationByFalse()
        {
            return Ok(notificationService.TGetAllNotificationByFalse());

        }
        [HttpPost]
        public IActionResult CreateNotification( CreateNotificationDto dto)
        {
            notificationService.TAdd(new Notification()
            {
                Description = dto.Description,
                Icon = dto.Icon,
                Status = false,
                Type = dto.Type,
                Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
            });

            return Ok("Ekleme yapıldı");

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = notificationService.TGetByID(id);
            notificationService.TDelete(value);

            return Ok("Silme yapıldı");

        }
        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var value = notificationService.TGetByID(id);
            

            return Ok(value);

        }
        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto dto)
        {
            notificationService.TAdd(new Notification()
            {
                NotificationID=dto.NotificationID,
                Description = dto.Description,
                Icon = dto.Icon,
                Status = false,
                Type = dto.Type,
                Date = dto.Date
            });

            return Ok("güncelleme yapıldı");

        }
        [HttpGet("NotificationChangeToFalse/{id}")]
        public IActionResult NotificationChangeToFalse(int id)
        {
            notificationService.TNotificationChangeToFalse(id);
            return Ok("Güncelleme Yapıldı");
        }
        [HttpGet("NotificationChangeToTrue/{id}")]
        public IActionResult NotificationChangeToTrue(int id)
        {
            notificationService.TNotificationChangeToTrue(id);
            return Ok("Güncelleme Yapıldı");
        }
    }
}
