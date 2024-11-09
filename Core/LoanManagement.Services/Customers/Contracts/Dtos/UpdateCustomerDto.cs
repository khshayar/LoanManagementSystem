namespace LoanManagement.Services.Customers.Contracts.Dtos;

public class UpdateCustomerDto
{
    public  string FirstName { get; set; }
    public  string LastName { get; set; }
    public  string PhoneNumber { get; set; }
    public  string? Email { get; set; }
    public IncomeLevelEnum IncomeLevel { get; set; } 
    public JobTypeEnum JobType { get; set; } 
    public decimal FinancialAssets { get; set; }
    public decimal Monthlyincome { get; set; }
    
    public int CreditScore { get; set; }
}