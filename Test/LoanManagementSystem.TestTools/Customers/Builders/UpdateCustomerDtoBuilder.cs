using LoanManagement.Services.Customers.Contracts.Dtos;

namespace LoanManagementSystem.TestTools.Customers.Builders;

public class UpdateCustomerDtoBuilder
{
    private readonly UpdateCustomerDto _updateCustomerDto;

    public UpdateCustomerDtoBuilder()
    {
       _updateCustomerDto= new UpdateCustomerDto()
        {

            FirstName = "Update_user_",
            LastName = "Update_user_",
            PhoneNumber = "09033816365",
            Email = "Update_user@gmail.com"
        };
    }
    public UpdateCustomerDtoBuilder WithFirstName(string firstName)
    {
        _updateCustomerDto.FirstName = firstName;
        return this;
    }

    public UpdateCustomerDtoBuilder WithLastName(string lastName)
    {
        _updateCustomerDto.LastName = lastName;
        return this;
    }
    public UpdateCustomerDtoBuilder WithPhoneNumber(string phoneNumber)
    {
        _updateCustomerDto.PhoneNumber = phoneNumber;
        return this;
    }

    public UpdateCustomerDtoBuilder WithEmail(string email)
    {
        _updateCustomerDto.Email = email;
        return this;
    }

    public UpdateCustomerDtoBuilder WithIncomeLevel(IncomeLevelEnum IncomeLevel)
    {
        _updateCustomerDto.IncomeLevel = IncomeLevel;
        return this;
    }

    public  UpdateCustomerDtoBuilder WithJobType(JobTypeEnum JobType)
    {
        _updateCustomerDto.JobType = JobType;
        return this;
    }

    public UpdateCustomerDtoBuilder WithMonthlyincome(decimal MonthlyIncomeonthlyIncome)
    {
        _updateCustomerDto.Monthlyincome = MonthlyIncomeonthlyIncome;
        return this;
    }

    public UpdateCustomerDtoBuilder WithFinancialAssets(decimal FinancialAssets)
    {
        _updateCustomerDto.FinancialAssets = FinancialAssets;
        return this;
    }

    public UpdateCustomerDtoBuilder WithCreditScore(int CreditScore)
    {
        _updateCustomerDto.CreditScore = CreditScore;
        return this;
    }

    public   UpdateCustomerDto Build()
    {
        return _updateCustomerDto;
    }
    
}