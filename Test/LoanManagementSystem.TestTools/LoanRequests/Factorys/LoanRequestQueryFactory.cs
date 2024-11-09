using LoanManagement.Services.LoanRequests.Contracts;
using LoanManagementSystem.Persistence.Ef.LoanRequests;

namespace LoanManagementSystem.TestTools.LoanRequests.Factorys;

public static class LoanRequestQueryFactory
{
    public static LoanRequestQuery LoanRequestQuery(EfDataContext context)
    {
        return new EfLoanRequestQuery(context);
    }
}