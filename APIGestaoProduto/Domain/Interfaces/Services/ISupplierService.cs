using Domain.Dtos;
using Domain.Dtos.Supplier;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
	public interface ISupplierService
	{
		Task<SupplierDtoResponse> Get(long? id);
		Task<PaginatedListResponse<SupplierDtoResponse>> GetPaginated(PaginatedListSupplierDto paginatedListSupplierDto);
		Task<BaseResponse<SupplierDtoResponse>> Post(SupplierDtoCreate supplierDtoCreate);
		Task<BaseResponse<SupplierDtoResponse>> Put(SupplierDtoUpdate supplierDtoUpdate);
		Task<BaseResponse<SupplierDtoResponse>> ChangeSituation(SupplierDtoSituation supplierDtoSituation);
		Task<bool> ExistAsync(long? id);
	}
}
