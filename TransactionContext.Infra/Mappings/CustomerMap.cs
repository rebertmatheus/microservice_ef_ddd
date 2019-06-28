using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransactionContext.Domain.Entities;

namespace TransactionContext.Infra.Mappings
{
	public class CustomerMap : IEntityTypeConfiguration<Customer>
	{
		public void Configure(EntityTypeBuilder<Customer> builder)
		{
			builder.ToTable("Customer");

            builder.Property(p => p.ID)
                .ValueGeneratedNever();
		}
	}
}
