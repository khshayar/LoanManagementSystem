namespace LoanManagement.Services.LoanRequests.Contracts.Dtos;

public class AddLoanRequestDto
{
    public required int LoanId { get; set; }
    public required int CustomerId { get; set; }
    public required DateTime RequestDate { get; set; }
}