using LoanManagement.Services.Loans.Exceptions;

namespace LoanManagementSystem.Persistence.Ef.Loans;

public class EfLoanRepository(EfDataContext context):LoanRepository
{
    public async Task<bool> Find(string dtoName)
    {
        return await context.Set<Loan>().AnyAsync(x => x.LoanName==dtoName);
    }

    public async Task Add(Loan loan)
    {
        context.Set<Loan>().Add(loan);
    }
}