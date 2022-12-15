using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
	public class SupplierMap : IEntityTypeConfiguration<Supplier>
	{
		public void Configure(EntityTypeBuilder<Supplier> builder)
		{
			builder.ToTable("supplier");
			builder.HasKey(p => p.Id);
			builder.Property(p => p.Description).IsRequired().HasMaxLength(100);
			builder.Property(p => p.Cnpj).HasMaxLength(14);
		}
	}
}
