namespace LoanManagement.Services.UnitOfWorks;

public interface UnitOfWork
{
    public Task Save();
    public Task Begin();
    public Task Commit();
    public Task Rollback();
}
