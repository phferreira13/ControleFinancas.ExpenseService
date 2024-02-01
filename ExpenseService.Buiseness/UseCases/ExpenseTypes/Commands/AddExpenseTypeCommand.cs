using ApiResult.Models;
using ExpenseService.Buiseness.UseCases.ExpenseTypes.Responses;
using ExpenseService.Domain.Interface.Repositories;
using ExpenseService.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.Buiseness.UseCases.ExpenseTypes.Commands
{
    public class AddExpenseTypeCommand : IRequest<ApiResult<ExpenseTypeResponse>>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }

        public static implicit operator ExpenseType(AddExpenseTypeCommand command) 
            => new (command.Name, command.UserId, command.Description);

        internal class AddExpenseTypeCommandHandler(IExpenseTypeRepository expenseTypeRepository) : IRequestHandler<AddExpenseTypeCommand, ApiResult<ExpenseTypeResponse>>
        {
            private readonly IExpenseTypeRepository _expenseTypeRepository = expenseTypeRepository;

            public async Task<ApiResult<ExpenseTypeResponse>> Handle(AddExpenseTypeCommand request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<ExpenseTypeResponse>();
                await apiResult.ExecuteAsync(
                    func: async () => await _expenseTypeRepository.AddAsync(request),
                    validation: data => data != null);
                return apiResult;
            }
        }

    }
}
