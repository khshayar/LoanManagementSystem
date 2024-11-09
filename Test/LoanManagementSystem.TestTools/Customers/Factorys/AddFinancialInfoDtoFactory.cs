using LoanManagement.Services.Customers.Contracts.Dtos;

namespace LoanManagementSystem.TestTools.Customers.Factorys;

public static class AddFinancialInfoDtoFactory
{
    public static AddFinancialInfoDto Create
        (IncomeLevelEnum incomeLevel = IncomeLevelEnum.Medium,
            JobTypeEnum jobType =JobTypeEnum.SelfEmployed
            , decimal financialAssets = 100000,decimal monthlyIncome = 6000000)

    {
        return new AddFinancialInfoDto()
        {
            IncomeLevel = incomeLevel,
            FinancialAssets = financialAssets,
            JobType = jobType,
            Monthlyincome = monthlyIncome
            
        };

    }
}