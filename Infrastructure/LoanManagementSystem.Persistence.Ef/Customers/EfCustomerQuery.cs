namespace LoanManagementSystem.Persistence.Ef.Customers;

public class EfCustomerQuery(EfDataContext context):CustomerQuery
{
    public async Task<Customer?> Read(int Id)
    {
        return await context.Set<Customer>().FirstOrDefaultAsync(x => x.Id == Id);
    }
}