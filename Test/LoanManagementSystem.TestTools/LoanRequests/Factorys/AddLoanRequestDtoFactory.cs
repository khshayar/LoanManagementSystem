using LoanManagement.Services.LoanRequests.Contracts.Dtos;

namespace LoanManagementSystem.TestTools.LoanRequests.Factorys;

public static class AddLoanRequestDtoFactory
{
    public static AddLoanRequestDto Create(int loanId, int customerId
        , DateTime requestDate)
    {
        return new AddLoanRequestDto()
        {
            CustomerId = customerId,
            LoanId = loanId,
            RequestDate = requestDate,
        };
    }
}