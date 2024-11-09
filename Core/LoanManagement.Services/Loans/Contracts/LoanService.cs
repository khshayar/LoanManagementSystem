using LoanManagement.Services.Loans.Exceptions;

namespace LoanManagement.Services.Loans.Contracts;

public interface LoanService
{
    Task Add(AddLoanDto dto);
}