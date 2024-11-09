namespace LoanManagement.Services.Customers.Contracts;

public interface CustomerRepository
{
    Task<bool> DuplicateByNationalCode(string nationalCode);
    Task Add(Customer customer);
    Task<Customer> Find(string nationalCode);
}