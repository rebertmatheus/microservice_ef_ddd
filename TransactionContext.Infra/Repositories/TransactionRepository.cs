using TransactionContext.Domain.Entities;
using TransactionContext.Domain.Interfaces.Repositories;

namespace TransactionContext.Infra.Repositories
{
	public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
	{
        public TransactionRepository(TransactionAccountContext context) : base(context)
		{
		}

		public Transaction Add(Account origin, Account destination, decimal amount)
		{
			Transaction transaction = new Transaction(origin, destination, amount, origin.ID, destination.ID);
			Add(transaction);
			return transaction;
		}
	}
}
