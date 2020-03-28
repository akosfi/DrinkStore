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
            Product product = await GetProduct(productId);
            _context
                .Products
                .Remove(product);

            await _context
                .SaveChangesAsync();
        }

        public async Task<Product> GetProduct(int productId)
        {
            return await _context
                .Products
                .SingleOrDefaultAsync(p => p.Id == productId);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context
                .Products
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId)
        {
            return await _context
                .Products
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetProductsBySubCategoryId(int subcategoryId)
        {
            return await _context
                .Products
                .Where(p => p.SubCategoryId == subcategoryId)
                .ToListAsync();
        }
        public async Task<Product> InsertProduct(Product newProduct)
        {
            _context
                .Products
                .Add(newProduct);

            await _context
                .SaveChangesAsync();

            return newProduct;
        }
        public async Task UpdateProduct(int productId, Product updatedProduct)
        {
            updatedProduct.Id = productId;
            var entry = _context.Attach(updatedProduct);

            entry.State = EntityState.Modified;

            await _context
                .SaveChangesAsync();
        }
    }
}
