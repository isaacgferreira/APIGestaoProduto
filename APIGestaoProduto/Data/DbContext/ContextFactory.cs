using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace Data.Context
{
	public class ContextFactory : IDesignTimeDbContextFactory<DomainContext>
	{
		public DomainContext CreateDbContext(string[] args)
		{
			var conectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");
			var optionsBuilder = new DbContextOptionsBuilder<DomainContext>();
			optionsBuilder.UseSqlServer(conectionString);
			return new DomainContext(optionsBuilder.Options);
		}
	}
}
