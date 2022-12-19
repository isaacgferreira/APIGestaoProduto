using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Context
{
	public class ContextFactory : IDesignTimeDbContextFactory<DomainContext>
	{
		public DomainContext CreateDbContext(string[] args)
		{
			var conectionString = "Initial Catalog=ApiGestaoProduto;Server=localhost; User Id=isaac; Password=123456";
			var optionsBuilder = new DbContextOptionsBuilder<DomainContext>();
			optionsBuilder.UseSqlServer(conectionString);
			return new DomainContext(optionsBuilder.Options);
		}
	}
}
