using LoanManagement.Services.Installments;
using LoanManagement.Services.Installments.Contracts;
using LoanManagementSystem.Persistence.Ef.Installments;
using LoanManagementSystem.Persistence.Ef.LoanRequests;

namespace LoanManagementSystem.TestTools.Installments.Factorys;

public static class InstallmentServiceFactory
{
    public static InstallmentService GetInstallmentService(EfDataContext context)
    {
        var uniOfwork = new EfUnitOfWork(context);
        var repository = new EfInstallmentRepository(context);
        var loanRequestQuery = new EfLoanRequestQuery(context);
        return new InstallmentAppService(uniOfwork, repository,loanRequestQuery);
    }
}