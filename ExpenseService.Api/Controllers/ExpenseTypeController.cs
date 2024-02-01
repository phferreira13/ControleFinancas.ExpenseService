using ApiResult.Models;
using ExpenseService.Buiseness.UseCases.ExpenseTypes.Commands;
using ExpenseService.Buiseness.UseCases.ExpenseTypes.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseService.Api.Controllers
{
    [ApiController]
    [Route("api/expense-types")]
    public class ExpenseTypeController(IMediator mediator)
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        [ProducesResponseType(typeof(ApiResult<ExpenseTypeResponse>), 200)]
        public async Task<ApiResult<ExpenseTypeResponse>> AddExpenseType([FromBody] AddExpenseTypeCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
