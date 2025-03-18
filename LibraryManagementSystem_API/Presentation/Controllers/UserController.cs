using Business.Abstract;
using Business.Dtos.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Helpers;
using System.Security.Claims;

namespace Presentation.Controllers
{
    //[Authorize]
    [Route("api/users")]
    [ApiController] 
    public class UserController : CustomControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            var result = await _userService.GetAllAsync();
            return HandleResult(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] int id)
        {
            var result = await _userService.GetByIdAsync(id);
            return HandleResult(result);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UpdateUserDto updateUserDto)
        {
            int? loggedInUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value is string id
         && int.TryParse(id, out var parsedId) ? parsedId : null;

            var result = await _userService.UpdateAsync(loggedInUserId, updateUserDto);
            return HandleResult(result);
        }
    }
}
