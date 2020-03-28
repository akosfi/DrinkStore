using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DrinkStore.DAL.Entities;

namespace BLL.Services
{
    public interface IProductService
    {
        Task<Product> GetProduct(int productId);
        Task<IEnumerable<Product>> GetProducts();
        Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId);
        Task<IEnumerable<Product>> GetProductsBySubCategoryId(int subcategoryId);
        Task<Product> InsertProduct(Product newProduct);
        Task UpdateProduct(int productId, Product updatedProduct);
        void DeleteProduct(int productId);
    }
}
