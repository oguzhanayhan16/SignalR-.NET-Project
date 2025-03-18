using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private IMenuTableService _menuTable;

        public MenuTablesController(IMenuTableService menuTable)
        {
            _menuTable = menuTable;
        }
        [HttpGet]

        public IActionResult menuTableCount()
        {
            return Ok(_menuTable.TMenuTableCount());
        }
        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDto dto)
        {
            _menuTable.TAdd(new MenuTable()
            {
                Name=dto.Name,
                Status=dto.Status
            });
            return Ok("Menü eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMenu(int id)
        {
            var values = _menuTable.TGetByID(id);
            _menuTable.TDelete(values);
            return Ok("Silme Başarılı");
        }
        [HttpPut]
        public IActionResult CategoryUpdate(UpdateMenuTableDto dto)
        {
            _menuTable.TAdd(new MenuTable()
            {
                MenuTableID=dto.MenuTableID,
                Name = dto.Name,
                Status = dto.Status
            });
            return Ok("Kategori güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult MenuGet(int id)
        {
            var values = _menuTable.TGetByID(id);

            return Ok(values);
        }
    }
}
