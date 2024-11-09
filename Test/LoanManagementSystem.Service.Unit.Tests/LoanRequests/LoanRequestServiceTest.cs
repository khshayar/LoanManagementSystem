namespace LoanManagementSystem.Service.Unit.Tests.LoanRequests;

public class LoanRequestServiceTest:BusinessIntegrationTest
{
    private readonly LoanRequestService _sut;

    public LoanRequestServiceTest()
    {
        _sut = LoanRequestServiceFactory.GetLoanRequestService(SetupContext);
    }

    [Fact]
    public async Task Add_add_loan_request_properly()
    {
        var customer= new CustomerBuilder().Build();
        Save(customer);
        var loan =new LoanBuilder().Build();
        Save(loan);
        var dto = AddLoanRequestDtoFactory.Create(
            loan.Id,
            customer.Id,
            DateTime.Now
        );

        await _sut.Add(dto);

        var actual = ReadContext.Set<LoanRequest>().Single();
        actual.LoanId.Should().Be(dto.LoanId);
        actual.CustomerId.Should().Be(customer.Id);
        actual.CustomerId.Should().Be(customer.Id);
    }

    [Theory]
    [InlineData("2420786719")]
    public async Task Add_throw_exception_when_customer_not_found(string nationalCode)
    {
        var customer= new CustomerBuilder().WithNationalCode(nationalCode).Build();
        var loan =new LoanBuilder().Build();
        Save(loan);
        var dto = AddLoanRequestDtoFactory.Create(
            loan.Id,
            customer.Id,
            DateTime.Now
        );
        
        var actual =async ()=> await _sut.Add(dto);

       await actual.Should().ThrowExactlyAsync<CustomerIsentExistByThisNationalCodeException>();
    }

    [Theory]
    [InlineData("maskan")]
    public async Task Add_throw_exception_when_loan_not_found_with_this_name(string loanname)
    {
        var customer = new CustomerBuilder().Build();
        Save(customer);
        var loan = new LoanBuilder().WithLoanName(loanname).Build();
        var dto = AddLoanRequestDtoFactory.Create(
            loan.Id,
            customer.Id,
            DateTime.Now
        );

        var actual = async () => await _sut.Add(dto);

        await actual.Should().ThrowExactlyAsync<LoanIsentExistException>();
    }
    [Theory]
    [InlineData("2420786719")]
    public async Task Add_throw_exception_when_loan_request_alredy_exist(string nationacode)
    {
        var customer = new CustomerBuilder().WithNationalCode(nationacode).Build();
        Save(customer);
        var loan = new LoanBuilder().Build();
        Save(loan);
        var loanrequest=new LoanRequestBuilder()
            .WithCustomerId(customer.Id)
            .WithLoanId(loan.Id)
            .WithRequestDate(DateTime.Now).Build();
        Save(loanrequest);
        var dto = AddLoanRequestDtoFactory.Create(
            loan.Id,
            customer.Id,
            DateTime.Now
        );
        
        var actual = async () => await _sut.Add(dto);
        
        await actual.Should().ThrowExactlyAsync<LoanRequestAllredyExistException>();
    }
    
    
}