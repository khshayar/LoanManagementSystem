using System.Data;
using FluentMigrator;
namespace LoanManagement.Migration.Migrations;
[Migration(20241141652)]
public class _20241141652_initial_loanrequest:FluentMigrator.Migration
{
    public override void Up()
    {
        Create.Table("LoanRequests")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("CustomerId").AsInt32().NotNullable()
            .WithColumn("LoanId").AsInt32().NotNullable()
            .WithColumn("RequestDate").AsDateTime().NotNullable()
            .WithColumn("LoanApprovalDate").AsDateTime().Nullable()
            .WithColumn("AssignedCreditScore").AsInt32().NotNullable()
            .WithColumn("Status").AsInt32().NotNullable();
        Create.ForeignKey("FK_LoanRequests_Customers")
            .FromTable("LoanRequests").ForeignColumn("CustomerId")
            .ToTable("Customers").PrimaryColumn("Id")
            .OnDelete(Rule.Cascade);
        Create.ForeignKey("FK_LoanRequests_Loans")
            .FromTable("LoanRequests").ForeignColumn("LoanId")
            .ToTable("Loans").PrimaryColumn("Id")
            .OnDelete(Rule.Cascade);
    }

    public override void Down()
    {
        Delete.ForeignKey("FK_LoanRequests_Loans");
        Delete.ForeignKey("FK_LoanRequests_Customers");
        Delete.Table("LoanRequests");
    }
}