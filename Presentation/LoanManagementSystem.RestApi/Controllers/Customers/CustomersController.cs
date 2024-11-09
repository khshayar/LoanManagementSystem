using LoanManagement.Services.Customers.Contracts;
using LoanManagement.Services.Customers.Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementSystem.RestApi.Controllers.Customers;
[Route("api/[controller]")]
[ApiController]
public class CustomersController:ControllerBase
{
    private readonly CustomerService _service;

    public CustomersController(CustomerService  service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> AddCustomer([FromBody] AddCustomerDto dto)
    {
        await _service.Add(dto);
        return Ok("Customer added successfully.");
    }
    [HttpGet("{nationalCode}/verify-info")]
    public async Task<IActionResult> VerifyInfo(string nationalCode)
    {
        await _service.VerifyInfo(nationalCode);
        return Ok("Customer information verified successfully.");
    }
    [HttpPost("{nationalCode}/financial-info")]
    public async Task<IActionResult> AddFinancialInfo(string nationalCode, [FromBody] AddFinancialInfoDto dto)
    {
        await _service.AddFinancialInfo(nationalCode, dto);
        return Ok("Financial information added successfully.");
    }
    [HttpGet("{nationalCode}/verify-financial-info")]
    public async Task<IActionResult> VerifyFinancialInfo(string nationalCode)
    {
        await _service.VerifyFinacialInfo(nationalCode);
        return Ok("Financial information verified successfully.");
    }
    [HttpPut("{nationalCode}/personal-info")]
    public async Task<IActionResult> UpdatePersonalInfo(string nationalCode, [FromBody] UpdateCustomerDto dto)
    {
        await _service.UpdatePersonalInfo(nationalCode, dto);
        return Ok("Personal information updated successfully.");
    }
    [HttpPut("{nationalCode}/financial-info")]
    public async Task<IActionResult> UpdateFinancialInfo(string nationalCode, [FromBody] UpdateCustomerDto dto)
    {
        await _service.UpdateFinancialInfo(nationalCode, dto);
        return Ok("Financial information updated successfully.");
    }
}