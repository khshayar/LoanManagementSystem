namespace LoanManagement.Services.LoanRequests.Contracts.Dtos;

public class GetMonthlyIncomeReportDto
{
    public int Year { get; set; }
    public int Month { get; set; }
    public decimal TotalInterestIncome { get; set; }
    public decimal TotalPenaltyIncome { get; set; }
}