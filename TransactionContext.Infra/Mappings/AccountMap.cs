using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransactionContext.Domain.Entities;

namespace TransactionContext.Infra.Mappings
{
	public class AccountMap : IEntityTypeConfiguration<Account>
	{
		public void Configure(EntityTypeBuilder<Account> builder)
		{
			builder.ToTable("Account");

            builder.Property(p => p.ID)
                .ValueGeneratedNever();
		}
	}
}
