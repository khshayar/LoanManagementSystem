namespace LoanManagementSystem.Persistence.Ef.Customers;
public class EfCustomerRepository
    (EfDataContext context):CustomerRepository
{
    public async Task<bool> DuplicateByNationalCode(string nationalCode)
    {
        return await context.Set<Customer>().AnyAsync(n => n.NationalCode == nationalCode);
    }

    public async Task Add(Customer customer)
    {
        await context.Set<Customer>().AddAsync(customer);
    }

    public async Task<Customer> Find(string nationalCode)
    {
        return await context.Set<Customer>().FirstAsync(n => n.NationalCode == nationalCode);
    }
}