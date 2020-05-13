using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkStore.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; } = new List<ProductOrder>();
        public ICollection<UserOrder> UserOrders { get; } = new List<UserOrder>();
    }
    
}
