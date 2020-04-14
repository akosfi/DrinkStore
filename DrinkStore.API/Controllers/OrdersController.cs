using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkStore.BLL.DTOs;
using DrinkStore.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrinkStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpGet(Name = nameof(GetOrders))]
        public async Task<IEnumerable<OrderDTO>> GetOrders()
        {
            return await _orderService.GetOrders();
        }

        [HttpGet("{id}")]
        public async Task<DetailedOrderDTO> Get(int id)
        {
            if (id == 0) throw new ArgumentException();
            return await _orderService.GetOrder(id);
        }

        [HttpPost]
        public async Task<DetailedOrderDTO> Post([FromBody] List<OrderEntryDTO> orders)
        {
            return await _orderService.InsertOrder(orders);
        }
    }
}