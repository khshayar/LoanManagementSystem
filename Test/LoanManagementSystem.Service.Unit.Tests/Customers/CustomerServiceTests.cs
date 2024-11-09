using LoanManagement.Entities.Customers;
using LoanManagementSystem.TestTools.Customers;
using LoanManagementSystem.TestTools.Customers.Builders;
using LoanManagementSystem.TestTools.Customers.Factorys;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem.Service.Unit.Tests.Customers;

public class CustomerServiceTests:BusinessIntegrationTest
{
    private readonly CustomerService _sut;

    public CustomerServiceTests()
    {
        _sut = CustomerServiceFactory.CreateService(SetupContext);
    }

    [Fact]
    async Task Add_add_customer_properly()
    {
        var dto=new AddCustomerDtoBuilder().Build();
        
        await _sut.Add(dto);
        
        var actual = ReadContext.Set<Customer>().Single();
        
        actual.NationalCode.Should().Be(dto.NationalCode);
        actual.Should().BeEquivalentTo(dto, options => options.ExcludingMissingMembers());
    }

    [Theory]
    [InlineData("1234567890")]
    async Task Add_throw_exception_if_national_code_is_duplicate(string nationalCode)
    {
        var customer =new CustomerBuilder().WithNationalCode(nationalCode).Build();
        Save(customer);
        var dto = new AddCustomerDtoBuilder().WithNationalCode(nationalCode).Build();
        
        var actual = async ()=> await _sut.Add(dto);

        await actual.Should().ThrowExactlyAsync<CustomerNationalCodeDuplicateException>();

    }

    [Theory]
    [InlineData("12345678910","123456789")]
    async Task Add_throw_exception_if_national_code_is_invalid(string nationalCode1,string nationalCode2)
    {
        var dto1 = new AddCustomerDtoBuilder().WithNationalCode(nationalCode1).Build();
        var dto2 = new AddCustomerDtoBuilder().WithNationalCode(nationalCode1).Build();
        
        var actual1 = async ()=> await _sut.Add(dto1);
        var actual2 = async ()=> await _sut.Add(dto2);

        await actual1.Should().ThrowExactlyAsync<CustomerNationalCodeOutOfRangeException>();
        await actual2.Should().ThrowExactlyAsync<CustomerNationalCodeOutOfRangeException>();
    }
    
    [Theory]
    [InlineData("123456789101","123456789")]
    async Task Add_throw_exception_if_phone_number_is_invalid(string phoneNumber1,string phoneNumber2)
    {
        var dto1 = new AddCustomerDtoBuilder().WithPhoneNumber(phoneNumber1).Build();
        var dto2 = new AddCustomerDtoBuilder().WithPhoneNumber(phoneNumber2).Build();
        
        var actual1 = async ()=> await _sut.Add(dto1);
        var actual2 = async ()=> await _sut.Add(dto2);

        await actual1.Should().ThrowExactlyAsync<CustomerPhoneNumberOutOfRangeException>();
        await actual2.Should().ThrowExactlyAsync<CustomerPhoneNumberOutOfRangeException>();
    }

    [Theory]
    [InlineData("1234567890")]
    async Task VerifyInfo_verifies_customer_information_properly(string nationalCode)
    {
        var customer = new CustomerBuilder().WithNationalCode(nationalCode).Build();
        Save(customer);
        
       await _sut.VerifyInfo(nationalCode);
        
        var actual = await ReadContext.Set<Customer>().SingleAsync();
        
        actual.IsIdentityVerified.Should().Be(true);
    }
    
    [Theory]
    [InlineData("1234567890")]
    async Task VerifyInfo_throw_exception_when_customer_not_Found(string nationalCode)
    {
        var customer = new CustomerBuilder().WithNationalCode(nationalCode).Build();
        
        var actual= async ()=>await _sut.VerifyInfo(nationalCode);

        await actual.Should().ThrowExactlyAsync<CustomerIsentExistByThisNationalCodeException>();
    }

    [Theory]
    [InlineData("1234567890")]
    async Task AddFinancialInfo_add_financial_info_properly(string nationalCode)
    {
        var customer = new CustomerBuilder().WithNationalCode(nationalCode).Build();
        Save(customer);
        var dto = AddFinancialInfoDtoFactory.Create();
        await _sut.AddFinancialInfo(nationalCode, dto);
        
        var actual=await ReadContext.Set<Customer>().SingleAsync();
        
        actual.FinancialAssets.Should().Be(dto.FinancialAssets);
        actual.IncomeLevel.Should().Be(dto.IncomeLevel);
        actual.JobType.Should().Be(dto.JobType);
        actual.Monthlyincome.Should().Be(dto.Monthlyincome);
    }
    
