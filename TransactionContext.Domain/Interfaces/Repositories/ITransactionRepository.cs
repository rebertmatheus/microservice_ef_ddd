using TransactionContext.Domain.Entities;

namespace TransactionContext.Domain.Interfaces.Repositories
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        Transaction Add(Account origin, Account destination, decimal amount);
    }
}
