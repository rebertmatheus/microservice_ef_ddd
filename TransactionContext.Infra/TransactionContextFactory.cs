
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TransactionContext.Infra
{
	public class TransactionAccountContextFactory : IDesignTimeDbContextFactory<TransactionAccountContext>
	{
		public TransactionAccountContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<TransactionAccountContext>();
            optionsBuilder.UseSqlServer("Data Source=localhost,1433; Database = TransactionsContext; User=sa; Password =Rhinoc&ros3d;");

            return new TransactionAccountContext(optionsBuilder.Options);
		}
	}
}