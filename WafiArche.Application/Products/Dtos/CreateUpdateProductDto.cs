using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WafiArche.Application.Products.Dtos
{
    public class CreateUpdateProductDto
    {

        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Code { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? SalePrice { get; set; }
    }
}
