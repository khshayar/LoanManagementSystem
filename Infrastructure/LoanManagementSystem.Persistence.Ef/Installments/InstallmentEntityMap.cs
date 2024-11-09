namespace LoanManagementSystem.Persistence.Ef.Installments;

public class InstallmentEntityMap:IEntityTypeConfiguration<Installment>
{
    public void Configure(EntityTypeBuilder<Installment> builder)
    {
        builder.ToTable("Installments");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        builder.Property(x => x.Amount)
            .IsRequired();
        builder.Property(x => x.DueDate)
            .IsRequired();
        builder.Property(x => x.IsPaid)
            .IsRequired();
        builder.Property(x => x.PaymentDate)
            .IsRequired(false);
        builder.HasOne(x => x.LoanRequest)
            .WithMany(x => x.Installments)
            .HasForeignKey(x => x.LoanRequestId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}