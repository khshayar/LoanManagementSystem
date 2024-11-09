using FluentMigrator;
namespace LoanManagement.Migration.Migrations;
[Migration(20241141629)]
public class _20241141629_initiali_customer:FluentMigrator.Migration
{
    public override void Up()
    {
        Create.Table("Customers")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("FirstName").AsString().NotNullable()
            .WithColumn("LastName").AsString().NotNullable()
            .WithColumn("Email").AsString().Nullable()
            .WithColumn("PhoneNumber").AsString(11).NotNullable()
            .WithColumn("NationalCode").AsString(10).NotNullable()
            .WithColumn("IncomeLevel").AsInt32().Nullable() 
            .WithColumn("JobType").AsInt32().Nullable()
            .WithColumn("Monthlyincome").AsDecimal().Nullable()
            .WithColumn("FinancialAssets").AsDecimal().Nullable() 
            .WithColumn("IsIdentityVerified").AsBoolean().NotNullable()
            .WithColumn("IsFinancialInfoVerified").AsBoolean().Nullable()
            .WithColumn("CreditScore").AsInt32().Nullable(); 
    }

    public override void Down()
    {
        Delete.Table("Customers");
    }
}