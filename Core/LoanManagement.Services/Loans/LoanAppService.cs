using LoanManagement.Entities.Loans;
using LoanManagement.Services.Loans.Contracts;
using LoanManagement.Services.Loans.Exceptions;

namespace LoanManagement.Services.Loans;

public class LoanAppService(UnitOfWork unitOfWork, LoanRepository repository) :LoanService
{
    public async Task Add(AddLoanDto dto)
    {
        var isExistByName =await repository.Find(dto.LoanName);
        if (isExistByName)
        {
            throw new
                LoanNameDuplicatedException();
        }

        var loan = new Loan()
        {
            LoanName = dto.LoanName,
            Amount = dto.Amount,
            DurationMonths = dto.DurationMonths,
            InterestRate = dto.InterestRate,
        };
        await repository.Add(loan);
        await unitOfWork.Save();
    }
}