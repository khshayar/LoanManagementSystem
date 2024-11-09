namespace LoanManagementSystem.Persistence.Ef.Customers;

public class CustomerEntityMap:IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        builder.Property(x=>x.FirstName)
            .IsRequired();
        builder.Property(x=>x.LastName)
            .IsRequired();
        builder.Property(x => x.Email)
            .IsRequired(false);
        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(11).IsRequired();
        builder.Property(x => x.NationalCode)
            .HasMaxLength(10) 
            .IsRequired();
        builder.Property(x => x.IncomeLevel)
            .IsRequired(false); 
        builder.Property(x => x.JobType)
            .IsRequired(false); 
        builder.Property(x=>x.Monthlyincome)
            .IsRequired(false);
        builder.Property(x => x.FinancialAssets)
            .IsRequired(false); 
        builder.Property(x => x.IsIdentityVerified)
            .IsRequired(); 
        builder.Property(x => x.IsFinancialInfoVerified)
            .IsRequired(false);
        builder.Property(x => x.CreditScore)
            .IsRequired(false); 
    }
}