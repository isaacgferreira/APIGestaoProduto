using Data.Context;
using Data.Repository;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection
{
	public static class ConfigureRepository
	{
		public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
		{
			serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
			serviceCollection.AddDbContext<DomainContext>(options =>
				options.UseSqlServer("Initial Catalog=ApiGestaoProduto;Server=localhost; User Id=isaac; Password=123456")
			);
		}
	}
}
