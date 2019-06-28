using TransactionContext.Domain.Entities;
using TransactionContext.Domain.Interfaces.Repositories;

namespace TransactionContext.Infra.Repositories
{
	public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
	{
        public CustomerRepository(TransactionAccountContext context) : base(context)
		{
		}

		public Customer Add(string name)
		{
			Customer customer = new Customer(name);
			Add(customer);
			return customer;
		}
	}
}
