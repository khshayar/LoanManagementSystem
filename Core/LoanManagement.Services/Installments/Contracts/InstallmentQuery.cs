using LoanManagement.Services.LoanRequests.Contracts.Dtos;

namespace LoanManagement.Services.Installments.Contracts;

public interface InstallmentQuery
{
    public Task<List<GetMonthlyIncomeReportDto>> GetMonthlyIncomeReportAsync(int i, int i1);

}