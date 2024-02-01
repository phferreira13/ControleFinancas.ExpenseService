using ExpenseService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.Domain.Interface.Repositories
{
    public interface IExpenseTypeRepository : IRepository<ExpenseType>
    {
        public Task<ExpenseType> AddAsync(ExpenseType expenseType);
    }
}
