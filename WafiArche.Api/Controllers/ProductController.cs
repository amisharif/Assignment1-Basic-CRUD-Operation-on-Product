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
        public async Task<ActionResult> CreateProduct(CreateUpdateProductDto productDto)
        {
            ProductDto product = await _productAppService.CreateAsync(productDto);
            return Ok(product);
        }

        [HttpGet]
        public async Task< ActionResult> GetProducts([FromQuery] QueryData queryData)
        {

            IEnumerable<ProductDto> products = await _productAppService.GetListAsync(queryData);
            if (products == null) 
                return NotFound();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            ProductDto product = await _productAppService.GetAsync(id);

            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id,CreateUpdateProductDto productDto)
        {

            ProductDto product = await _productAppService.UpdateAsync(id,productDto);
            return Ok(product);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(int Id)
        {
            bool isDeleted =  await _productAppService.DeleteAsync(Id);
            return Ok(isDeleted);
        }



    }
}
