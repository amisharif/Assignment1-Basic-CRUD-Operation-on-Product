using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WafiArche.Application.Enums;

namespace WafiArche.Application.Products.Dtos
{
    public class QueryData
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string? sortBy { get; set; }
        public SortOrderOptions sortOrder { get; set; }
    }
}
