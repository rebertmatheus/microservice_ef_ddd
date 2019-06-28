using System.Linq;
using TransactionContext.Domain.Entities;
using TransactionContext.Domain.Interfaces.Repositories;

namespace TransactionContext.Infra.Repositories
{
	public class AccountRepository : BaseRepository<Account>, IAccountRepository
	{
		public AccountRepository(TransactionAccountContext context) : base(context)
		{
		}

		public Account GetByAgencyAndNumber(string agency, string number)
		{
			return GetAll().Where(x => x.Agency == agency && x.Number == number).FirstOrDefault();
		}

		public Account Add(decimal balance, Customer customer, string agency, string number)
		{
			Account account = new Account(balance, customer, agency, number);
			Add(account);
			return account;
		}
	}
}
