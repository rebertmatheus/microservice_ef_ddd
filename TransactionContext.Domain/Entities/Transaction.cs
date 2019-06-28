using System;
using System.ComponentModel.DataAnnotations;

namespace TransactionContext.Domain.Entities
{
	public class Transaction
	{
		[Key]
		public Guid ID { get; set; }
		public decimal Amount { get; set; }
		public Guid OriginAccountID { get; set; }
		public Guid DestinationAccountID { get; set; }
		public virtual Account OriginAccount { get; set; }
		public virtual Account DestinationAccount { get; set; }
		
		public Transaction()
		{
            ID = Guid.NewGuid();
		}

		public Transaction(Account originAccount, Account destinationAccount, 
			decimal amount, Guid originAccountID, Guid destinationAccountID) : this()
		{
			OriginAccount = originAccount;
			DestinationAccount = destinationAccount;
			OriginAccountID = originAccountID;
			DestinationAccountID = destinationAccountID;
			Amount = amount;
		}
	}
}