using FluentMigrator;
namespace LoanManagement.Migration.Migrations;
[Migration(20241141646)]
public class _20241141646_initial_loan:FluentMigrator.Migration
{
    public override void Up()
    {
        Create.Table("Loans")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("LoanName").AsString(100).NotNullable()
            .WithColumn("Amount").AsDecimal().NotNullable()
            .WithColumn("DurationMonths").AsInt32().NotNullable() 
            .WithColumn("InterestRate").AsDecimal().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Loans");
    }
}