    [Theory]
    [InlineData("1234567890")]
    async Task AddFinancialInfo_throw_exception_when_customer_is_ent_exist(string nationalCode)
    {
        var customer = new CustomerBuilder().WithNationalCode(nationalCode).Build();
        var dto = AddFinancialInfoDtoFactory.Create();
        
        var actual=async()=>await _sut.AddFinancialInfo(nationalCode, dto);
        
        await actual.Should().ThrowExactlyAsync<CustomerIsentExistByThisNationalCodeException>();
    }
    
    [Theory]
    [InlineData("1234567890")]
    async Task AddFinancialInfo_throw_exception_when_customer_Financial_info_is_exist
        (string nationalCode)
    {
        var customer = new CustomerBuilder().WithNationalCode(nationalCode)
            .WithJobType(JobTypeEnum.SelfEmployed).WithIncomeLevelEnum(IncomeLevelEnum.Medium)
            .WithFinancialAssets(100000).WithIsFinancialInfoVerified(true).Build();
        Save(customer);
        var dto = AddFinancialInfoDtoFactory.Create();
        
        var actual=async()=>await _sut.AddFinancialInfo(nationalCode, dto);
        
        await actual.Should().ThrowExactlyAsync<CustomerFinancialInfoAlredyExistException>();
    }

    [Theory]
    [InlineData("1234567890")]
    async Task VerifyFinancialInfo_verify_financial_information_propebly(string nationalCode)
    {
        var customer = new CustomerBuilder().WithNationalCode(nationalCode).Build();
        Save(customer);
        
        await _sut.VerifyFinacialInfo(nationalCode);
        
        var actual = await ReadContext.Set<Customer>().SingleAsync();
        actual.IsFinancialInfoVerified.Should().Be(true);
    }
    [Theory]
    [InlineData("1234567890")]
    async Task VerifyFinancial_throw_exception_when_customer_not_Found(string nationalCode)
    {
        var customer = new CustomerBuilder().WithNationalCode(nationalCode).Build();
        
        var actual= async ()=>await _sut.VerifyFinacialInfo(nationalCode);

        await actual.Should().ThrowExactlyAsync<CustomerIsentExistByThisNationalCodeException>();
    }
    
    [Theory]
    [InlineData("1234567890")]
    async Task VerifyFinancial_throw_exception_when_customer_financial_info_is_verified
        (string nationalCode)
    {
        var customer = new CustomerBuilder().WithNationalCode(nationalCode)
            .WithIsFinancialInfoVerified(true).Build();
        Save(customer);
        var actual= async ()=>await _sut.VerifyFinacialInfo(nationalCode);

        await actual.Should().ThrowExactlyAsync<CustomerFinancialInfoAlredyVerifiedException>();
    }
    

    [Theory]
    [InlineData("2430049063")]
    async Task UpdatePersonalInFo_update_a_Customer_personal_information_properly
        (string nationalCode)
    {
        var customer = new CustomerBuilder().WithNationalCode(nationalCode).Build();
        Save(customer);
        var dto = new UpdateCustomerDtoBuilder().WithFirstName("John").WithLastName("Doe")
            .WithEmail("tes.com").WithPhoneNumber("09033816342").Build();
        
         await _sut.UpdatePersonalInfo(nationalCode, dto);
        
        var actual = await ReadContext.Set<Customer>().SingleAsync();
        
        actual.FirstName.Should().Be(dto.FirstName);
        actual.LastName.Should().Be(dto.LastName);
        actual.PhoneNumber.Should().Be(dto.PhoneNumber);
        actual.Email.Should().Be(dto.Email);
    }
    
    [Theory]
    [InlineData("2430049063")]
    async Task UpdatePersonalInFo_throw_exception_when_a_Customer_not_found
        (string nationalCode)
    {
        var customer = new CustomerBuilder().WithNationalCode(nationalCode).Build();
        var dto = new UpdateCustomerDtoBuilder().WithFirstName("John").WithLastName("Doe")
            .WithEmail("tes.com").WithPhoneNumber("09033816342").Build();
        
        var actual = async ()=>await _sut.UpdatePersonalInfo(nationalCode, dto);
        
        await actual.Should().ThrowExactlyAsync<CustomerIsentExistByThisNationalCodeException>();
    }
    
