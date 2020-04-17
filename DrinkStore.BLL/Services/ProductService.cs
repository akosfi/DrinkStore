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
                .Select(ProductDTO.CreateFromProductExpression())
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            return await _context
                .Products
                .Select(ProductDTO.CreateFromProductExpression())
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByCategoryId(int categoryId)
        {
            return await _context
                .Products
                .Where(p => p.CategoryId == categoryId)
                .Select(ProductDTO.CreateFromProductExpression())
                .ToListAsync();
        }
        public async Task<IEnumerable<ProductDTO>> GetProductsBySubCategoryId(int subcategoryId)
        {
            return await _context
                .Products
                .Where(p => p.SubCategoryId == subcategoryId)
                .Select(ProductDTO.CreateFromProductExpression())
                .ToListAsync();
        }

        public async Task<ProductDTO> InsertProduct(ProductCreateDTO newProduct)
        {
            Product product = new Product
            {
                Name = newProduct.Name,
                UnitPrice = newProduct.UnitPrice,
                PackSizeId = newProduct.PackSizeId,
                CategoryId = newProduct.CategoryId,
                SubCategoryId = newProduct.SubcategoryId,
            };

            _context
                .Products
                .Add(product);

            await _context
                .SaveChangesAsync();

            return await _context
                .Products
                .Include(p => p.PackSize)
                .Where(p => p.Id == product.Id)
                .Select(ProductDTO.CreateFromProductExpression())
                .SingleOrDefaultAsync();
        }
        public async Task UpdateProduct(int productId, ProductCreateDTO updatedProduct)
        {
            Product product = new Product
            {
                Id = productId,
                UnitPrice = updatedProduct.UnitPrice,
                Name = updatedProduct.Name,
                CategoryId = updatedProduct.CategoryId,
                SubCategoryId = updatedProduct.SubcategoryId,
                PackSizeId = updatedProduct.PackSizeId,
            };

            var entry = _context.Attach(product);

            entry.State = EntityState.Modified;

            await _context
                .SaveChangesAsync();
        }

        public async Task<IEnumerable<PackSizeDTO>> GetPackSizes()
        {
            return await _context.PackSizes.Select(PackSizeDTO.CreateFromPackSizeExpression()).ToListAsync();
        }

        public async Task<PackSizeDTO> InsertPackSize(PackSizeCreateDTO newPackSize)
        {
            PackSize ps = new PackSize
            {
                Quanitity = newPackSize.Quanitity,
                Unit = newPackSize.Unit,
            };

            _context
                .PackSizes
                .Add(ps);

            await _context
                .SaveChangesAsync();

            return PackSizeDTO.CreateFromPackSize(ps);
        }
    }
}
