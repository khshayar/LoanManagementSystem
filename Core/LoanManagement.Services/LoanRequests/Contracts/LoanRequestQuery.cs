using LoanManagement.Entities.LoanRequests;
using LoanManagement.Services.LoanRequests.Contracts.Dtos;

namespace LoanManagement.Services.LoanRequests.Contracts;

public interface LoanRequestQuery
{
    Task<LoanRequest?> Read(int id);
    Task <List<ReadLoanRequestReportofactiveandoverdueloansDto>> Reportofactiveandoverdueloans();
    Task<List<GetRiskyCustomerDto>> GetRiskyCustomersReportAsync();

    Task<List<ClosedLoanReportDto>> GetClosedLoansReportAsync();
}