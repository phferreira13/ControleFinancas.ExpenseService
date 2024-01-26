namespace ExpenseService.EFConfiguration.EntityConfigurations
{
    public class ExpenseConfiguration : DbEntityConfiguration<Expense>, IEntityTypeConfiguration<Expense>
    {
        public new void Configure(EntityTypeBuilder<Expense> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Description)
                .HasMaxLength(500);

            builder.Property(e => e.Value)
                .IsRequired();

            builder.Property(e => e.ExpenseDate)
                .IsRequired();

            builder.Property(e => e.ExpenseTypeId)
                .IsRequired();

            builder.Property(e => e.AccountId)
                .IsRequired();

            builder.Property(e => e.UserId)
                .IsRequired();

            builder.HasAlternateKey(e => new { e.Id, e.UserId });

            builder.HasOne(e => e.ExpenseType)
                .WithMany(e => e.Expenses)
                .HasForeignKey(e => e.ExpenseTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
