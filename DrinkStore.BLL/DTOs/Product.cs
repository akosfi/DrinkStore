using DrinkStore.DAL.Entities;
using RiskFirst.Hateoas.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DrinkStore.BLL.DTOs
{
    public class ProductListDTO : DTO
    {
        public List<ProductDTO> Products { get; set; }
        public ProductListDTO(List<ProductDTO> _products)
        {
            Products = _products;
        }
    }
    public class ProductDTO : DTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitPrice { get; set; }
        public double PackSizeQuantity { get; set; }
        public string PackSizeUnit { get; set; }
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }

        public static Expression<Func<Product, ProductDTO>> CreateFromProductExpression()
        {
            return p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                UnitPrice = p.UnitPrice,
                CategoryId = p.CategoryId,
                SubCategoryId = p.SubCategoryId,
                PackSizeQuantity = p.PackSize.Quanitity,
                PackSizeUnit = p.PackSize.Unit,
            };
        }

    }

    public class ProductCreateDTO
    {
        public string Name { get; set; }
        public int UnitPrice { get; set; }
        public int PackSizeId { get; set; }
        public int CategoryId { get; set; }
        public int? SubcategoryId { get; set; }
    }

    public class PackSizeDTO : DTO
    {
        public int Id { get; set; }
        public double Quanitity { get; set; }
        public string Unit { get; set; }

        public static Expression<Func<PackSize, PackSizeDTO>> CreateFromPackSizeExpression()
        {
            return p => new PackSizeDTO
            {
                Id = p.Id,
                Quanitity = p.Quanitity,
                Unit = p.Unit,
            };
        }

        public static PackSizeDTO CreateFromPackSize(PackSize p)
        {
            return new PackSizeDTO
            {
                Id = p.Id,
                Quanitity = p.Quanitity,
                Unit = p.Unit,
            };
        }
    }

    public class PackSizeCreateDTO
    {
        public double Quanitity { get; set; }
        public string Unit { get; set; }
    }

    public class PackSizeListDTO : DTO
    {
        public List<PackSizeDTO> PackSizes { get; set; }
        public PackSizeListDTO(List<PackSizeDTO> _PackSizes)
        {
            PackSizes = _PackSizes;
        }
    }
}
