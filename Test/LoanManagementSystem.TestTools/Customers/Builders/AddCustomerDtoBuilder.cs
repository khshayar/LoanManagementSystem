using LoanManagement.Services.Customers.Contracts.Dtos;

namespace LoanManagementSystem.TestTools.Customers;

public class AddCustomerDtoBuilder
{
    private readonly AddCustomerDto _customer;

    public AddCustomerDtoBuilder()
    {
        _customer = new AddCustomerDto
        {
            FirstName = "test_user",
            LastName = "test_user",
            NationalCode = "1234567890",
            PhoneNumber = "12345678910",
            Email= "test_user@test.com",
        };
    }

    public AddCustomerDtoBuilder WithFirstName(string firstName)
    {
        _customer.FirstName = firstName;
        return this;
    }

    public AddCustomerDtoBuilder WithLastName(string lastName)
    {
        _customer.LastName = lastName;
        return this;
    }

    public AddCustomerDtoBuilder WithNationalCode(string nationalCode)
    {
        _customer.NationalCode = nationalCode;
        return this;
    }

    public AddCustomerDtoBuilder WithPhoneNumber(string phoneNumber)
    {
        _customer.PhoneNumber = phoneNumber;
        return this;
    }

    public AddCustomerDtoBuilder WithEmail(string email)
    {
        _customer.Email = email;
        return this;
    }

    public AddCustomerDto Build()
    {
        return _customer;
    }
}