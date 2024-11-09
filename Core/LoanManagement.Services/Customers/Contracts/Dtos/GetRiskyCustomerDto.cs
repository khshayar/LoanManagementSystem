namespace LoanManagement.Services.Customers.Contracts.Dtos;

public class GetRiskyCustomerDto
{
    public int CustomerId { get; set; }
    public string NationalCode { get; set; }
    public string CustomerName { get; set; }
    public int DelayedInstallmentsCount { get; set; }
}