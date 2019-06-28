using TransactionContext.Domain.Interfaces.UnitOfWork;

namespace TransactionContext.Infra.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly TransactionAccountContext _context;

		public UnitOfWork(TransactionAccountContext context)
		{
			_context = context;
		}

		public bool Commit()
		{
			return _context.SaveChanges() > 0;
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}