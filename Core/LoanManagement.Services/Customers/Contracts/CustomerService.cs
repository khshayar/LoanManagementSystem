namespace LoanManagement.Services.Customers.Contracts;

public interface CustomerService
{
    Task Add(AddCustomerDto dto);
    Task VerifyInfo(string nationalCode);
    Task AddFinancialInfo(string nationalCode, AddFinancialInfoDto dto);
    Task VerifyFinacialInfo(string nationalCode);
    Task UpdatePersonalInfo(string nationalCode, UpdateCustomerDto dto);
    Task UpdateFinancialInfo(string nationalCode, UpdateCustomerDto dto);
}