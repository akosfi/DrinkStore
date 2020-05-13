using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkStore.DAL.Entities
{
    public class UserOrder
    {
        public int Id { get; set; }

        public String UserId { get; set; }
        public User User { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
