using LoanManagement.Services.LoanRequests.Contracts.Dtos;

namespace LoanManagementSystem.Persistence.Ef.Installments;

public class EfInstallmentQuery(EfDataContext context):InstallmentQuery
{
    public Task<List<GetMonthlyIncomeReportDto>> GetMonthlyIncomeReportAsync(int i, int i1)
    {
        throw new NotImplementedException();
    }
}