namespace LoanManagementSystem.TestTools.Customers.CustomerBuilders;

public class CustomerBuilder
{
    private readonly Customer _customer;

    public CustomerBuilder()
    {
        _customer = new Customer
        {
            FirstName = "test_user",
            LastName = "test_user",
            NationalCode = "1234567890",
            PhoneNumber = "12345678910",
        };
    }

    public CustomerBuilder WithFirstName(string firstName)
    {
        _customer.FirstName = firstName;
        return this;
    }

    public CustomerBuilder WithLastName(string lastName)
    {
        _customer.LastName = lastName;
        return this;
    }

    public CustomerBuilder WithNationalCode(string nationalCode)
    {
        _customer.NationalCode = nationalCode;
        return this;
    }

    public CustomerBuilder WithPhoneNumber(string phoneNumber)
    {
        _customer.PhoneNumber = phoneNumber;
        return this;
    }

    public CustomerBuilder WithEmail(string email)
    {
        _customer.Email = email;
        return this;
    }

    public CustomerBuilder WithMonthlyincome(decimal monthlyIncome)
    {
        _customer.Monthlyincome = monthlyIncome;
        return this;
    }

    public CustomerBuilder WithIncomeLevelEnum(IncomeLevelEnum incomeLevel)
    {
        _customer.IncomeLevel = incomeLevel;
        return this;
    }

    public CustomerBuilder WithJobType(JobTypeEnum jobType)
    {
        _customer.JobType = jobType;
        return this;
    }

    public CustomerBuilder WithFinancialAssets(decimal financialAssets)
    {
        _customer.FinancialAssets = financialAssets;
        return this;
    }

    public CustomerBuilder WithIsIdentityVerified(bool isIdentityVerified)
    {
        _customer.IsIdentityVerified = isIdentityVerified;
        return this;
    }

    public CustomerBuilder WithIsFinancialInfoVerified(bool isFinancialInfoVerified)
    {
        _customer.IsFinancialInfoVerified = isFinancialInfoVerified;
        return this;
    }

    public CustomerBuilder WithCreditScore(int creditScore)
    {
        _customer.CreditScore = creditScore;
        return this;
    }

    public CustomerBuilder WithLoanRequests(List<LoanRequest> LoanRequests)
    {
        _customer.LoanRequests = LoanRequests;
        return this;
    }

    public Customer Build()
    {
        return _customer;
    }
    
}