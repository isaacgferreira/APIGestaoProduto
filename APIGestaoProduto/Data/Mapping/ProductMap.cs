using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
	public class ProductMap : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.ToTable("product");
			builder.HasKey(p => p.Id);
			builder.Property(p => p.CreateAt).ValueGeneratedOnAdd();
			builder.Property(p => p.Description).IsRequired().HasMaxLength(100);
			builder.Property(p => p.Situation).IsRequired();
			builder.HasOne(p => p.Supplier).WithOne(f => f.Product).HasForeignKey<Product>(b => b.SupplierId);
		}
	}
}
