﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DrinkStore.BLL.DTOs;
using DrinkStore.DAL.Entities;

namespace BLL.Services
{
    public interface IProductService
    {
        Task<ProductDTO> GetProduct(int productId);
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<IEnumerable<ProductDTO>> GetProductsByCategoryId(int categoryId);
        Task<IEnumerable<ProductDTO>> GetProductsBySubCategoryId(int subcategoryId);
        Task<ProductDTO> InsertProduct(ProductCreateDTO newProduct);
        Task UpdateProduct(int productId, ProductCreateDTO updatedProduct);
        void DeleteProduct(int productId);
        Task<IEnumerable<PackSizeDTO>> GetPackSizes();
        Task<PackSizeDTO> InsertPackSize(PackSizeCreateDTO newPackSize);
    }
}
