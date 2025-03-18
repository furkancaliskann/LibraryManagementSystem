using Business.Abstract;
using Business.Dtos.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Helpers;
using System.Security.Claims;

namespace Presentation.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : CustomControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories([FromQuery] bool includeDeleted = true)
        {
            var result = includeDeleted
                ? await _categoryService.GetAllAsync()
                : await _categoryService.GetWithoutDeletedAsync();

            return HandleResult(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            return HandleResult(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryDto addCategoryDto)
        {
            string? userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await _categoryService.AddAsync(userRole, addCategoryDto);
            return HandleResult(result);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            string? userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await _categoryService.UpdateAsync(userRole, id, updateCategoryDto);
            return HandleResult(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteBookCopy([FromRoute] int id)
        {
            string? userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await _categoryService.DeleteAsync(userRole, id);
            return HandleResult(result);
        }
    }
}
