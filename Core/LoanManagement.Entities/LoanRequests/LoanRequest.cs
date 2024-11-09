using LoanManagement.Entities.Customers;
using LoanManagement.Entities.Installments;
using LoanManagement.Entities.Loans;

namespace LoanManagement.Entities.LoanRequests;

public class LoanRequest
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int LoanId { get; set; }
    public Loan Loan { get; set; }
    public LoanStatusEnum Status { get; set; }
    public DateTime RequestDate { get; set; }
    public DateTime? LoanApprovalDate { get; set; }
    public int AssignedCreditScore { get; set; }
    public List<Installment> Installments { get; set; } = [];

}

public enum LoanStatusEnum
{
    Pending,       
    Approved,      
    Rejected,      
    Repayment,     
    Delinquent,    
    Closed         
}