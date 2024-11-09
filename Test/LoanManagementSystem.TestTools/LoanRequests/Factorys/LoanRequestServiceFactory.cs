using LoanManagement.Services.LoanRequests;
using LoanManagement.Services.LoanRequests.Contracts;
using LoanManagementSystem.Persistence.Ef.LoanRequests;
using LoanManagementSystem.Persistence.Ef.Loans;

namespace LoanManagementSystem.TestTools.LoanRequests.Factorys;

public static class LoanRequestServiceFactory
{
    public static LoanRequestService GetLoanRequestService(EfDataContext context)
    {
        
        var unitOfWork = new EfUnitOfWork(context);
        var repository = new EfLoanRequestRepository(context);
        var customerQuery=new EfCustomerQuery(context);
        var loanQuery = new EfLoanQuery(context);
        return new LoanRequestAppService(unitOfWork, repository, customerQuery, loanQuery);
    }
    
}