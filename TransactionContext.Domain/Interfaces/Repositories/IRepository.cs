using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TransactionContext.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T obj);
        T GetById(int? id);
        IEnumerable<T> GetAll();
        void Update(T obj);
        void Remove(T obj);
    }
}