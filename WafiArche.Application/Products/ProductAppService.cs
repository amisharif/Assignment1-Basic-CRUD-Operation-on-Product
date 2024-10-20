using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WafiArche.Application.Products.Dtos;
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
        public ProductDto AddProduct(ProductDto productDto)
        {
            
            Product product = _mapper.Map<Product>(productDto);
            _context.Add(product);
            _context.SaveChanges();
            return productDto;
        }

      

        public IEnumerable<Product> GetAllProducts()
        {
            IEnumerable<Product> products = _context.Products.ToList();

            return products;

        }

        public ProductDto GetProductById(int id)
        {
            Product? product = _context.Products.FirstOrDefault( prod => prod.Id == id);
            return _mapper.Map<ProductDto>(product);
        }

        public bool DeleteProduct(int Id)
        {
            Product? product = _context.Products.FirstOrDefault(prod => prod.Id == Id);
            if (product == null) return false;
            _context.Remove(product);
            _context.SaveChanges();
            return true;
        }

        public ProductDto UpdateProduct(ProductDto productDto)
        {
            Product? product = _context.Products.FirstOrDefault(prod =>prod.Id== productDto.Id);

            product.Name = productDto.Name;
            product.Price = productDto.Price;

            _context.SaveChanges();
            return _mapper.Map<ProductDto>(product);
        }
    }
}
