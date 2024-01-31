using ExpenseService.Domain.Filters.Expenses;
using ExpenseService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.Domain.Interface.Repositories
{
    public interface IExpenseRepository
    {
        Task<IEnumerable<Expense>> GetExpensesByFilter(ExpenseFilter filter);
    }
}
