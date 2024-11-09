namespace LoanManagementSystem.TestTools.LoanRequests.Builders;

public class LoanRequestBuilder
{
    private readonly LoanRequest _loanRequest;

    public LoanRequestBuilder()
    {
        _loanRequest = new LoanRequest();
    }
    
    public LoanRequestBuilder WithLoanId(int LoanId)
    {
        _loanRequest.LoanId = LoanId;
        return this;
    }

    public LoanRequestBuilder WithCustomerId(int CustomerId)
    {
        _loanRequest.CustomerId = CustomerId;
        return this;
    }

    public LoanRequestBuilder WithLoanStatus(LoanStatusEnum LoanStatus)
    {
        _loanRequest.Status = LoanStatus;
        return this;
    }

    public LoanRequestBuilder WithAssignedCreditScore(int AssignedCreditScore)
    {
        _loanRequest.AssignedCreditScore = AssignedCreditScore;
        return this;
    }

    public LoanRequestBuilder WithRequestDate(DateTime RequestDate)
    {
        _loanRequest.RequestDate = RequestDate;
        return this;
    }

    public LoanRequestBuilder WithLoanApprovedDate(DateTime LoanApprovedDate)
    {
        _loanRequest.LoanApprovalDate = LoanApprovedDate;
        return this;
    }

    public LoanRequest Build()
    {
        return _loanRequest;
    }
    
}