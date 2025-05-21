using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Helpers
{
    public class CustomControllerBase : ControllerBase
    {
        public IActionResult HandleResult<T>(Result<T> result)
        {
            switch(result.StatusCode)
            {
                case ResultCodes.Ok: return Ok(result);
                case ResultCodes.NoContent: return NoContent();

                case ResultCodes.ServerError: return StatusCode(500);
                case ResultCodes.BadRequest: return BadRequest(result);
                case ResultCodes.NotFound: return NotFound(result);
                case ResultCodes.Conflict: return Conflict(result);
                case ResultCodes.Forbidden: return Forbid();
                case ResultCodes.Unauthorized: return Unauthorized(result);

                default: return StatusCode(500);
            }
        }
    }
}
