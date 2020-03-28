using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkStore.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; } = new List<ProductOrder>();
    }
    
}
