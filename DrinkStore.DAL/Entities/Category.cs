using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkStore.DAL.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; } = new List<Product>();
        public ICollection<Subcategory> Subcategories { get; } = new List<Subcategory>();
    }
}
