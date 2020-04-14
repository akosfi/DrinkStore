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
        public ICollection<SubcategoryDTO> Subcategories { get; set; } = new List<SubcategoryDTO>();

        public static Expression<Func<Category, CategoryDTO>> CreateFromCategory()
        {
            return c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
                Subcategories = c.Subcategories.Select(sc => new SubcategoryDTO
                {
                    Id = sc.Id,
                    Name = sc.Name,
                    CategoryId = c.Id,
                }).ToList(),
            };
        }
    }

    public class SubcategoryDTO : DTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
