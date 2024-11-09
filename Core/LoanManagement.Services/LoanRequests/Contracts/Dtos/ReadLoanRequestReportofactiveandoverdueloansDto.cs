using LoanManagement.Entities.LoanRequests;

namespace LoanManagement.Services.LoanRequests.Contracts.Dtos;

public class ReadLoanRequestReportofactiveandoverdueloansDto
{
    public int LoanRequestId { get; set; }
    public LoanStatusEnum Status { get; set; } 
    public decimal TotalPaidAmount { get; set; }
    public int RemainingInstallments { get; set; }
}