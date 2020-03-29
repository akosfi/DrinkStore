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
        Task<CategoryDTO> InsertCategory(CategoryDTO newCategory);
        Task<SubcategoryDTO> InsertSubcategory(SubcategoryDTO newSubcategory);
    }
}
