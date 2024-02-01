using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.Domain.Filters
{
    public interface IQueryFilter<T> where T : class
    {
        IQueryable<T> ApplyFilterTo(IQueryable<T> query);
    }
}
