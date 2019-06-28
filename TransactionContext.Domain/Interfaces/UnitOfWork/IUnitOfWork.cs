using System;

namespace TransactionContext.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
