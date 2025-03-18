using Business.Abstract;
using Business.Dtos.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Helpers;
using System.Security.Claims;

namespace Presentation.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : CustomControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks([FromQuery] bool includeDeleted = true)
        {
            var result = includeDeleted
                ? await _bookService.GetAllAsync()
                : await _bookService.GetWithoutDeletedAsync();

            return HandleResult(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var result = await _bookService.GetByIdAsync(id);
            return HandleResult(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddBook([FromBody] AddBookDto addBookDto)
        {
            string? userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await _bookService.AddAsync(userRole, addBookDto);
            return HandleResult(result);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromBody] UpdateBookDto updateBookDto)
        {
            string? userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await _bookService.UpdateAsync(userRole, id, updateBookDto);
            return HandleResult(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            string? userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await _bookService.DeleteAsync(userRole, id);
            return HandleResult(result);
        }
    }
}
