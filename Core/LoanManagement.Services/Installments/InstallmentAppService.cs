namespace LoanManagement.Services.Installments;

public class InstallmentAppService
    (UnitOfWork unitOfWork,InstallmentRepository repository
    ,LoanRequestQuery loanRequestQuery):InstallmentService
{
    public async Task AddRange(AddInstallmentDto dto)
    {
        var loanRequest=await loanRequestQuery.Read(dto.LoanRequestId);
        if (loanRequest == null)
        {
            throw new
                LoanRequestIsentExistByThisIdException();
        }
        int installmentCount = loanRequest.Loan.DurationMonths;
        DateTime? dueDate = loanRequest.LoanApprovalDate;
        List<Installment> installments = new List<Installment>();
        if (await repository.IsExistByLoanRequestId(dto.LoanRequestId))
        {
            throw new
                InstallmentAllReadyExistByThisLoanRequest();

        }
        if (!dueDate.HasValue)
        {
            throw new
                ApprovaedDateNotSetException();
        }
        for (int i = 0; i < installmentCount; i++)
        {
            var installment = new Installment
            {
                LoanRequestId = dto.LoanRequestId,
                Amount = loanRequest.Loan.IsShortTerm 
                    ? loanRequest.Loan.Amount * (0.15m / 12) 
                    : loanRequest.Loan.Amount * (0.20m / 12),
                DueDate = dueDate.Value.AddMonths(i),
                IsPaid = false,
                PaymentDate = null
                
            };
        
            installments.Add(installment);
        }
        await repository.AddRange(installments);
        await unitOfWork.Save();
    }
}