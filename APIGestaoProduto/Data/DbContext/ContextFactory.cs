using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Context
{
	public class ContextFactory : IDesignTimeDbContextFactory<DomainContext>
	{
		public DomainContext CreateDbContext(string[] args)
		{
			var conectionString = "Initial Catalog=ApiGestaoProduto;Server=localhost";
			var optionsBuilder = new DbContextOptionsBuilder<DomainContext>();
			optionsBuilder.UseInMemoryDatabase(conectionString);
			return new DomainContext(optionsBuilder.Options);
		}
	}
}
