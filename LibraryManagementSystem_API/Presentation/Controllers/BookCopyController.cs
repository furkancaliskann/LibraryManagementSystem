using Business.Abstract;
using Business.Dtos.BookCopy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Helpers;
using System.Security.Claims;

namespace Presentation.Controllers
{
    [Route("api/book-copies")]
    [ApiController]
    public class BookCopyController : CustomControllerBase
    {
        private readonly IBookCopyService _bookCopyService;

        public BookCopyController(IBookCopyService bookCopyService)
        {
            _bookCopyService = bookCopyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBookCopies([FromQuery] bool includeDeleted = true)
        {
            var result = includeDeleted
                ? await _bookCopyService.GetAllAsync()
                : await _bookCopyService.GetWithoutDeletedAsync();

            return HandleResult(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetBookCopyById([FromRoute] int id)
        {
            var result = await _bookCopyService.GetByIdAsync(id);
            return HandleResult(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddBookCopy([FromBody] AddBookCopyDto addBookCopyDto)
        {
            string? userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await _bookCopyService.AddAsync(userRole, addBookCopyDto);
            return HandleResult(result);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> UpdateBookCopy([FromRoute] int id, [FromBody] UpdateBookCopyDto updateBookCopyDto)
        {
            string? userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await _bookCopyService.UpdateAsync(userRole, id, updateBookCopyDto);
            return HandleResult(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteBookCopy([FromRoute] int id)
        {
            string? userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await _bookCopyService.DeleteAsync(userRole, id);
            return HandleResult(result);
        }
    }
}
