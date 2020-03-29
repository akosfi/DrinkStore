using DrinkStore.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DrinkStore.BLL.Services
{
    public interface IOrderService
    {
        Task<DetailedOrderDTO> GetOrder(int orderId);
        Task<IEnumerable<OrderDTO>> GetOrders();
        Task<DetailedOrderDTO> InsertOrder(List<OrderEntryDTO> orders);
    }
}
