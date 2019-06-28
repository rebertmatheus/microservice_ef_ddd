using System;
using Microsoft.EntityFrameworkCore;
using TransactionContext.Domain.Entities;

namespace TransactionContext.Infra.Mappings
{
	public class TransactionMap : IEntityTypeConfiguration<Transaction>
	{
		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Transaction> builder)
		{
			builder.ToTable("Transaction");

            builder.Property(p => p.ID)
                .ValueGeneratedOnAdd();
			
			builder.HasOne(a => a.OriginAccount)
				.WithMany(t => t.OriginTransactions)
				.HasForeignKey(t => t.OriginAccountID);
			
			builder.HasOne(a => a.DestinationAccount)
				.WithMany(t => t.DestinationTransactions)
				.HasForeignKey(t => t.DestinationAccountID);
		}
	}
}
