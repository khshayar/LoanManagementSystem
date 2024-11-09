namespace LoanManagementSystem.Persistence.Ef.Loans;

public class EfLoanQuery(EfDataContext context):LoanQuery
{
    public async Task<Loan?> Read(int dtoLoanId)
    {
        return await context.Set<Loan>().FirstOrDefaultAsync(x => x.Id == dtoLoanId);
    }
}