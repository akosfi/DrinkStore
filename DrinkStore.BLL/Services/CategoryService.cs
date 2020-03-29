using DrinkStore.DAL;
using DrinkStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context
                .Categories
                .Include(c => c.Subcategories)
                .ToListAsync();
        }
    }
}
