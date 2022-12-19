using AutoMapper;
using CrossCutting.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection
{
	public static class ConfigureMapper
	{
		public static void ConfigureDependenciesDto(IServiceCollection services)
		{
			var configMapper = new AutoMapper.MapperConfiguration(conf =>
			{
				conf.AddProfile(new DtoToEntityProfile());
				conf.AddProfile(new DtoToModelProfile());
			});

			IMapper mapper = configMapper.CreateMapper();
			services.AddSingleton(mapper);
		}
	}
}
