namespace ExpenseService.EFConfiguration.Context
{
    public class ExpenseServiceContext(DbContextOptions<ExpenseServiceContext> options) : DbContext(options)
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExpenseServiceContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
