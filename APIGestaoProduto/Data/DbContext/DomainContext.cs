using Data.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
	public class DomainContext : DbContext
	{
		public DbSet<Product> Product { get; set; }
		public DbSet<Supplier> Supplier { get; set; }

		public DomainContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Product>(new ProductMap().Configure);
			modelBuilder.Entity<Supplier>(new SupplierMap().Configure);
		}
	}
}
