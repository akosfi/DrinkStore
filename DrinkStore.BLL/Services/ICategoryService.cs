using DrinkStore.BLL.DTOs;
using DrinkStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DrinkStore.BLL.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> InsertCategory(CreateCategoryDTO newCategory);
        Task<CategoryDTO> InsertSubcategory(CreateCategoryDTO newSubcategory);
        Task DeleteCategory(int id);
        Task DeleteSubCategory(int id);
    }
}
