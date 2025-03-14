using Business.Abstract;
using Business.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Helpers;

namespace Presentation.Controllers
{
    //[Authorize]
    [Route("api/users")]
    [ApiController] 
    public class UserController : BaseController
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

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateUserAsync([FromRoute] int id, [FromBody] UpdateUserDto updateUserDto)
        {
            var result = await _userService.UpdateAsync(id, updateUserDto);
            return HandleResult(result);
        }
    }
}
