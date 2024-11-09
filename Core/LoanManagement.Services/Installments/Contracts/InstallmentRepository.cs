namespace LoanManagement.Services.Installments.Contracts;

public interface InstallmentRepository
{
    Task AddRange(List<Installment> installments);
    Task <bool> IsExistByLoanRequestId(int dtoLoanRequestId);
}