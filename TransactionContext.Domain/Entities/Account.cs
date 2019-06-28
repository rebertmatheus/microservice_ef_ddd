using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransactionContext.Domain.Entities
{
	public class Account
	{
		[Key]
		public int ID { get; set; }
		public string Agency { get; set; }
		public string Number { get; set; }
		public decimal Balance { get; set; }
		public virtual Customer Customer { get; set; }
		public virtual List<Transaction> OriginTransactions { get; set; }
		public virtual List<Transaction> DestinationTransactions { get; set; }
		
		public Account()
		{

		}
		
		public Account(decimal balance, Customer customer, 
			string agency, string number)
		{
			Balance = balance;
			Customer = customer;
			Agency = agency;
			Number = number;
		}

		public void Deposit(decimal value)
		{
			Balance += value;
		}

		public void Withdraw(decimal value)
		{
			Balance -= value;
		}

		public override string ToString()
		{
			return $"{Agency} - {Number}";
		}
	}
}