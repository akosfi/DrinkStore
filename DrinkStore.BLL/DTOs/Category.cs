using DrinkStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DrinkStore.BLL.DTOs
{
    public class CategoryListDTO : DTO
    {
        public List<CategoryDTO> Categories { get; set; }
        public CategoryListDTO(List<CategoryDTO> _categories)
        {
            Categories = _categories;
        }
    }
    public class CategoryDTO : DTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryDTO> Subcategories { get; set; } = new List<CategoryDTO>();
        public int? ParentCategoryId { get; set; }

        public static Expression<Func<Category, CategoryDTO>> CreateFromCategoryExpression()
        {
            return c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
                Subcategories = c.Subcategories.Select(sc => new CategoryDTO
                {
                    Id = sc.Id,
                    Name = sc.Name,
                    ParentCategoryId = c.Id,
                }).ToList(),
            };
        }

        public static Expression<Func<Subcategory, CategoryDTO>> CreateFromSubcategoryExpression()
        {
            return c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
                ParentCategoryId = c.CategoryId,
            };
        }
    }

    public class CreateCategoryDTO
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
