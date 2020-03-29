using DrinkStore.BLL.DTOs;
using DrinkStore.DAL;
using DrinkStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly DrinkStoreContext _context;

        public ProductService(DrinkStoreContext context)
        {
            _context = context;
        }

        public async void DeleteProduct(int productId)
        {
            Product product = await _context
                .Products
                .Include(p => p.PackSize)
                .Where(p => p.Id == productId)
                .SingleOrDefaultAsync();

            if (product == null) return;

            _context
                .Products
                .Remove(product);

            await _context
                .SaveChangesAsync();
        }

        public async Task<ProductDTO> GetProduct(int productId)
        {
            return await _context
                .Products
                .Include(p => p.PackSize)
                .Where(p => p.Id == productId)
                .Select(ProductDTO.CreateFromProduct())
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            return await _context
                .Products
                .Select(ProductDTO.CreateFromProduct())
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByCategoryId(int categoryId)
        {
            return await _context
                .Products
                .Where(p => p.CategoryId == categoryId)
                .Select(ProductDTO.CreateFromProduct())
                .ToListAsync();
        }
        public async Task<IEnumerable<ProductDTO>> GetProductsBySubCategoryId(int subcategoryId)
        {
            return await _context
                .Products
                .Where(p => p.SubCategoryId == subcategoryId)
                .Select(ProductDTO.CreateFromProduct())
                .ToListAsync();
        }
        public async Task<Product> InsertProduct(ProductCreateDTO newProduct)
        {
            Product product = new Product
            {
                Name = newProduct.Name,
                UnitPrice = newProduct.UnitPrice,
                PackSizeId = newProduct.PackSizeId,
                CategoryId = newProduct.CategoryId,
                SubCategoryId = newProduct.SubCategoryId,
            };

            _context
                .Products
                .Add(product);

            await _context
                .SaveChangesAsync();

            return product;
        }
        public async Task UpdateProduct(int productId, ProductCreateDTO updatedProduct)
        {
            Product product = new Product
            {
                Id = productId,
                UnitPrice = updatedProduct.UnitPrice,
                Name = updatedProduct.Name,
                CategoryId = updatedProduct.CategoryId,
                SubCategoryId = updatedProduct.SubCategoryId,
                PackSizeId = updatedProduct.PackSizeId,
            };

            var entry = _context.Attach(product);

            entry.State = EntityState.Modified;

            await _context
                .SaveChangesAsync();
        }
    }
}
