using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services;
using DrinkStore.BLL.DTOs;
using DrinkStore.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DrinkStore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> Get()
        {
            return await _productService.GetProducts();
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            if (id == 0) throw new ArgumentException();
            return await _productService.GetProduct(id);
        }
    }
}
