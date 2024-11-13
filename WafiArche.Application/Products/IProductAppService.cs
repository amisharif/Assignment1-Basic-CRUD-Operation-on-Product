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
        Task<ProductDto> CreateAsync(CreateUpdateProductDto product);
        Task<ProductDto> GetAsync(int id);
        Task<IEnumerable<ProductDto>> GetListAsync(QueryData queryData);
        Task<ProductDto> UpdateAsync(int id,CreateUpdateProductDto productDto);
        Task<bool> DeleteAsync(int Id);
    }
}
