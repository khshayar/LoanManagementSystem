using System.Data;
using FluentMigrator;

namespace LoanManagement.Migration.Migrations;
[Migration(20241141713)]
public class _20241141713_initial_installment: FluentMigrator.Migration
{
    public override void Up()
    {
        Create.Table("Installments")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity() 
            .WithColumn("LoanRequestId").AsInt32()
            .ForeignKey("LoanRequests", "Id")
            .OnDelete(Rule.Cascade) 
            .WithColumn("Amount").AsDecimal().NotNullable()
            .WithColumn("DueDate").AsDateTime().NotNullable() 
            .WithColumn("IsPaid").AsBoolean().NotNullable() 
            .WithColumn("PaymentDate").AsDateTime().Nullable();
    }

    public override void Down()
    {
        Delete.Table("Installments");
    }
}