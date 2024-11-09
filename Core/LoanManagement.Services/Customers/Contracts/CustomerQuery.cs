namespace LoanManagement.Services.Customers.Contracts;

public interface CustomerQuery
{
    Task<Customer?> Read(int Id);
}