using ExpenseService.Domain.Interface.Repositories;
using ExpenseService.EFConfiguration.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.EFConfiguration.Repositories
{
    public class ExpenseTypeRepository(ExpenseDbContext context) : IExpenseTypeRepository
    {
        private readonly ExpenseDbContext _context = context;
        private readonly DbSet<ExpenseType> expenseTypes = context.ExpenseTypes;

        public async Task<ExpenseType> AddAsync(ExpenseType expenseType)
        {
            await expenseTypes.AddAsync(expenseType);            
            await _context.SaveChangesAsync();
            return expenseType;
        }
    }
}
