namespace LoanManagementSystem.Persistence.Ef.LoanRequests;

public class LoanRequestEntityMap:IEntityTypeConfiguration<LoanRequest>
{
    
    public void Configure(EntityTypeBuilder<LoanRequest> builder)
    {
        builder.ToTable("LoanRequests");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        builder.Property(x => x.RequestDate)
            .IsRequired();
        builder.Property(x => x.LoanApprovalDate)
            .IsRequired(false);
        builder.Property(x => x.AssignedCreditScore)
            .IsRequired();
        builder.Property(x => x.Status)
            .IsRequired();
        
        builder.HasOne(x => x.Customer)
            .WithMany(x => x.LoanRequests)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Cascade); 
        
        builder.HasOne(x => x.Loan)
            .WithMany(x => x.LoanRequests)
            .HasForeignKey(x => x.LoanId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}