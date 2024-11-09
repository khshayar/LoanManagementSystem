using System.Security.Cryptography;

namespace LoanManagementSystem.Persistence.Ef.LoanRequests;

public class EfLoanRequestRepository(EfDataContext context):LoanRequestRepository
{
    public async Task<bool> Find(int id)
    {
        return await context.Set<LoanRequest>()
            .AnyAsync(x => x.LoanId == id|| x.CustomerId == id);
    }
    
    public async Task<int> IsEntPaidedCount(int dtoCustomerId)
    {
        return await context.Set<LoanRequest>()
            .SelectMany(_=>_.Installments).CountAsync(_=>_.IsPaid == false);
    }

    public async Task Add(LoanRequest loanRequest)
    {
        await context.Set<LoanRequest>().AddAsync(loanRequest);
    }
}