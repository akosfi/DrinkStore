using DrinkStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DrinkStore.BLL.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public static Expression<Func<Order, OrderDTO>> CreateFromOrder()
        {
            return o => new OrderDTO
            {
                Id = o.Id,
                OrderDate = o.OrderDate
            };
        }
    }

    public class DetailedOrderDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderEntryDTO> Products { get; set; } = new List<OrderEntryDTO>();

        public static Expression<Func<Order, DetailedOrderDTO>> CreateFromOrder()
        {
            return o => new DetailedOrderDTO
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                Products = o.ProductOrders.Select(o => new OrderEntryDTO
                {
                    Id = o.ProductId,
                    Quantity = o.Quantity
                }).ToList()
            };
        }
    }

    public class OrderEntryDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}
