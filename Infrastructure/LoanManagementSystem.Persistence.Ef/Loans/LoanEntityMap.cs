namespace LoanManagementSystem.Persistence.Ef.Loans;

public class LoanEntityMap:IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        builder.ToTable("Loans");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        builder.Property(x => x.LoanName)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.Amount)
            .IsRequired();

        builder.Property(x => x.DurationMonths)
            .IsRequired();
        builder.Property(x => x.InterestRate)
            .IsRequired();
    }
}