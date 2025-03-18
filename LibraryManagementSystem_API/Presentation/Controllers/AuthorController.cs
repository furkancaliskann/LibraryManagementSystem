using Business.Abstract;
using Business.Dtos.Author;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Helpers;
using System.Security.Claims;

namespace Presentation.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : CustomControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors([FromQuery] bool includeDeleted = true)
        {
            var result = includeDeleted
                ? await _authorService.GetAllAsync()
                : await _authorService.GetWithoutDeletedAsync();

            return HandleResult(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetAuthorById([FromRoute] int id)
        {
            var result = await _authorService.GetByIdAsync(id);
            return HandleResult(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddAuthor([FromBody] AddAuthorDto addAuthorDto)
        {
            string? userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await _authorService.AddAsync(userRole, addAuthorDto);
            return HandleResult(result);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> UpdateAuthor([FromRoute] int id, [FromBody] UpdateAuthorDto updateAuthorDto)
        {
            string? userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await _authorService.UpdateAsync(userRole, id, updateAuthorDto);
            return HandleResult(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize] 
        public async Task<IActionResult> DeleteAuthor([FromRoute] int id)
        {
            string? userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await _authorService.DeleteAsync(userRole, id);
            return HandleResult(result);
        }
    }
}
