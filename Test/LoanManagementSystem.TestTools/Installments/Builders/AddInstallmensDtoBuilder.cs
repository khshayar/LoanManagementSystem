using LoanManagement.Services.Installments.Contracts.Dtos;

namespace LoanManagementSystem.TestTools.Installments.Builders;

public class AddInstallmensDtoBuilder
{
    private readonly AddInstallmentDto _addInstallmentDto;

    public AddInstallmensDtoBuilder()
    {
        _addInstallmentDto = new AddInstallmentDto();
    }

    public AddInstallmensDtoBuilder WithLoanRequestId(int loanRequestId)
    {
        _addInstallmentDto.LoanRequestId = loanRequestId;
        return this;
    }

    public AddInstallmensDtoBuilder WithAmount(decimal amount)
    {
        _addInstallmentDto.Amount = amount;
        return this;
    }

    public AddInstallmensDtoBuilder WithDueDate(DateTime dueDate)
    {
        _addInstallmentDto.DueDate = dueDate;
        return this;
    }

    public AddInstallmensDtoBuilder WithIsPaid(bool isPaid)
    {
        _addInstallmentDto.IsPaid = isPaid;
        return this;
    }

    public AddInstallmensDtoBuilder WithPaymentDate(DateTime paymentDate)
    {
        _addInstallmentDto.PaymentDate = paymentDate;
        return this;
    }

    public AddInstallmentDto Build()
    {
        return _addInstallmentDto;
    }
}