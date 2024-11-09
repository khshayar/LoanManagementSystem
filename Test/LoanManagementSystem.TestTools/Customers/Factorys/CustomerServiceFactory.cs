namespace LoanManagementSystem.TestTools.Customers.Factorys;

public static class CustomerServiceFactory
{
    public static CustomerService CreateService(EfDataContext context)
    {
        var repository = new EfCustomerRepository(context);
        var unitOfWork = new EfUnitOfWork(context);
        return new CustomerAppService(unitOfWork, repository);
    }
}