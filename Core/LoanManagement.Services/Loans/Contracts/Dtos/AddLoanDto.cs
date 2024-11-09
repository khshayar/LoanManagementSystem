namespace LoanManagement.Services.Loans.Exceptions;

public class AddLoanDto
{
    public required string LoanName { get; set; }
    public required decimal Amount { get; set; } 
    public required int DurationMonths { get; set; } 
    public required decimal InterestRate { get; set; }
}