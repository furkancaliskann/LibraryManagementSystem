using Business.Abstract;
using Business.Dtos.Fine;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Helpers;
using System.Security.Claims;

namespace Presentation.Controllers
{
    [Route("api/fines")]
    [ApiController]
    public class FineController : CustomControllerBase
    {
        private readonly IFineService _fineService;

        public FineController(IFineService fineService)
        {
            _fineService = fineService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFines([FromQuery] bool includeDeleted = true)
        {
            var result = includeDeleted
                ? await _fineService.GetAllAsync()
                : await _fineService.GetWithoutDeletedAsync();

            return HandleResult(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetFineById([FromRoute] int id)
        {
            var result = await _fineService.GetByIdAsync(id);
            return HandleResult(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddFine([FromBody] AddFineDto addFineDto)
        {
            string? userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await _fineService.AddAsync(userRole, addFineDto);
            return HandleResult(result);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> UpdateFine([FromRoute] int id, [FromBody] UpdateFineDto updateFineDto)
        {
            string? userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await _fineService.UpdateAsync(userRole, id, updateFineDto);
            return HandleResult(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteFine([FromRoute] int id)
        {
            string? userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await _fineService.DeleteAsync(userRole, id);
            return HandleResult(result);
        }
    }
}
