using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(values);
        }
        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductCategoryDto
            {
                Description = y.Description,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
                ProductID = y.ProductID,
                ProductName = y.ProductName,
                ProductStatus = y.ProductStatus,
                CategoryName = y.Category.CategoryName

            });
            return Ok(values.ToList());
        }
        [HttpPost]
        public IActionResult ProductCreate(CreateProductDto create)
        {
            _productService.TAdd(new Product()
            {
                ProductName = create.ProductName,
                Description = create.Description,
                ImageUrl = create.ImageUrl,
                Price = create.Price,
                ProductStatus = true,
                CategoryID = create.CategoryID
            });
            return Ok(" Product eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult ProductDelete(int id)
        {
            var values = _productService.TGetByID(id);
            _productService.TDelete(values);
            return Ok("Silme Başarılı");
        }
        [HttpPut]
        public IActionResult ProductUpdate(UpdateProductDto create)
        {
            _productService.TUpdate(new Product()
            {
                ProductID = create.ProductID,
                ProductName = create.ProductName,
                Description = create.Description,
                ImageUrl = create.ImageUrl,
                Price = create.Price,
                ProductStatus = true,
                CategoryID = create.CategoryID
            });
            return Ok("Product güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult ProductGet(int id)
        {
            var values = _productService.TGetByID(id);

            return Ok(values);
        }

        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            
            return Ok(_productService.TProductCount());
        }
        [HttpGet("ProductCountByHamburger")]
        public IActionResult ProductCountByHamburger()
        {

            return Ok(_productService.TProductCountByCategoryNameHamburger());
        }
        [HttpGet("ProductCountByDrink")]
        public IActionResult ProductCountByDrink()
        {

            return Ok(_productService.TProductCountByCategoryNameDrink());
        }

        [HttpGet("ProductPriceAvg")]
        public IActionResult ProductPriceAvg()
        {

            return Ok(_productService.TProductPriceAvg());
        }

        [HttpGet("ProductByMaxPrice")]
        public IActionResult ProductByMaxPrice()
        {

            return Ok(_productService.TProductPriceByMaxPrice());
        }
        [HttpGet("ProductByMinPrice")]
        public IActionResult ProductByMinPrice()
        {

            return Ok(_productService.TProductPriceByMinPrice());
        }
        [HttpGet("ProductPriceByAvgHamburger")]
        public IActionResult ProductPriceByAvgHamburger()
        {

            return Ok(_productService.TProductPriceByHamburger());
        }
    }
}


