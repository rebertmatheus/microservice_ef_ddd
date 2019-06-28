using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransactionContext.Domain.Entities
{
	public class Customer
	{
		[Key]
		public int ID { get; set; }
		public string Name { get; set; }
		public virtual List<Account> Accounts { get; set; }

		public Customer()
		{
			Accounts = new List<Account>();
		}
		public Customer(string name) : base()
		{
			Name = name;
		}

		public Customer(string name, List<Account> accounts)
		{
			Name = name;
			Accounts = accounts != null ? accounts : new List<Account>();
		}
	}
}