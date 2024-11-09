namespace LoanManagement.Services.Customers;

public class CustomerAppService
    (UnitOfWork unitOfWork, CustomerRepository repository) : CustomerService
{
    public async Task Add(AddCustomerDto dto)
    {
        var isDuplicateByNationalCode = await repository
            .DuplicateByNationalCode(dto.NationalCode);
        if (isDuplicateByNationalCode)
        {
            throw new
                CustomerNationalCodeDuplicateException();
        }

        if (dto.NationalCode.Length != 10)
        {
            throw new
                CustomerNationalCodeOutOfRangeException();
        }
        if (dto.PhoneNumber.Length != 11)
        {
            throw new
                CustomerPhoneNumberOutOfRangeException();
        }
        var customer = new Customer()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            NationalCode = dto.NationalCode,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
        };
       await repository.Add(customer);
       await unitOfWork.Save();
    }

    public async Task VerifyInfo(string nationalCode)
    {
        var isDuplicateByNationalCode = await repository
            .DuplicateByNationalCode(nationalCode);
        if (!isDuplicateByNationalCode)
        {
            throw new
                CustomerIsentExistByThisNationalCodeException();
        }

        var customer = await repository.Find(nationalCode);

        customer.IsIdentityVerified = true; 
        
        await unitOfWork.Save();
    }

    public async Task AddFinancialInfo(string nationalCode, AddFinancialInfoDto dto)
    {
        var isDuplicateByNationalCode = await repository
            .DuplicateByNationalCode(nationalCode);
        if (!isDuplicateByNationalCode)
        {
            throw new
                CustomerIsentExistByThisNationalCodeException();
        }

        var customer = await repository.Find(nationalCode);

        if (customer.IsFinancialInfoVerified==true)
        {
            throw new
                CustomerFinancialInfoAlredyExistException();
        }
        customer.FinancialAssets = dto.FinancialAssets;
        customer.IncomeLevel = dto.IncomeLevel;
        customer.JobType = dto.JobType;
        customer.Monthlyincome = dto.Monthlyincome;
        await unitOfWork.Save();
    }

    public async Task VerifyFinacialInfo(string nationalCode)
    {
        var isDuplicateByNationalCode = await repository
            .DuplicateByNationalCode(nationalCode);
        if (!isDuplicateByNationalCode)
        {
            throw new
                CustomerIsentExistByThisNationalCodeException();
        }

        var customer = await repository.Find(nationalCode);

        if (customer.IsFinancialInfoVerified == true)
        {
            throw new 
                CustomerFinancialInfoAlredyVerifiedException();
        }
        customer.IsFinancialInfoVerified = true;
        await unitOfWork.Save();

    }

    public async Task UpdatePersonalInfo(string nationalCode, UpdateCustomerDto dto)
    {
        var isDuplicateByNationalCode = await repository
            .DuplicateByNationalCode(nationalCode);
        if (!isDuplicateByNationalCode)
        {
            throw new
                CustomerIsentExistByThisNationalCodeException();
        }
        Customer customer=await repository.Find(nationalCode);
        if (customer.FirstName ==dto.FirstName|| 
            customer.LastName ==dto.LastName||
            customer.PhoneNumber ==dto.PhoneNumber||
            customer.Email ==dto.Email)
        {
            throw new
                UpdateCustomerDuplicatedException();
        }
        if (dto.PhoneNumber.Length != 11)
        {
            throw new
                CustomerPhoneNumberOutOfRangeException();
        }
        customer.FirstName = dto.FirstName;
        customer.LastName = dto.LastName;
        customer.PhoneNumber = dto.PhoneNumber;
        customer.Email = dto.Email;
        customer.IsIdentityVerified = false;
        await unitOfWork.Save();
    }

    public async Task UpdateFinancialInfo(string nationalCode, UpdateCustomerDto dto)
    {
        var isDuplicateByNationalCode = await repository
            .DuplicateByNationalCode(nationalCode);
        if (!isDuplicateByNationalCode)
        {
            throw new
                CustomerIsentExistByThisNationalCodeException();
        }
        var customer=await repository.Find(nationalCode);
        if (customer.FinancialAssets==dto.FinancialAssets||
            customer.IncomeLevel==dto.IncomeLevel||
            customer.JobType==dto.JobType||
            customer.Monthlyincome==dto.Monthlyincome)
        {
            throw new
                UpdateCustomerDuplicatedException();
        }
        customer.FinancialAssets = dto.FinancialAssets;
        customer.IncomeLevel = dto.IncomeLevel;
        customer.JobType = dto.JobType;
        customer.Monthlyincome = dto.Monthlyincome;
        customer.IsFinancialInfoVerified = false;
        unitOfWork.Save();
        
    }
}