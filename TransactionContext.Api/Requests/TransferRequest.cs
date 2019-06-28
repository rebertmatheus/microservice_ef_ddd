using MediatR;
using TransactionContext.Api.Responses;
using TransactionContext.Domain.ValueObjects;

namespace TransactionContext.Api.Requests
{
    public class TransferRequest : IRequest<Response>
    {
        public AccountTransferVO OriginAccount { get; set; }
        public AccountTransferVO DestinationAccount { get; set; }
        public decimal Amount { get; set; }
        
    }
}
