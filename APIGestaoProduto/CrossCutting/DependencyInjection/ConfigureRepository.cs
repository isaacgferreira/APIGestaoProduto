using Data.Context;
using Data.Repository;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CrossCutting.DependencyInjection
{
	public static class ConfigureRepository
	{
		public static void ConfigureDependenciesRepository(IServiceCollection services)
		{
			services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
			services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
			services.AddScoped(typeof(ISupplierRepository), typeof(SupplierRepository));

			string dbConnection = Environment.GetEnvironmentVariable("DB_CONNECTION");
			services.AddDbContext<DomainContext>(options => options.UseSqlServer(dbConnection));
		}
	}
}
