using Microsoft.EntityFrameworkCore;
using TransactionContext.Domain.Entities;

namespace TransactionContext.Infra
{
    public interface IDataBase
    {
        DbSet<Account> Account { get; set; }
        DbSet<Customer> Customer { get; set; }
        DbSet<Transaction> Transaction { get; set; }
        void SaveChanges();
    }
}
