using DrinkStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DrinkStore.BLL.DTOs
{
    public class OrderListDTO : DTO
    {
        public List<OrderDTO> Orders { get; set; }
        public OrderListDTO(List<OrderDTO> _orders)
        {
            Orders = _orders;
        }
    }
    public class OrderDTO : DTO
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
        public ICollection<DetailedOrderEntryDTO> Products { get; set; } = new List<DetailedOrderEntryDTO>();

        public static Expression<Func<Order, DetailedOrderDTO>> CreateFromOrder()
        {
            return o => new DetailedOrderDTO
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                Products = o.ProductOrders.Select(o => new DetailedOrderEntryDTO
                {
                    Id = o.ProductId,
                    Name = o.Product.Name,
                    UnitPrice = o.Product.UnitPrice,
                    PackSizeQuantity = o.Product.PackSize.Quanitity,
                    PackSizeUnit = o.Product.PackSize.Unit,
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

    public class DetailedOrderEntryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitPrice { get; set; }
        public double PackSizeQuantity { get; set; }
        public string PackSizeUnit { get; set; }
        public int Quantity { get; set; }
    }
}
