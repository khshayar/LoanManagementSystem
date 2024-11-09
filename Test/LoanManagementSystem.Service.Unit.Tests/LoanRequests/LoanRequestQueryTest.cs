using LoanManagementSystem.Persistence.Ef.DataContexts;
using LoanManagementSystem.Persistence.Ef.LoanRequests;
using LoanManagementSystem.TestTools.Installments.Builders;

namespace LoanManagementSystem.Service.Unit.Tests.LoanRequests;

public class LoanRequestQueryTest : BusinessIntegrationTest
{
    private readonly LoanRequestQuery _sut;

    public LoanRequestQueryTest()
    {
        _sut = LoanRequestQueryFactory.LoanRequestQuery(SetupContext);
    }

    [Theory]
    [InlineData(LoanStatusEnum.Repayment, LoanStatusEnum.Delinquent)]
    public async Task Reportofactiveandoverdueloans_Report_of_active_and_overdue_loans
        (LoanStatusEnum Repayment, LoanStatusEnum Delinquent)
    {
        var customer1 = new CustomerBuilder().Build();
        Save(customer1);
        var customer2 = new CustomerBuilder().Build();
        Save(customer2);
        var loan = new LoanBuilder().Build();
        Save(loan);
        var loanrequest1 = new LoanRequestBuilder()
            .WithLoanId(loan.Id).WithCustomerId(customer1.Id)
            .WithRequestDate(DateTime.Now)
            .WithLoanStatus(Repayment)
            .WithLoanApprovedDate(DateTime.Now).Build();
        Save(loanrequest1);
        var loanrequest2 = new LoanRequestBuilder()
            .WithLoanId(loan.Id).WithCustomerId(customer2.Id)
            .WithRequestDate(DateTime.Now)
            .WithLoanStatus(Delinquent)
            .WithLoanApprovedDate(DateTime.Now).Build();
        Save(loanrequest2);
        var installment1 = new InstallmensBuilder()
            .WithLoanRequestId(loanrequest1.Id)
            .WithDueDate(DateTime.Now)
            .WithIsPaid(true)
            .Build();
        Save(installment1);
        var installment2 = new InstallmensBuilder()
            .WithLoanRequestId(loanrequest2.Id)
            .WithDueDate(DateTime.Now)
            .WithIsPaid(false)
            .Build();
        Save(installment2);

        var report = await _sut.Reportofactiveandoverdueloans();

        report.Should().HaveCount(2);
        report.FirstOrDefault(_ => _.Status == LoanStatusEnum.Repayment).LoanRequestId.Should().Be(loanrequest1.Id);
        report.FirstOrDefault(_ => _.Status == LoanStatusEnum.Delinquent).LoanRequestId.Should().Be(loanrequest2.Id);
    }

    [Fact]
    public async Task GetRiskyCustomersReportAsync_Returns_Customers_With_More_Than_Two_Delayed_Installments()
    {
        var customer1 = new CustomerBuilder().Build();
        Save(customer1);
        var customer2 = new CustomerBuilder().Build();
        Save(customer2);
        var loan = new LoanBuilder().Build();
        Save(loan);
        var loanrequest1 = new LoanRequestBuilder()
            .WithLoanId(loan.Id).WithCustomerId(customer1.Id)
            .WithRequestDate(DateTime.Now)
            .WithLoanStatus(LoanStatusEnum.Delinquent)
            .WithLoanApprovedDate(DateTime.Now).Build();
        Save(loanrequest1);
        var loanrequest2 = new LoanRequestBuilder()
            .WithLoanId(loan.Id).WithCustomerId(customer2.Id)
            .WithRequestDate(DateTime.Now)
            .WithLoanStatus(LoanStatusEnum.Delinquent)
            .WithLoanApprovedDate(DateTime.Now).Build();
        Save(loanrequest2);
        var installment1 = new InstallmensBuilder()
            .WithLoanRequestId(loanrequest1.Id)
            .WithDueDate(DateTime.Now.AddMonths(-1))
            .WithIsPaid(false)
            .Build();
        Save(installment1);
        var installment2 = new InstallmensBuilder()
            .WithLoanRequestId(loanrequest1.Id)
            .WithDueDate(DateTime.Now.AddMonths(-2))
            .WithIsPaid(false)
            .Build();
        Save(installment2);
        var installment3 = new InstallmensBuilder()
            .WithLoanRequestId(loanrequest1.Id)
            .WithDueDate(DateTime.Now.AddMonths(-3))
            .WithIsPaid(false)
            .Build();
        Save(installment3);
        var installment4 = new InstallmensBuilder()
            .WithLoanRequestId(loanrequest2.Id)
            .WithDueDate(DateTime.Now.AddMonths(-1))
            .WithIsPaid(false)
            .Build();
        Save(installment4);

        var result = await _sut.GetRiskyCustomersReportAsync();

        result.Should().HaveCount(1);
        result.Single().CustomerId.Should().Be(customer1.Id);
        result.Single().DelayedInstallmentsCount.Should().Be(3);
    }

    [Fact]
    public async Task GetClosedLoansReportAsync_Returns_Only_Fully_Paid_Loans_With_Correct_Details()
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
        .WithIsPaid(true)
        .Build();
    Save(installment1);
    var installment2 = new InstallmensBuilder()
        .WithLoanRequestId(loanRequest.Id)
        .WithAmount(1000)
        .WithDueDate(new DateTime(2024, 10, 15))
        .WithIsPaid(true)
        .WithPaymentDate(new DateTime(2024, 10, 20))
        .Build();
    Save(installment2);
    var loanRequest2 = new LoanRequestBuilder()
        .WithLoanId(loan.Id)
        .WithCustomerId(customer.Id)
        .WithRequestDate(DateTime.Now)
        .WithLoanStatus(LoanStatusEnum.Repayment)
        .WithLoanApprovedDate(DateTime.Now)
        .Build();
    Save(loanRequest2);
    var partialInstallment = new InstallmensBuilder()
        .WithLoanRequestId(loanRequest2.Id)
        .WithAmount(2000)
        .WithDueDate(new DateTime(2024, 10, 05))
        .WithIsPaid(false)
        .Build();
    Save(partialInstallment);
    
    var result = await _sut.GetClosedLoansReportAsync();
    
    result.Should().HaveCount(1); 
    var closedLoan = result.First();
    closedLoan.LoanId.Should().Be(loanRequest.Id);
    closedLoan.TotalLoanAmount.Should().Be(2000); 
    closedLoan.PaidInstallmentsCount.Should().Be(2); 
    closedLoan.TotalLateFees.Should().Be(20); 

    }

}