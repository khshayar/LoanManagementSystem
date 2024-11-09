namespace LoanManagement.Services.Customers.Contracts.Dtos;

public class AddFinancialInfoDto
{
    public IncomeLevelEnum? IncomeLevel { get; set; } 
    public JobTypeEnum? JobType { get; set; } 
    public decimal? Monthlyincome { get; set; }
    public decimal? FinancialAssets { get; set; }
}