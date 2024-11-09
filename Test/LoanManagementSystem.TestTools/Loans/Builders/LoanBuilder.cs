using LoanManagement.Entities.Loans;
using LoanManagement.Services.Loans.Exceptions;

namespace LoanManagementSystem.TestTools.Loans.Builders;

public class LoanBuilder
{
    private Loan _loan;

    public LoanBuilder()
    {
        _loan = new Loan()
        {
            Amount = 10000000,
            DurationMonths = 12,
            InterestRate = (12 / 12) * (15 / 100) * 10000000,
            LoanName = "maskan"
        };
    }

    public LoanBuilder WithAmount(decimal amount)
    {
        _loan.Amount = amount;
        return this;
    }

    public LoanBuilder WithDurationMonths(int durationMonths)
    {
        _loan.DurationMonths = durationMonths;
        return this;
    }

    public LoanBuilder WithInterestRate(decimal interestRate)
    {
        _loan.InterestRate = interestRate;
        return this;
    }

    public LoanBuilder WithLoanName(string loanName)
    {
        _loan.LoanName = loanName;
        return this;
    }

    public Loan Build()
    {
        return _loan;
    }
}