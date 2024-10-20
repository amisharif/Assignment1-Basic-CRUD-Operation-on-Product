using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WafiArche.Application.Products.Dtos;
using WafiArche.Domain.Products;

namespace WafiArche.Application.Products
{
    public interface IProductAppService
    {
        ProductDto AddProduct(ProductDto product);
        ProductDto GetProductById(int id);
        IEnumerable<Product> GetAllProducts();
        ProductDto UpdateProduct(ProductDto productDto);
        bool DeleteProduct(int Id);
    }
}
