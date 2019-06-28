using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransactionContext.Domain.Entities
{
	public class Customer
	{
		[Key]
		public Guid ID { get; set; }
		public string Name { get; set; }
		public virtual List<Account> Accounts { get; set; }

		public Customer()
		{
            ID = Guid.NewGuid();
			Accounts = Accounts == null ? new List<Account>() : Accounts;
		}
		public Customer(string name) : this()
		{
			Name = name;
		}

		public Customer(string name, List<Account> accounts) : this()
		{
			Name = name;
			Accounts = accounts != null ? accounts : new List<Account>();
		}
	}
}