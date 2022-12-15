using Domain.Interfaces.Services;
using Domain.Interfaces.Services.Produtos;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;

namespace CrossCutting.DependencyInjection
{
	public static class ConfigureService
	{
		public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
		{
			serviceCollection.AddTransient<IProductService, ProductService>();
			serviceCollection.AddTransient<ISupplierService, SupplierService>();
		}
	}
}
