using LoanManagement.Services.LoanRequests.Contracts.Dtos;

namespace LoanManagement.Services.LoanRequests.Contracts;

public interface LoanRequestService
{
    Task Add(AddLoanRequestDto dto);
}