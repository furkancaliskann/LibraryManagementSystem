using Business.Abstract;
using Business.Dtos.Shelf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Helpers;
using System.Security.Claims;

namespace Presentation.Controllers
{
    [Route("api/shelves")]
    [ApiController]
    public class ShelfController : CustomControllerBase
    {
        private readonly IShelfService _shelfService;

        public ShelfController(IShelfService shelfService)
        {
            _shelfService = shelfService;
        }

        [HttpGet]
        public async Task<IActionResult> GetShelves([FromQuery] bool includeDeleted = true)
        {
            var result = includeDeleted
                ? await _shelfService.GetAllAsync()
                : await _shelfService.GetWithoutDeletedAsync();

            return HandleResult(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetShelfById([FromRoute] int id)
        {
            var result = await _shelfService.GetByIdAsync(id);
            return HandleResult(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddShelf([FromBody] AddShelfDto addShelfDto)
        {
            string? userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await _shelfService.AddAsync(userRole, addShelfDto);
            return HandleResult(result);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> UpdateShelf([FromRoute] int id, [FromBody] UpdateShelfDto updateShelfDto)
        {
            string? userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await _shelfService.UpdateAsync(userRole, id, updateShelfDto);
            return HandleResult(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteShelf([FromRoute] int id)
        {
            string? userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await _shelfService.DeleteAsync(userRole, id);
            return HandleResult(result);
        }
    }
}
