namespace LoanManagement.Services.LoanRequests.Contracts.Dtos;

public class ClosedLoanReportDto
{
    public int LoanId { get; set; }
    public decimal TotalLoanAmount { get; set; }
    public int PaidInstallmentsCount { get; set; }
    public decimal TotalLateFees { get; set; }
}