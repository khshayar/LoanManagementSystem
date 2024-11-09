using LoanManagement.Services.Installments.Contracts;
using LoanManagement.Services.Installments.Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementSystem.RestApi.Installments;
[Route("api/[controller]")]
[ApiController]
public class InstallmentsController : ControllerBase
{
    private readonly InstallmentService _service;

    public InstallmentsController(InstallmentService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> AddInstallments([FromBody] AddInstallmentDto dto)
    {
        await _service.AddRange(dto);
        return Ok("Installments added successfully.");
    }
}