namespace LoanManagementSystem.Persistence.Ef.Installments;

public class EfInstallmentRepository
    (EfDataContext context):InstallmentRepository
{
    public async Task AddRange(List<Installment> installments)
    {
        await context.Set<Installment>().AddRangeAsync(installments);
    }

    public async Task<bool> IsExistByLoanRequestId(int dtoLoanRequestId)
    {
        return await context.Set<Installment>().AnyAsync(x => x.LoanRequestId == dtoLoanRequestId);
    }
}