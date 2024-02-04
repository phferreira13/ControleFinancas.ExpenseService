using ApiResult.Models;
using ExpenseService.Buiseness.UseCases.ExpenseTypes.Responses;
using ExpenseService.Domain.Interface.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.Buiseness.UseCases.Expenses.Queries
{
    public class GetExpenseTypeByIdQuery : IRequest<ApiResult<ExpenseTypeResponse>>
    {
        public int Id { get; set; }

        internal class GetExpenseTypeByIdHandler(IExpenseTypeRepository expenseTypeRepository) : IRequestHandler<GetExpenseTypeByIdQuery, ApiResult<ExpenseTypeResponse>>
        {
            private readonly IExpenseTypeRepository _expenseTypeRepository = expenseTypeRepository;

            public async Task<ApiResult<ExpenseTypeResponse>> Handle(GetExpenseTypeByIdQuery request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<ExpenseTypeResponse>();
                await apiResult.ExecuteAsync(
                    func: async () => await _expenseTypeRepository.GetExpenseTypeByIdAsync(request.Id),
                    validation: e => e != null
                );
                return apiResult;
            }
        }
    }
}
