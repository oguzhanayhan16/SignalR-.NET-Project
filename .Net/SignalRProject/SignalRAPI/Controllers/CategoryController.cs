using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _mapper.Map<List<CategoryResultDto>>(_categoryService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CategoryCreate(CreateCategoryDto create)
        {
            var value = _mapper.Map<Category>(create);
            _categoryService.TAdd(value);

            return Ok("Kategori eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var values = _categoryService.TGetByID(id);
            _categoryService.TDelete(values);
            return Ok("Silme Başarılı");
        }
        [HttpPut]
        public IActionResult CategoryUpdate(UpdateCategoryDto create)
        {
            var value = _mapper.Map<Category>(create);
            _categoryService.TUpdate(value);
            return Ok("Kategori güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult CategoryGet(int id)
        {
            var values = _categoryService.TGetByID(id);

            return Ok(values);
        }
        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            return Ok(_categoryService.TCategoryCount());

        }
        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            return Ok(_categoryService.TActiveCategoryCount());

        }
        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount()
        {
            return Ok(_categoryService.TPassiveCategoryCount());

        }
    }
}
