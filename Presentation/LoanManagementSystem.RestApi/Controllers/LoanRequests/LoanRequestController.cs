using LoanManagement.Services.LoanRequests.Contracts;
using LoanManagement.Services.LoanRequests.Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementSystem.RestApi.Controllers.LoanRequests;

[Route("api/[controller]")]
[ApiController]
public class LoanRequestsController : ControllerBase
{
    private readonly LoanRequestService _service;

    public LoanRequestsController(LoanRequestService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> AddLoanRequest([FromBody] AddLoanRequestDto dto)
    {
        await _service.Add(dto);
        return Ok("Loan request added successfully.");
    }
}