    [Theory]
    [InlineData("2430049063")]
    async Task
        UpdatePersonalInFo_throw_exception_when_a_Customer_Duplicate_personal_information
        (string nationalCode)
    {
        var customer = new CustomerBuilder().WithFirstName("John").WithLastName("Doe")
            .WithEmail("tes.com").WithPhoneNumber("09033816342")
            .WithNationalCode(nationalCode).Build();
        Save(customer);
        var dto = new UpdateCustomerDtoBuilder().WithFirstName("John").WithLastName("Doe")
            .WithEmail("tes.com").WithPhoneNumber("09033816342").Build();
        
        var actual = async ()=>await _sut.UpdatePersonalInfo(nationalCode, dto);
        
        await actual.Should().ThrowExactlyAsync<UpdateCustomerDuplicatedException>();
    }
    [Theory]
    [InlineData("2430049063")]
    async Task
        UpdatePersonalInFo_throw_exception_when_a_Customer_enter_phone_number_out_of_range
        (string nationalCode)
    {
        var customer = new CustomerBuilder().WithNationalCode(nationalCode).Build();
        Save(customer);
        var dto = new UpdateCustomerDtoBuilder().WithFirstName("John").WithLastName("Doe")
            .WithEmail("tes.com").WithPhoneNumber("0903381634222").Build();
        
        var dto2 = new UpdateCustomerDtoBuilder().WithFirstName("John1").WithLastName("Doe2")
            .WithEmail("tess.com").WithPhoneNumber("0903").Build();
        
        var actual = async ()=>await _sut.UpdatePersonalInfo(nationalCode, dto);
        var actual2 = async ()=>await _sut.UpdatePersonalInfo(nationalCode, dto2);
        
        await actual.Should().ThrowExactlyAsync<CustomerPhoneNumberOutOfRangeException>();
        await actual2.Should().ThrowExactlyAsync<CustomerPhoneNumberOutOfRangeException>();
    }

    [Theory]
    [InlineData("2430049063")]
    async Task UpdateFinancialInfo_update_a_Customer_FinancialInfo_properly
        (string nationalCode)
    {
        var customer = new CustomerBuilder().WithNationalCode(nationalCode).Build();
        Save(customer);
        var dto = new UpdateCustomerDtoBuilder().WithJobType(JobTypeEnum.Unemployed)
            .WithMonthlyincome(7000000)
            .WithFinancialAssets(200000).WithIncomeLevel(IncomeLevelEnum.High).Build();
        
        await _sut.UpdateFinancialInfo(nationalCode, dto);
        
        var actual = await ReadContext.Set<Customer>().SingleAsync();
        actual.IncomeLevel.Should().Be(dto.IncomeLevel);
        actual.JobType.Should().Be(dto.JobType);
        actual.FinancialAssets.Should().Be(dto.FinancialAssets);
        actual.Monthlyincome.Should().Be(dto.Monthlyincome);
    }

    [Theory]
    [InlineData("2430049063")]
    async Task UpdateFinancialInfo_throw_exception_when_a_Customer_not_found
        (string nationalCode)
    {
        var customer = new CustomerBuilder().WithNationalCode(nationalCode).Build();
        var dto = new UpdateCustomerDtoBuilder().WithJobType(JobTypeEnum.Unemployed)
            .WithFinancialAssets(200000).WithIncomeLevel(IncomeLevelEnum.High).Build();
        
        var actual =async ()=>await _sut.UpdateFinancialInfo(nationalCode, dto);
        
        await actual.Should().ThrowExactlyAsync<CustomerIsentExistByThisNationalCodeException>();
    }
    
    [Theory]
    [InlineData("2430049063")]
    async Task UpdateFinancialInfo_throw_exception_when_a_Customer_Duplicated_financial_information
        (string nationalCode)
    {
        var customer = new CustomerBuilder().WithNationalCode(nationalCode)
            .WithJobType(JobTypeEnum.Unemployed)
            .WithFinancialAssets(200000).WithIncomeLevelEnum(IncomeLevelEnum.High).Build();
        Save(customer);
        var dto = new UpdateCustomerDtoBuilder().WithJobType(JobTypeEnum.Unemployed)
            .WithFinancialAssets(200000).WithIncomeLevel(IncomeLevelEnum.High).Build();
        
        var actual =async ()=>await _sut.UpdateFinancialInfo(nationalCode, dto);
        
        await actual.Should().ThrowExactlyAsync<UpdateCustomerDuplicatedException>();
    }
    
}