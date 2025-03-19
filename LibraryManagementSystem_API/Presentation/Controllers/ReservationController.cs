using Business.Abstract;
using Business.Dtos.BookCopy;
using Business.Dtos.Reservation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Helpers;
using System.Security.Claims;

namespace Presentation.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationController : CustomControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetReservations([FromQuery] bool includeDeleted = true)
        {
            var result = includeDeleted
                ? await _reservationService.GetAllAsync()
                : await _reservationService.GetWithoutDeletedAsync();

            return HandleResult(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetReservationById([FromRoute] int id)
        {
            var result = await _reservationService.GetByIdAsync(id);
            return HandleResult(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddReservation([FromBody] AddReservationDto addReservationDto)
        {
            string? userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await _reservationService.AddAsync(userRole, addReservationDto);
            return HandleResult(result);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> UpdateReservation([FromRoute] int id, [FromBody] UpdateReservationDto updateReservationDto)
        {
            string? userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await _reservationService.UpdateAsync(userRole, id, updateReservationDto);
            return HandleResult(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteReservation([FromRoute] int id)
        {
            string? userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await _reservationService.DeleteAsync(userRole, id);
            return HandleResult(result);
        }
    }
}
