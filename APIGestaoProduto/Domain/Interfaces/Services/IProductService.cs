using Domain.Dtos;
using Domain.Dtos.Product;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Produtos
{
	public interface IProductService
	{
		Task<ProductDtoResponse> Get(long id);
		Task<PaginatedListResponse<ProductDtoResponse>> GetPaginated(PaginatedListProductDto paginatedListProductDto);
		Task<BaseResponse<ProductDtoResponse>> Post(ProductDtoCreate productDtoCreate);
		Task<BaseResponse<ProductDtoResponse>> Put(ProductDtoUpdate productDtoUpdate);
		Task<BaseResponse<ProductDtoResponse>> ChangeSituation(ProductDtoSituation productDtoSituation);
	}
}
