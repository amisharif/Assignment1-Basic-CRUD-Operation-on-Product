using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WafiArche.Application.Products;
using WafiArche.Application.Products.Dtos;
using WafiArche.Domain.Products;

namespace WafiArche.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductAppService _productAppService;
        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult AddProduct(ProductDto productDto)
        {
            ProductDto product = _productAppService.AddProduct(productDto);
            return Ok(product);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAllProducts()
        {
            IEnumerable<Product> products = _productAppService.GetAllProducts();
            if (products == null) return NotFound();
            return Ok(products);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult GetProductById(int id)
        {
            ProductDto product = _productAppService.GetProductById(id);

            if (product == null) return NotFound();
            return Ok(product);
        }


        [HttpPut]
       [Route("[action]/{Id}")]
        public ActionResult UpdateProduct(int Id,ProductDto productDto)
        {
            if (Id != productDto.Id) return BadRequest();

            ProductDto product = _productAppService.UpdateProduct(productDto);
            return Ok(product);
        }



        [HttpPost]
        [Route("[action]")]

        public ActionResult DeleteProduct(int Id)
        {
            ProductDto productDto = _productAppService.GetProductById(Id);

            if (productDto == null) return BadRequest();

            _productAppService.DeleteProduct(Id);
            return Ok();
        }



    }
}
