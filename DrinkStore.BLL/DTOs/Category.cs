using DrinkStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DrinkStore.BLL.DTOs
{
    public class CategoryDTO
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

    public class SubcategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
