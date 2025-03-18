using Business.Abstract;
using Business.Dtos.Category;
using Business.Dtos.Publisher;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Helpers;
using System.Security.Claims;

namespace Presentation.Controllers
{
    [Route("api/publishers")]
    [ApiController]
    public class PublisherController : CustomControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPublishers([FromQuery] bool includeDeleted = true)
        {
            var result = includeDeleted
                ? await _publisherService.GetAllAsync()
                : await _publisherService.GetWithoutDeletedAsync();

            return HandleResult(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetPublisherById([FromRoute] int id)
        {
            var result = await _publisherService.GetByIdAsync(id);
            return HandleResult(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPublisher([FromBody] AddPublisherDto addPublisherDto)
        {
            string? userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await _publisherService.AddAsync(userRole, addPublisherDto);
            return HandleResult(result);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> UpdatePublisher([FromRoute] int id, [FromBody] UpdatePublisherDto updatePublisherDto)
        {
            string? userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await _publisherService.UpdateAsync(userRole, id, updatePublisherDto);
            return HandleResult(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeletePublisher([FromRoute] int id)
        {
            string? userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await _publisherService.DeleteAsync(userRole, id);
            return HandleResult(result);
        }
    }
}
