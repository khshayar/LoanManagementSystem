using LoanManagement.Services.Loans;
using LoanManagement.Services.Loans.Contracts;
using LoanManagementSystem.Persistence.Ef.Loans;

namespace LoanManagementSystem.TestTools.Loans.Factorys;

public static class LoanServiceFactory
{
    public static LoanService CreateLoanService(EfDataContext context)
    {
        var repository = new EfLoanRepository(context);
        var unitOfWork = new EfUnitOfWork(context);
        return new LoanAppService(unitOfWork, repository);
    }
}