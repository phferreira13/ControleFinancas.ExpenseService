using ApiResult.Models;
using ExpenseService.Buiseness.UseCases.Expenses.Reponses;
using ExpenseService.Domain.Interface.Repositories;
using ExpenseService.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.Buiseness.UseCases.Expenses.Commands
{
    public class AddExpenseCommand : IRequest<ApiResult<ExpenseResponse>>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Value { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int ExpenseTypeId { get; set; }
        public bool Paid { get; set; }
        public DateTime? PaidAt { get; set; }
        public int AccountId { get; set; }
        public int UserId { get; set; }

        public static implicit operator Expense(AddExpenseCommand expense)
        {
            return new Expense(
                expense.Name, 
                expense.Value, 
                expense.ExpenseDate, 
                expense.ExpenseTypeId, 
                expense.AccountId, 
                expense.UserId, 
                expense.Description, 
                expense.Paid, 
                expense.PaidAt
                );
        }

        internal class AddExpenseCommandHandler(IExpenseRepository expenseRepository) : IRequestHandler<AddExpenseCommand, ApiResult<ExpenseResponse>>
        {
            private readonly IExpenseRepository _expenseRepository = expenseRepository;

            public async Task<ApiResult<ExpenseResponse>> Handle(AddExpenseCommand request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<ExpenseResponse>();
                await apiResult.ExecuteAsync(async () => await _expenseRepository.AddAsync(request));
                return apiResult;
            }
        }
    }
}
