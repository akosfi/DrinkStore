using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkStore.DAL.Entities
{
    public class PackSize
    {
        public int Id { get; set; }
        
        public double Quanitity { get; set; }
        public string Unit { get; set; }

        public ICollection<Product> Products { get; } = new List<Product>();
    }
}
