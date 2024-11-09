using LoanManagement.Entities.Loans;
using LoanManagement.Services.Loans.Exceptions;

namespace LoanManagement.Services.Loans;

public interface LoanRepository
{
    Task<bool> Find(string dtoName);
    Task Add(Loan loan);
}