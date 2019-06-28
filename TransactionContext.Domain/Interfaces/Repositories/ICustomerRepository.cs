using TransactionContext.Domain.Entities;

namespace TransactionContext.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer Add(string name);
    }
}
