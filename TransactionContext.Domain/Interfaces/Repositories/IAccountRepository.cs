using TransactionContext.Domain.Entities;

namespace TransactionContext.Domain.Interfaces.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        Account GetByAgencyAndNumber(string agency, string number);
        Account Add(decimal balance, Customer customer, string agency, string number);
    }
}
