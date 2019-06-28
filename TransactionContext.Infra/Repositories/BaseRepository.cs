using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TransactionContext.Domain.Interfaces.Repositories;

namespace TransactionContext.Infra.Repositories
{
    public class BaseRepository<T> : IDisposable, IRepository<T> where T : class
    {
        protected readonly TransactionAccountContext _context;

        protected BaseRepository(TransactionAccountContext context)
        {
            _context = context;
        }

        public virtual void Add(T obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public virtual T GetById(int? id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual void Remove(T obj)
        {
            _context.Set<T>().Remove(obj);
            _context.SaveChanges();
        }

        public virtual void Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
	}
}