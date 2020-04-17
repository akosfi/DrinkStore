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
                .Select(CategoryDTO.CreateFromCategoryExpression())
                .ToListAsync();
        }

        public async Task<CategoryDTO> InsertCategory(CreateCategoryDTO newCategory)
        {
            Category category = new Category
            {
                Name = newCategory.Name,
            };

            _context
                .Categories
                .Add(category);

            await _context
                .SaveChangesAsync();

            return await _context
                .Categories
                .Where(c => c.Id == category.Id)
                .Select(CategoryDTO.CreateFromCategoryExpression())
                .SingleOrDefaultAsync();
        }

        public async Task<CategoryDTO> InsertSubcategory(CreateCategoryDTO newSubcategory)
        {
            Subcategory category = new Subcategory
            {
                Name = newSubcategory.Name,
                CategoryId = (int)newSubcategory.ParentCategoryId,
            };

            _context
                .Subcategories
                .Add(category);

            await _context
                .SaveChangesAsync();


            return await _context
                .Subcategories
                .Where(c => c.Id == category.Id)
                .Select(CategoryDTO.CreateFromSubcategoryExpression())
                .SingleOrDefaultAsync();
        }

        public async Task DeleteCategory(int id)
        {
            //TODO does it delete subcategories??
            Category category = await _context
                .Categories
                .Where(c => c.Id == id)
                .SingleOrDefaultAsync();

            if (category == null) return;

            _context
                .Categories
                .Remove(category);

            await _context
                .SaveChangesAsync();
        }

        public async Task DeleteSubCategory(int id)
        {
            Subcategory category = await _context
                .Subcategories
                .Where(c => c.Id == id)
                .SingleOrDefaultAsync();

            if (category == null) return;

            _context
                .Subcategories
                .Remove(category);

            await _context
                .SaveChangesAsync();
        }

    }
}
