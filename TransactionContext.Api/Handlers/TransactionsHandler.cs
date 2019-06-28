using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TransactionContext.Api.Requests;
using TransactionContext.Api.Responses;
using TransactionContext.Domain.Entities;
using TransactionContext.Domain.Interfaces.Repositories;
using TransactionContext.Domain.Interfaces.UnitOfWork;
using TransactionContext.Domain.ValueObjects;

namespace TransactionContext.Api.Handlers
{
	public class TransactionsHandler : IRequestHandler<TransferRequest, Response>
	{
		private readonly IAccountRepository _accountRepository;
		private readonly ICustomerRepository _customerRepository;
		private readonly ITransactionRepository _transactionRepository;
		private readonly IUnitOfWork _unitOfWork;

		public TransactionsHandler(IAccountRepository accountRepository, 
            ICustomerRepository customerRepository, 
            ITransactionRepository transactionRepository,
            IUnitOfWork unitOfWork
			)
		{
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
			_customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
		}

		public async Task<Response> Handle(TransferRequest request, CancellationToken cancellationToken)
		{
			if (request == null)
				return (new Response(){Message = "Invalid Request."});
			if (request.DestinationAccount == null)
				return (new Response(){Message = "Destination Account cannot be null."});
			if (request.OriginAccount == null)
				return (new Response(){Message = "Origin Account cannot be null."});
			if (request.Amount <= 0 )
				return (new Response(){Message = "Amount should be greater than zero."});

			var originAccount = _accountRepository.GetByAgencyAndNumber(request.OriginAccount.Agency, 
				request.OriginAccount.Number);

			if (originAccount == null)
				originAccount = CreateAccount(request.OriginAccount);
				
			if (originAccount.Balance <= request.Amount)
				return (new Response(){Message = "Not enough money."});

			var destinationAccount = _accountRepository.GetByAgencyAndNumber(request.DestinationAccount.Agency, 
				request.DestinationAccount.Number);
			if (destinationAccount == null)
				destinationAccount = CreateAccount(request.DestinationAccount);
			
			originAccount.Withdraw(request.Amount);
			destinationAccount.Deposit(request.Amount);

			_transactionRepository.Add(originAccount, destinationAccount, request.Amount);

			// _accountRepository.Update(originAccount);
			// _accountRepository.Update(destinationAccount);

			_unitOfWork.Commit();
			
			return (new Response(){Message = "Transferencia realizada com sucesso!"});
		}

		private string RandomString(int size, bool lowerCase)  
		{  
			StringBuilder builder = new StringBuilder();
			Random random = new Random();  
			char ch;  
			for (int i = 0; i < size; i++)  
			{  
				ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));  
				builder.Append(ch);  
			}  
			if (lowerCase)  
				return builder.ToString().ToLower();

			return builder.ToString();  
		}

		private int RandomNumber(int min, int max)  
		{  
			Random random = new Random();  
			return random.Next(min, max);  
		}

		private Account CreateAccount(AccountTransferVO reqAccount)
		{
			var customer = _customerRepository.Add(RandomString(5,true));
			var account = _accountRepository.Add(RandomNumber(100,5000), customer, reqAccount.Agency, 
				reqAccount.Number);
				
			customer.Accounts.Add(account);
			return account;
		}
	}
}
