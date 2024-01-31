using ExpenseService.Domain.Filters.Expenses;
using ExpenseService.Domain.Interface.Repositories;
using ExpenseService.EFConfiguration.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.EFConfiguration.Repositories
{
    public class ExpenseRepository(ExpenseDbContext context) : IExpenseRepository
    {
        private readonly ExpenseDbContext _context = context;
        private readonly DbSet<Expense> expenses = context.Expenses;

        public async Task<IEnumerable<Expense>> GetExpensesByFilter(ExpenseFilter filter)
        {
            var query = filter.ApplyFilter(expenses);
            return await query.ToListAsync();
        }
    }
}
