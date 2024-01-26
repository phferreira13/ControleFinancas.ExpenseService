namespace ExpenseService.EFConfiguration.EntityConfigurations
{
    public class ExpenseTypeConfiguration : DbEntityConfiguration<ExpenseType>, IEntityTypeConfiguration<ExpenseType>
    {
        public new void Configure(EntityTypeBuilder<ExpenseType> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Description)
                .HasMaxLength(500);

            builder.HasAlternateKey(e => new { e.Id, e.UserId });

            builder.HasMany(e => e.Expenses)
                .WithOne(e => e.ExpenseType)
                .HasForeignKey(e => e.ExpenseTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
