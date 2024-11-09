using LoanManagement.Entities.Loans;

namespace LoanManagement.Services.Loans;

public interface LoanQuery
{
    Task<Loan?> Read(int dtoLoanId);
}