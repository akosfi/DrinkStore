using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services;
using DrinkStore.BLL.DTOs;
using DrinkStore.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RiskFirst.Hateoas;
using RiskFirst.Hateoas.Models;

namespace DrinkStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly ILinksService _linksService;

        public ProductsController(IProductService productService, ILinksService linksService)
        {
            _productService = productService;
            _linksService = linksService;
        }

        [HttpGet(Name = nameof(GetProducts))]
        public async Task<ActionResult<ProductListDTO>> GetProducts([FromQuery] int? categoryId, [FromQuery] int? subcategoryId)
        {
            IEnumerable<ProductDTO> products;
            if (subcategoryId != null)
            {
                products = await _productService.GetProductsBySubCategoryId((int)subcategoryId);
            }
            else if (categoryId != null)
            {
                products = await _productService.GetProductsByCategoryId((int)categoryId);
            }
            else
            {
                products = await _productService.GetProducts();
            }

            ProductListDTO _products = new ProductListDTO(products.ToList());
            _products.Products.ForEach(async p => await _linksService.AddLinksAsync(p));

            await _linksService.AddLinksAsync(_products);

            return _products;
        }

        [Authorize(Policy = "product")]
        [HttpPost(Name = nameof(AddProduct))]
        public async Task<ActionResult<ProductDTO>> AddProduct(ProductCreateDTO newProduct)
        {
            var product = await _productService.InsertProduct(newProduct);
            await _linksService.AddLinksAsync(product);
            return product;
        }


        [HttpGet("{id}", Name = nameof(GetProduct))]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            if (id == 0) throw new ArgumentException();
            var product = await _productService.GetProduct(id);
            await _linksService.AddLinksAsync(product);
            return product;
        }

        [Authorize(Policy = "product")]
        [HttpPut("{id}", Name = nameof(UpdateProduct))]
        public async Task<ActionResult> UpdateProduct(int id, ProductCreateDTO productToUpdate)
        {
            if (id == 0) throw new ArgumentException();
            await _productService.UpdateProduct(id, productToUpdate);
            return Ok();
        }

        [Authorize(Policy = "product")]
        [HttpDelete("{id}", Name = nameof(DeleteProduct))]
        public async Task<ActionResult<ProductDTO>> DeleteProduct(int id)
        {
            if (id == 0) throw new ArgumentException();
            return await _productService.GetProduct(id);
        }

        [HttpGet("pack", Name = nameof(GetPackSizes))]
        public async Task<PackSizeListDTO> GetPackSizes()
        {
            var packSizes = await _productService.GetPackSizes();
            PackSizeListDTO _packSizes = new PackSizeListDTO(packSizes.ToList());
            _packSizes.PackSizes.ForEach(async p => await _linksService.AddLinksAsync(p));

            await _linksService.AddLinksAsync(_packSizes);

            return _packSizes;
        }

        [HttpPost("pack", Name = nameof(AddPackSize))]
        public async Task<PackSizeDTO> AddPackSize(PackSizeCreateDTO newPackSize)
        {
            return await _productService.InsertPackSize(newPackSize);
        }
    }
}
