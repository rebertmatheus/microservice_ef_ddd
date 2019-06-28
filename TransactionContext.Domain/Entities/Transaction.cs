using System.ComponentModel.DataAnnotations;

namespace TransactionContext.Domain.Entities
{
	public class Transaction
	{
		[Key]
		public int ID { get; set; }
		public decimal Amount { get; set; }
		public int OriginAccountID { get; set; }
		public int DestinationAccountID { get; set; }
		public virtual Account OriginAccount { get; set; }
		public virtual Account DestinationAccount { get; set; }
		
		public Transaction()
		{

		}

		public Transaction(Account originAccount, Account destinationAccount, 
			decimal amount, int originAccountID, int destinationAccountID)
		{
			OriginAccount = originAccount;
			DestinationAccount = destinationAccount;
			OriginAccountID = originAccountID;
			DestinationAccountID = destinationAccountID;
			Amount = amount;
		}
	}
}