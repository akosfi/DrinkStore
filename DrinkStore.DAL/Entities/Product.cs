using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DrinkStore.DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitPrice { get; set; }

        public int PackSizeId { get; set; }
        public PackSize PackSize { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int? SubCategoryId { get; set; }
        public Subcategory SubCategory { get; set; }

        public ICollection<ProductOrder> ProductOrders { get; } = new List<ProductOrder>();
    }
}
