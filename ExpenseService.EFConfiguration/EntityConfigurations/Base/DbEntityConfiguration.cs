namespace ExpenseService.EFConfiguration.EntityConfigurations
{
    public abstract class DbEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : DbEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreatedAt)
                .IsRequired();

            builder.Property(e => e.UpdatedAt);

            builder.Property(e => e.DeletedAt);
            builder.Property(e => e.Status)
                .IsRequired();
        }
    }
}
