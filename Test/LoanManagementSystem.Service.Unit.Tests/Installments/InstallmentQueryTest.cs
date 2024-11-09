using LoanManagement.Services.Installments.Contracts;
using LoanManagementSystem.Persistence.Ef.Installments;
using LoanManagementSystem.TestTools.Installments.Builders;

namespace LoanManagementSystem.Service.Unit.Tests.Installments;

public class InstallmentQueryTest:BusinessIntegrationTest
{
    private readonly InstallmentQuery _sut;

    public InstallmentQueryTest()
    {
        _sut = new EfInstallmentQuery(SetupContext);
    }
    
    [Fact]
    public async Task GetMonthlyIncomeReportAsync_Returns_Correct_Monthly_Income()
    {
        var customer = new CustomerBuilder().Build();
        Save(customer);
        var loan = new LoanBuilder().Build();
        Save(loan);
        var loanRequest = new LoanRequestBuilder()
            .WithLoanId(loan.Id)
            .WithCustomerId(customer.Id)
            .WithRequestDate(DateTime.Now)
            .WithLoanStatus(LoanStatusEnum.Repayment)
            .WithLoanApprovedDate(DateTime.Now)
            .Build();
        Save(loanRequest);
        var installment1 = new InstallmensBuilder()
            .WithLoanRequestId(loanRequest.Id)
            .WithAmount(1000)
            .WithDueDate(new DateTime(2024, 10, 01))
            .WithIsPaid(false)
            .Build();
        Save(installment1);
        var installment2 = new InstallmensBuilder()
            .WithLoanRequestId(loanRequest.Id)
            .WithAmount(1500)
            .WithDueDate(new DateTime(2024, 10, 15))
            .WithIsPaid(true)
            .WithPaymentDate(new DateTime(2024, 10, 20))
            .Build();
        Save(installment2);
        var installment3 = new InstallmensBuilder()
            .WithLoanRequestId(loanRequest.Id)
            .WithAmount(2000)
            .WithDueDate(new DateTime(2024, 10, 05))
            .WithIsPaid(false)
            .Build();
        Save(installment3);
        
        
        
    }
}