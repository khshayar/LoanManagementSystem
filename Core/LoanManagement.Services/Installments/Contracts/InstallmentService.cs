namespace LoanManagement.Services.Installments.Contracts;

public interface InstallmentService
{
    Task AddRange(AddInstallmentDto dto);
}