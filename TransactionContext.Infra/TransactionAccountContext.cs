using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TransactionContext.Domain.Entities;
using TransactionContext.Infra.Mappings;

namespace TransactionContext.Infra
{
    public class TransactionAccountContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        protected IServiceProvider _serviceProvider;
        public TransactionAccountContext(DbContextOptions<TransactionAccountContext> optionsBuilder) 
            : base(optionsBuilder)
        {
        }

        public TransactionAccountContext(DbContextOptions<TransactionAccountContext> optionsBuilder,
            IServiceProvider serviceProvider) 
            : base(optionsBuilder)
        {
            _serviceProvider = serviceProvider;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new TransactionMap());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
