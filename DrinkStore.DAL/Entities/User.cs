using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkStore.DAL.Entities
{
    public class User : IdentityUser
    {   
        public String Name { get; set; }

        public ICollection<UserOrder> UserOrders { get; } = new List<UserOrder>();
    }
}
