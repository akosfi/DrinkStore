using DrinkStore.BLL.DTOs;
using DrinkStore.DAL;
using DrinkStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkStore.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly DrinkStoreContext _context;

        public CategoryService(DrinkStoreContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            return await _context
                .Categories
                .Include(c => c.Subcategories)
                .Select(CategoryDTO.CreateFromCategory())
                .ToListAsync();
        }

        public async Task<CategoryDTO> InsertCategory(CategoryDTO newCategory)
        {
            Category category = new Category
            {
                Id = newCategory.Id,
                Name = newCategory.Name,
            };

            _context
                .Categories
                .Add(category);

            await _context
                .SaveChangesAsync();

            newCategory.Id = category.Id;

            return newCategory;
        }

        public async Task<SubcategoryDTO> InsertSubcategory(SubcategoryDTO newSubcategory)
        {
            Subcategory category = new Subcategory
            {
                Id = newSubcategory.Id,
                Name = newSubcategory.Name,
                CategoryId = newSubcategory.CategoryId,
            };

            _context
                .Subcategories
                .Add(category);

            await _context
                .SaveChangesAsync();

            newSubcategory.Id = category.Id;

            return newSubcategory;
        }
    }
}
