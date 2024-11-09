using LoanManagement.Services.LoanRequests.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementSystem.RestApi.Controllers.Reports;
[Route("api/[controller]")]
[ApiController]
public class Reports : ControllerBase
{
    private readonly LoanRequestQuery _queryService;

    public Reports(LoanRequestQuery queryService)
    {
        _queryService = queryService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLoanRequest(int id)
    {
        var loanRequest = await _queryService.Read(id);
        if (loanRequest == null)
        {
            return NotFound("Loan request not found.");
        }
        return Ok(loanRequest);
    }

    [HttpGet("active-and-overdue")]
    public async Task<IActionResult> GetActiveAndOverdueLoansReport()
    {
        var report = 
            await _queryService.Reportofactiveandoverdueloans();
        return Ok(report);
    }

    [HttpGet("risky-customers")]
    public async Task<IActionResult> GetRiskyCustomersReport()
    {
        var report = await _queryService.GetRiskyCustomersReportAsync();
        return Ok(report);
    }

    [HttpGet("closed-loans")]
    public async Task<IActionResult> GetClosedLoansReport()
    {
        var report = await _queryService.GetClosedLoansReportAsync();
        return Ok(report);
    }
}