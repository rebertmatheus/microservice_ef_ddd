using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransactionContext.Api.Requests;
using TransactionContext.Api.Responses;
using TransactionContext.Domain.Interfaces.Repositories;
using TransactionContext.Domain.Interfaces.UnitOfWork;

namespace TransactionContext.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/Transactions")]
    public class TransactionsController : Controller
    {
		private readonly IUnitOfWork _unitOfWork;
		private readonly ITransactionRepository _transactionRepository;
		private readonly IMediator _mediator;

		public TransactionsController(IUnitOfWork unitOfWork, 
            ITransactionRepository transactionRepository,
            IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _transactionRepository = transactionRepository;
            _mediator = mediator;
        }

        private IActionResult ToActionResult(Response response)
        {
            return response.Errors != null && response.Errors.Any() ? BadRequest(
                new {
                    response.Message,
                    response.Errors
            }) : (IActionResult)Ok(new {response.Message});
        }

        [HttpPost]
        [Route("Transfer")]
        public async Task<Response> TransferValuesBetweenAccounts([FromBody] TransferRequest request)
        {
            return await _mediator.Send(request);
        }

    }
}
