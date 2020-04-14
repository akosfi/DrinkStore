using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkStore.BLL.DTOs;
using DrinkStore.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RiskFirst.Hateoas;

namespace DrinkStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILinksService _linksService;

        public CategoriesController(ICategoryService categoryService, ILinksService linksService)
        {
            _categoryService = categoryService;
            _linksService = linksService;
        }

        [HttpGet(Name = nameof(GetCategories))]
        public async Task<CategoryListDTO> GetCategories()
        {
            var categories = await _categoryService.GetCategories();
            CategoryListDTO _categories = new CategoryListDTO(categories.ToList());
            _categories.Categories.ForEach(async c => await _linksService.AddLinksAsync(c));

            await _linksService.AddLinksAsync(_categories);

            return _categories;
        }


        [Authorize(Policy = "cat")]
        [HttpDelete("{id}", Name = nameof(DeleteCategory))]
        public async void DeleteCategory(int id)
        {
            await _categoryService.DeleteCategory(id);
        }


        [Authorize(Policy = "cat")]
        [HttpDelete("{id}/sub/{sid}", Name = nameof(DeleteSubcategory))]
        public async void DeleteSubcategory(int sid)
        {
            await _categoryService.DeleteSubCategory(sid);
        }
    }
}