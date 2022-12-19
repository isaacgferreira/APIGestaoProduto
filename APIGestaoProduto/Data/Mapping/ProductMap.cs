using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
	public class ProductMap : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.ToTable("product");
			builder.HasKey(p => p.Id);
			builder.Property(p => p.CreatedAt).IsRequired().HasDefaultValue(DateTime.UtcNow.Date);
			builder.Property(p => p.Description).IsRequired().HasMaxLength(100);
			builder.Property(p => p.Situation).IsRequired().HasDefaultValue(true);
			builder.HasOne(p => p.Supplier).WithMany(s => s.Products);
		}
	}
}
