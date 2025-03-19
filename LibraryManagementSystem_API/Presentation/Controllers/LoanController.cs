using Business.Abstract;
using Business.Dtos.Loan;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Helpers;
using System.Security.Claims;

namespace Presentation.Controllers
{
    [Route("api/loans")]
    [ApiController]
    public class LoanController : CustomControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLoans([FromQuery] bool includeDeleted = true)
        {
            var result = includeDeleted
                ? await _loanService.GetAllAsync()
                : await _loanService.GetWithoutDeletedAsync();

            return HandleResult(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetLoanById([FromRoute] int id)
        {
            var result = await _loanService.GetByIdAsync(id);
            return HandleResult(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddLoan([FromBody] AddLoanDto addLoanDto)
        {
            string? userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await _loanService.AddAsync(userRole, addLoanDto);
            return HandleResult(result);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> UpdateLoan([FromRoute] int id, [FromBody] UpdateLoanDto updateLoanDto)
        {
            string? userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await _loanService.UpdateAsync(userRole, id, updateLoanDto);
            return HandleResult(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteLoan([FromRoute] int id)
        {
            string? userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var result = await _loanService.DeleteAsync(userRole, id);
            return HandleResult(result);
        }
    }
}
