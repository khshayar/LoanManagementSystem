using LoanManagement.Services.Customers;
using LoanManagement.Services.Customers.Contracts;
using LoanManagement.Services.Installments;
using LoanManagement.Services.Installments.Contracts;
using LoanManagement.Services.LoanRequests;
using LoanManagement.Services.LoanRequests.Contracts;
using LoanManagement.Services.Loans;
using LoanManagement.Services.Loans.Contracts;
using LoanManagement.Services.UnitOfWorks;
using LoanManagementSystem.Persistence.Ef.Customers;
using LoanManagementSystem.Persistence.Ef.DataContexts;
using LoanManagementSystem.Persistence.Ef.Installments;
using LoanManagementSystem.Persistence.Ef.LoanRequests;
using LoanManagementSystem.Persistence.Ef.Loans;
using LoanManagementSystem.Persistence.Ef.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EfDataContext>(option=>option
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<UnitOfWork, EfUnitOfWork>();
builder.Services.AddScoped<CustomerService, CustomerAppService>();
builder.Services.AddScoped<CustomerRepository, EfCustomerRepository>();
builder.Services.AddScoped<CustomerQuery, EfCustomerQuery>();
builder.Services.AddScoped<LoanService, LoanAppService>();
builder.Services.AddScoped<LoanRepository, EfLoanRepository>();
builder.Services.AddScoped<LoanQuery, EfLoanQuery>();
builder.Services.AddScoped<InstallmentService, InstallmentAppService>();
builder.Services.AddScoped<InstallmentRepository, EfInstallmentRepository>();
builder.Services.AddScoped<InstallmentQuery, EfInstallmentQuery>();
builder.Services.AddScoped<LoanRequestService, LoanRequestAppService>();
builder.Services.AddScoped<LoanRequestRepository, EfLoanRequestRepository>();
builder.Services.AddScoped<LoanRequestQuery, EfLoanRequestQuery>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();