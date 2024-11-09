using System.Security.Cryptography;
using LoanManagement.Services.Customers.Contracts.Dtos;
using LoanManagement.Services.LoanRequests;
using LoanManagement.Services.LoanRequests.Contracts.Dtos;

namespace LoanManagementSystem.Persistence.Ef.LoanRequests;

public class EfLoanRequestQuery(EfDataContext context) : LoanRequestQuery
{
    public async Task<LoanRequest?> Read(int id)
    {
        return await context.Set<LoanRequest>()
            .Include(_ => _.Loan).FirstOrDefaultAsync(_ => _.Id == id);
    }

    public async Task<List<ReadLoanRequestReportofactiveandoverdueloansDto>> Reportofactiveandoverdueloans()
    {
        var report = await context.Set<LoanRequest>()
            .Include(_ => _.Installments)
            .Where(_ => _.Status == LoanStatusEnum.Repayment || _.Status == LoanStatusEnum.Delinquent)
            .Select(_ => new ReadLoanRequestReportofactiveandoverdueloansDto
            {
                LoanRequestId = _.Id,
                Status = _.Status,
                TotalPaidAmount = _.Installments
                    .Where(_ => _.IsPaid)
                    .Sum(_ => _.Amount),
                RemainingInstallments = _.Installments.Count(_ => !_.IsPaid)


            }).ToListAsync();
        return report;
    }

    public async Task<List<GetRiskyCustomerDto>> GetRiskyCustomersReportAsync()
    {
        var riskyCustomers = await context.Set<LoanRequest>()
            .Include(_=>_.Installments)
            .Include(_=>_.Customer)
            .Where(_=>_.Installments.Count(_=>!_.IsPaid&&_.DueDate<DateTime.Now) > 2)
            .Select(_=> new GetRiskyCustomerDto
            {
                CustomerId = _.CustomerId,
                CustomerName = _.Customer.FirstName,
                NationalCode = _.Customer.NationalCode,
                DelayedInstallmentsCount = _.Installments.Count(i => !i.IsPaid && i.DueDate < DateTime.Now)
            }).Distinct()
            .ToListAsync();
        return riskyCustomers;
    }

    public async Task<List<ClosedLoanReportDto>> GetClosedLoansReportAsync()
    {
        var closedLoansReport = await context.Set<LoanRequest>()
            .Include(lr => lr.Installments)
            .Where(lr => lr.Installments.All(inst => inst.IsPaid)) 
            .Select(lr => new ClosedLoanReportDto
            {
                LoanId = lr.Id,
                TotalLoanAmount = lr.Installments.Sum(inst => inst.Amount),
                PaidInstallmentsCount = lr.Installments.Count(),
                TotalLateFees = lr.Installments
                    .Where(inst => inst.DueDate < inst.PaymentDate)
                    .Sum(inst => inst.Amount * 0.02m)
            })
            .ToListAsync();
        return closedLoansReport;
    }
}