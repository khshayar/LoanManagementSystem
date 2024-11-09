namespace LoanManagement.Services.Installments.Contracts.Dtos;

public class AddInstallmentDto
{
    public int LoanRequestId { get; set; }
    public decimal Amount { get; set; } 
    public DateTime DueDate { get; set; }
    public bool IsPaid { get; set; }
    public DateTime? PaymentDate { get; set; }
}