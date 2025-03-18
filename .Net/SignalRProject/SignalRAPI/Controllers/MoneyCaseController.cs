using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyCaseController : ControllerBase
    {
        private readonly IMoneyCaseService _moneyCase;

        public MoneyCaseController(IMoneyCaseService moneyCase)
        {
            _moneyCase = moneyCase;
        }
        [HttpGet]
        public IActionResult TotalMoneyCaseAmount()
        {
            return Ok(_moneyCase.TTotalMoneyCaseAmouny());
        }
    }
}
