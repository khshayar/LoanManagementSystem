using LoanManagement.Entities.Loans;
using LoanManagement.Services.Loans;
using LoanManagement.Services.Loans.Contracts;
using LoanManagementSystem.TestTools.Customers.Factorys;
using LoanManagementSystem.TestTools.Loans.Factorys;

namespace LoanManagementSystem.Service.Unit.Tests.Loans;

public class LoanServiceTest:BusinessIntegrationTest
{
    private readonly LoanService _sut;

    public LoanServiceTest()
    {
        _sut = LoanServiceFactory.CreateLoanService(SetupContext);
    }

    [Fact]
    public async Task Add_add_a_loan_properly()
    {
        var dto = new AddLoanDtoBuilder().Build();
        
        await _sut.Add(dto);

        var actual = ReadContext.Set<Loan>().Single();
        
        actual.LoanName.Should().Be(dto.LoanName);
        actual.Should().BeEquivalentTo(dto);
    }

    [Theory]
    [InlineData("maskan")]
    public async Task Add_throw_exception_when_name_Duplicated(string maskan)
    {
        var loan=new LoanBuilder().WithLoanName(maskan).Build();
        Save(loan);
        var dto = new AddLoanDtoBuilder().WithLoanName(maskan).Build();
        
        var actual =async () =>await _sut.Add(dto);

       await actual.Should().ThrowExactlyAsync<LoanNameDuplicatedException>();
    }
    
    
    
}