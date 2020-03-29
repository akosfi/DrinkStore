using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkStore.BLL.DTOs
{
    public class ProductCreateDTO
    {
        public string Name { get; set; }
        public int UnitPrice { get; set; }
        public int PackSizeId { get; set; }
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
    }
}
