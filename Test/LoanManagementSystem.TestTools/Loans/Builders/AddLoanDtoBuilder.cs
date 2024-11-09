using LoanManagement.Services.Loans.Exceptions;

namespace LoanManagementSystem.TestTools.Loans.Builders;

public class AddLoanDtoBuilder
{
    private AddLoanDto _addLoanDto;

    public AddLoanDtoBuilder()
    {
        _addLoanDto = new AddLoanDto()
        {
            Amount = 1000000,
            DurationMonths = 6,
            InterestRate = (6 / 12) * (15 / 100) * 1000000,
            LoanName = "kala"
        };
    }

    public AddLoanDtoBuilder WithAmount(decimal amount)
    {
        _addLoanDto.Amount = amount;
        return this;
    }

    public AddLoanDtoBuilder WithDurationMonths(int durationMonths)
    {
        _addLoanDto.DurationMonths = durationMonths;
        return this;
    }

    public AddLoanDtoBuilder WithInterestRate(decimal interestRate)
    {
        _addLoanDto.InterestRate = interestRate;
        return this;
    }

    public AddLoanDtoBuilder WithLoanName(string loanName)
    {
        _addLoanDto.LoanName = loanName;
        return this;
    }

    public AddLoanDto Build()
    {
        return _addLoanDto;
    }
}