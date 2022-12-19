using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.Product;
using Domain.Dtos.Supplier;
using Domain.Entities;

namespace CrossCutting.Mappings
{
	public class DtoToEntityProfile : Profile
	{
		public DtoToEntityProfile()
		{
			CreateMap<Product, ProductDtoCreate>().ReverseMap();
			CreateMap<Product, ProductDtoUpdate>().ReverseMap();
			CreateMap<Product, ProductDtoSituation>().ReverseMap();
			CreateMap<Product, ProductDtoResponse>().ReverseMap();

			CreateMap<Supplier, SupplierDtoCreate>().ReverseMap();
			CreateMap<Supplier, SupplierDtoUpdate>().ReverseMap();
			CreateMap<Supplier, SupplierDtoSituation>().ReverseMap();
			CreateMap<Supplier, SupplierDtoResponse>().ReverseMap();
		}
	}
}
