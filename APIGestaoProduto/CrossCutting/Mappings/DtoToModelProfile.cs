using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.Product;
using Domain.Dtos.Supplier;
using Domain.Model;

namespace CrossCutting.Mappings
{
	public class DtoToModelProfile : Profile
	{
		public DtoToModelProfile()
		{
			CreateMap<PaginatedListProductDto, PaginatedListProductModel>().ReverseMap();
			CreateMap<PaginatedListResponse<ProductDtoResponse>, PaginatedListProductModel>().ReverseMap();

			CreateMap<PaginatedListSupplierDto, PaginatedListSupplierModel>().ReverseMap();
			CreateMap<PaginatedListResponse<SupplierDtoResponse>, PaginatedListSupplierModel>().ReverseMap();
		}
	}
}
