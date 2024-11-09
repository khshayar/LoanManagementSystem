using LoanManagement.Entities.LoanRequests;
using LoanManagement.Services.LoanRequests.Contracts.Dtos;
using LoanManagement.Services.LoanRequests.Exceptions;
using LoanManagement.Services.Loans;
using LoanManagement.Services.Loans.Exceptions;

namespace LoanManagement.Services.LoanRequests;

public class LoanRequestAppService
    (UnitOfWork unitOfWork,LoanRequestRepository repository
        ,CustomerQuery customerQuery,LoanQuery loanQuery):LoanRequestService
{
    
    public async Task Add(AddLoanRequestDto dto)
    {
        var customer=await customerQuery.Read(dto.CustomerId);
        var loan=await loanQuery.Read(dto.LoanId);
        if (customer==null)
        {
            throw new
                CustomerIsentExistByThisNationalCodeException();
        }

        if (loan==null)
        {
            throw new
                LoanIsentExistException();
        }

        var isExist= await repository.Find(dto.LoanId);
        if (isExist)
        {
            throw new
                LoanRequestAllredyExistException();
        }

        var loanRequest = new LoanRequest();
        loanRequest.LoanId = dto.LoanId;
        loanRequest.CustomerId = dto.CustomerId;
        loanRequest.RequestDate = dto.RequestDate;
        loanRequest.Status = LoanStatusEnum.Pending;
        int assignedCreditScore = 0;
        if (customer.Monthlyincome>10000000)
        {
            assignedCreditScore += 20;
        }else if (10000000>=customer.Monthlyincome && customer.Monthlyincome>=5000000)
        {
            assignedCreditScore += 10;
        }else if (customer.Monthlyincome<5000000)
        {
            assignedCreditScore +=0;
        }
        var notPayment=await repository.IsEntPaidedCount(dto.CustomerId);
        if (notPayment==0)
        {
            assignedCreditScore += 30;
        }
        else
        {
            assignedCreditScore -= (notPayment * 5);
        }

        if (customer.JobType==JobTypeEnum.GovernmentEmployee)
        {
            assignedCreditScore += 20;
        }
        else if (customer.JobType==JobTypeEnum.SelfEmployed)
        {
            assignedCreditScore += 10;
        }
        else if (customer.JobType==JobTypeEnum.Unemployed)
        {
            assignedCreditScore += 0;
        }

        if (loan.Amount<customer.FinancialAssets/2)
        {
            assignedCreditScore += 20;
        }
        else if (loan.Amount >= customer.FinancialAssets / 2 &&
                  loan.Amount <= customer.FinancialAssets * 0.7m)
        {
            assignedCreditScore += 10;
        }
        else if(loan.Amount > customer.FinancialAssets * 0.7m)
        {
            assignedCreditScore += 0;
        }

        if (assignedCreditScore>=60)
        {
            loanRequest.Status = LoanStatusEnum.Approved;
            loanRequest.LoanApprovalDate = DateTime.Now;
        }
        else
        {
            loanRequest.Status = LoanStatusEnum.Rejected;
        }
        await repository.Add(loanRequest);
        await unitOfWork.Save();

    }
}