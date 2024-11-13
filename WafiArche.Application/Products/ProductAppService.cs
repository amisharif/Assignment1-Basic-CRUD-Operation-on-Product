using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WafiArche.Application.Products.Dtos;
using WafiArche.Application.Products.Pagination;
using WafiArche.Domain.Products;
using WafiArche.EntityFrameworkCore.Data;

namespace WafiArche.Application.Products
{
    public class ProductAppService : IProductAppService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProductAppService(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateAsync(CreateUpdateProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            await _context.AddAsync(product);
            _context.SaveChanges();

            return _mapper.Map<ProductDto>(product);
        }
      
        public async Task<IEnumerable<ProductDto>> GetListAsync(QueryData queryData)
        {

            IQueryable<Product>productList = _context.Products;

            PaginatedList<Product>products = await GetPaginatedList(productList,queryData);
           
            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> GetAsync(int id)
        {
            Product? product = await _context.Products.FirstOrDefaultAsync( prod => prod.Id == id);
            return _mapper.Map<ProductDto>(product);
        }
        public async Task<ProductDto> UpdateAsync(int id, CreateUpdateProductDto productDto)
        {
            Product? product = await _context.Products.FirstOrDefaultAsync(prod => prod.Id == id);

            if (product == null)
                throw new Exception("Product not found");

            _mapper.Map(productDto, product);

            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }

        
        public async Task<bool> DeleteAsync(int Id)
        {
            Product? product = _context.Products.FirstOrDefault(prod => prod.Id == Id);
            if (product == null)
                throw new Exception("Product not found");

            _context.Remove(product);
            return await _context.SaveChangesAsync()>1;
        }

       


        private async Task<PaginatedList<Product>> GetPaginatedList(IQueryable<Product>products,QueryData query)
        {
            PaginatedList<Product> list = await PaginatedList<Product>.CreateAsync(products, query.PageIndex, query.PageSize);

            return list;
        }

    }
}
