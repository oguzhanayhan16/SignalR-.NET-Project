using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult DiscountCreate(CreateDiscountDto create)
        {
            _discountService.TAdd(new Discount()
            {
                Title = create.Title,
                Amount = create.Amount,
                Description = create.Description,
                ImageUrl = create.ImageUrl,
                Status=false
            });
            return Ok(" Discount eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DiscountDelete(int id)
        {
            var values = _discountService.TGetByID(id);
            _discountService.TDelete(values);
            return Ok("Silme Başarılı");
        }
        [HttpPut]
        public IActionResult DiscountUpdate(UpdateDiscountDto create)
        {
            _discountService.TUpdate(new Discount()
            {
                DiscountID =create.DiscountID,
                Title = create.Title,
                Amount = create.Amount,
                Description = create.Description,
                ImageUrl = create.ImageUrl,
                Status = false
            });
            return Ok("Discount güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult DiscountGet(int id)
        {
            var values = _discountService.TGetByID(id);

            return Ok(values);
        }
        [HttpGet("ChangeStatusToTrue/{id}")]
        public IActionResult ChangeStatusToTrue(int id)
        {
            _discountService.TChangeStatusToTrue(id);
            return Ok("Rezervasyon alındı");
        }
        [HttpGet("ChangeStatusToFalse/{id}")]
        public IActionResult ChangeStatusToFalse(int id)
        {
            _discountService.TChangeStatusToFalse(id);
            return Ok("Rezervasyon alındı");
        }
        [HttpGet("GetListByStatusTrue")]
        public IActionResult GetListByStatusTrue()
        {
            return Ok(_discountService.TGetListByStatusTrue());
        }
    }
}
