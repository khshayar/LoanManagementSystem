using LoanManagement.Entities.Installments;
using LoanManagement.Services.Installments.Contracts.Dtos;

namespace LoanManagementSystem.TestTools.Installments.Builders;

public class InstallmensBuilder
{
    private readonly Installment _installment;

    public InstallmensBuilder()
    {
        _installment = new Installment();
    }

    public InstallmensBuilder WithLoanRequestId(int loanRequestId)
    {
        _installment.LoanRequestId = loanRequestId;
        return this;
    }

    public InstallmensBuilder WithAmount(decimal amount)
    {
        _installment.Amount = amount;
        return this;
    }

    public InstallmensBuilder WithDueDate(DateTime dueDate)
    {
        _installment.DueDate = dueDate;
        return this;
    }

    public InstallmensBuilder WithIsPaid(bool isPaid)
    {
        _installment.IsPaid = isPaid;
        return this;
    }

    public InstallmensBuilder WithPaymentDate(DateTime? paymentDate)
    {
        _installment.PaymentDate = paymentDate;
        return this;
    }

    public Installment Build()
    {
        return _installment;
    }
}