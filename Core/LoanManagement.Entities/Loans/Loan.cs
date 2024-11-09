using LoanManagement.Entities.LoanRequests;

namespace LoanManagement.Entities.Loans;

public class Loan
{
    public int Id { get; set; }
    public string LoanName { get; set; }
    public decimal Amount { get; set; } 
    public int DurationMonths { get; set; } 
    public decimal InterestRate { get; set; }
    public bool IsShortTerm => DurationMonths < 12;
    public List<LoanRequest> LoanRequests { get; set; } 
}