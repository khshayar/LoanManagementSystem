using LoanManagement.Entities.LoanRequests;

namespace LoanManagement.Services.LoanRequests.Contracts;

public interface LoanRequestRepository
{
    Task<bool> Find(int id);
    Task<int> IsEntPaidedCount(int dtoCustomerId);
    Task Add(LoanRequest loanRequest);
}