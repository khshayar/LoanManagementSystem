using LoanManagement.Services.Loans.Contracts;
using LoanManagement.Services.Loans.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementSystem.RestApi.Loans;
[Route("api/[controller]")]
[ApiController]
public class LoansController : ControllerBase
{
    private readonly LoanService _service;

    public LoansController(LoanService service)
    {
        _service = service;
    }
    
    [HttpPost]
    public async Task<IActionResult> AddLoan([FromBody] AddLoanDto dto)
    
    {
        await _service.Add(dto);
        return Ok("Customer added successfully.");
    }

}