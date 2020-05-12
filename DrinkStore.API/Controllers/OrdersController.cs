using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DrinkStore.BLL.DTOs;
using DrinkStore.BLL.Services;
using DrinkStore.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RiskFirst.Hateoas;

namespace DrinkStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILinksService _linksService;

        public OrdersController(IOrderService orderService, ILinksService linksService)
        {
            _orderService = orderService;
            _linksService = linksService;
        }


        [Authorize(Policy = "consumer")]
        [HttpGet(Name = nameof(GetOrders))]
        public async Task<OrderListDTO> GetOrders()
        {
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).SingleOrDefault();

            IEnumerable<OrderDTO> orders = await _orderService.GetOrders(userId);
            OrderListDTO _orders = new OrderListDTO(orders.ToList());

            _orders.Orders.ForEach(async o => await _linksService.AddLinksAsync(o));
            await _linksService.AddLinksAsync(_orders);

            return _orders;
        }

        [Authorize(Policy = "consumer")]
        [HttpGet("{id}", Name = nameof(GetOrder))]
        public async Task<DetailedOrderDTO> GetOrder(int id)
        {
            if (id == 0) throw new ArgumentException();
            var order = await _orderService.GetOrder(id);
            await _linksService.AddLinksAsync(order);

            return order;
        }

        [Authorize(Policy = "consumer")]
        [HttpPost(Name = nameof(AddOrder))]
        public async Task<DetailedOrderDTO> AddOrder([FromBody] List<OrderEntryDTO> orders)
        {
            var order = await _orderService.InsertOrder(orders);
            await _linksService.AddLinksAsync(order);

            return order;
        }
    }
}