using LoanManagement.Entities.LoanRequests;

namespace LoanManagement.Entities.Customers;

public class Customer
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string NationalCode { get; set; }
    public required string PhoneNumber { get; set; }
    public  string? Email { get; set; }
    public IncomeLevelEnum? IncomeLevel { get; set; } 
    public JobTypeEnum? JobType { get; set; }
    public decimal? Monthlyincome { get; set; }
    public decimal? FinancialAssets { get; set; }
    public bool IsIdentityVerified { get; set; } = false;
    public bool? IsFinancialInfoVerified { get; set; }
    public int? CreditScore { get; set; }
    public List<LoanRequest> LoanRequests { get; set; } = [];

}

public enum JobTypeEnum
{
    GovernmentEmployee, 
    SelfEmployed,       
    Unemployed          
}

public enum IncomeLevelEnum
{
    Low,        
    Medium,     
    High        
}