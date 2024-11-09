using LoanManagement.Entities.Installments;
using LoanManagement.Services.Installments.Contracts;
using LoanManagement.Services.Installments.Exceptions;
using LoanManagementSystem.TestTools.Installments.Builders;
using LoanManagementSystem.TestTools.Installments.Factorys;

namespace LoanManagementSystem.Service.Unit.Tests.Installments;

public class InstallmentServiceTest:BusinessIntegrationTest
{
    private readonly InstallmentService _sut;

    public InstallmentServiceTest()
    {
        _sut=InstallmentServiceFactory.GetInstallmentService(SetupContext);
    }

    [Fact]
    public async Task AddRange_add_all_installment_properly()
    {
        var customer=new CustomerBuilder().Build();
        Save(customer);
        var loan=new LoanBuilder().Build();
        Save(loan);
        var loanRequest=new LoanRequestBuilder()
            .WithCustomerId(customer.Id).WithLoanId(loan.Id)
            .WithRequestDate(DateTime.Now)
            .WithLoanApprovedDate(DateTime.Now).Build();
        Save(loanRequest);
        var dto=new AddInstallmensDtoBuilder()
            .WithLoanRequestId(loanRequest.Id).Build();
        
       await _sut.AddRange(dto);

        var actual = ReadContext.Set<Installment>().Where(_=>_.LoanRequestId==loanRequest.Id).ToList();
        foreach (var item in actual)
        {
            item.LoanRequestId.Should().Be(dto.LoanRequestId);
        }
    }

    [Fact]
    public async Task AddRange_ThrowException_when_loan_request_approved_date_is_null()
    {
        var customer=new CustomerBuilder().Build();
        Save(customer);
        var loan=new LoanBuilder().Build();
        Save(loan);
        var loanRequest=new LoanRequestBuilder()
            .WithCustomerId(customer.Id).WithLoanId(loan.Id)
            .WithRequestDate(DateTime.Now)
            .Build();
        Save(loanRequest);
        var dto=new AddInstallmensDtoBuilder()
            .WithLoanRequestId(loanRequest.Id).Build();
        
        var actual=async () => await _sut.AddRange(dto);

        await actual.Should().ThrowExactlyAsync<ApprovaedDateNotSetException>();
    }
    
    [Fact]
    public async Task AddRange_ThrowException_when_loan_request_isent_exist()
    {
        var customer=new CustomerBuilder().Build();
        Save(customer);
        var loan=new LoanBuilder().Build();
        Save(loan);
        var loanRequest=new LoanRequestBuilder()
            .WithCustomerId(customer.Id).WithLoanId(loan.Id)
            .WithRequestDate(DateTime.Now)
            .Build();
        var dto=new AddInstallmensDtoBuilder()
            .WithLoanRequestId(loanRequest.Id).Build();
        
        var actual=async () => await _sut.AddRange(dto);

        await actual.Should().ThrowExactlyAsync<LoanRequestIsentExistByThisIdException>();
    }
    [Fact]
    public async Task AddRange_ThrowException_when_installment_already_exist()
    {
        var customer=new CustomerBuilder().Build();
        Save(customer);
        var loan=new LoanBuilder().Build();
        Save(loan);
        var loanRequest=new LoanRequestBuilder()
            .WithCustomerId(customer.Id).WithLoanId(loan.Id)
            .WithRequestDate(DateTime.Now)
            .Build();
        Save(loanRequest);
        var installment = new InstallmensBuilder()
            .WithLoanRequestId(loanRequest.Id)
            .WithDueDate(DateTime.Now)
            .WithIsPaid(true)
            .Build();
        Save(installment);
        var dto=new AddInstallmensDtoBuilder()
            .WithLoanRequestId(loanRequest.Id).Build();
        
        var actual=async () => await _sut.AddRange(dto);
        
        await actual.Should().ThrowExactlyAsync<InstallmentAllReadyExistByThisLoanRequest>();
    }
}