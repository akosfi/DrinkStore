using DrinkStore.BLL.DTOs;
using DrinkStore.DAL;
using DrinkStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkStore.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly DrinkStoreContext _context;

        public OrderService(DrinkStoreContext context)
        {
            _context = context;
        }

        public async Task<DetailedOrderDTO> GetOrder(int orderId)
        {
            return await _context
                .Orders
                .Include(o => o.ProductOrders)
                .Where(o => o.Id == orderId)
                .Select(DetailedOrderDTO.CreateFromOrder())
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<OrderDTO>> GetOrders()
        {
            return await _context
                .Orders
                .Select(OrderDTO.CreateFromOrder())
                .ToListAsync();
        }

        public async Task<DetailedOrderDTO> InsertOrder(List<OrderEntryDTO> orders)
        {
            Order order = new Order
            {
                OrderDate = DateTime.Now
            };

            _context
                .Orders
                .Add(order);

            await _context
                .SaveChangesAsync();

            foreach(OrderEntryDTO productOrder in orders)
            {
                ProductOrder po = new ProductOrder
                {
                    OrderId = order.Id,
                    ProductId = productOrder.Id,
                    Quantity = productOrder.Quantity
                };
                _context
                    .ProductOrders
                    .Add(po);
            }

            await _context
                .SaveChangesAsync();

            return await _context
                .Orders
                .Include(o => o.ProductOrders)
                .Where(o => o.Id == order.Id)
                .Select(DetailedOrderDTO.CreateFromOrder())
                .SingleOrDefaultAsync();

        }
    }
}
