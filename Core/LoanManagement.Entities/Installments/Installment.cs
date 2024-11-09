using LoanManagement.Entities.LoanRequests;

namespace LoanManagement.Entities.Installments;

public class Installment
{
    public int Id { get; set; }
    public int LoanRequestId { get; set; }
    public LoanRequest LoanRequest { get; set; }
    public decimal Amount { get; set; } 
    public DateTime DueDate { get; set; }
    public bool IsPaid { get; set; }
    public decimal LateFee => IsPaid ? 0 : Amount * 0.02m; 
    public DateTime? PaymentDate { get; set; }
}