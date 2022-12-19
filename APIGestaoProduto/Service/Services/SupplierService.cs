using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.Supplier;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
	public class SupplierService : ISupplierService
	{
		private readonly ISupplierRepository _repository;
		private readonly IMapper _mapper;

		public SupplierService(ISupplierRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<BaseResponse<SupplierDtoResponse>> ChangeSituation(SupplierDtoSituation supplierDtoSituation)
		{
			var response = new BaseResponse<SupplierDtoResponse>();
			var supplier = await _repository.SelectAsync(supplierDtoSituation.Id);

			if (supplier is null)
			{
				response.Errors = new List<Errors>() {
					new Errors()
					{
						Type = "NotFound",
						Error = "Supplier not found."
					}
				};
				return response;
			}

			supplier.Situation = supplierDtoSituation.Situation;
			supplier.UpdatedAt = DateTime.UtcNow.Date;
			var updatedSupplier = await _repository.UpdateAsync(supplier);
			response.Data = _mapper.Map<SupplierDtoResponse>(updatedSupplier);

			return response;
		}

		public async Task<SupplierDtoResponse> Get(long? id)
		{
			var supplier = await _repository.SelectAsync(id);

			return _mapper.Map<SupplierDtoResponse>(supplier);
		}

		public async Task<PaginatedListResponse<SupplierDtoResponse>> GetPaginated(PaginatedListSupplierDto paginatedListSupplierDto)
		{
			//var listSupplier = await _repository.SelectManyAsync();
			//return _mapper.Map<IEnumerable<SupplierDtoResponse>>(listSupplier);

			var pagination = _mapper.Map<PaginatedListSupplierModel>(paginatedListSupplierDto);

			var paginated = await _repository.GetMany(pagination);

			return _mapper.Map<PaginatedListResponse<SupplierDtoResponse>>(paginated);
		}

		public async Task<BaseResponse<SupplierDtoResponse>> Post(SupplierDtoCreate supplierDtoCreate)
		{
			var response = new BaseResponse<SupplierDtoResponse>();
			var supplier = _mapper.Map<Supplier>(supplierDtoCreate);
			var createdSupplier = await _repository.InsertAsync(supplier);

			response.Data = _mapper.Map<SupplierDtoResponse>(createdSupplier);
			return response;
		}

		public async Task<BaseResponse<SupplierDtoResponse>> Put(SupplierDtoUpdate supplierDtoUpdate)
		{
			var response = new BaseResponse<SupplierDtoResponse>();
			var supplierToUpdate = _mapper.Map<Supplier>(supplierDtoUpdate);

			supplierToUpdate.UpdatedAt = DateTime.UtcNow.Date;
			var updatedSupplier = await _repository.UpdateAsync(supplierToUpdate);

			response.Data = _mapper.Map<SupplierDtoResponse>(updatedSupplier);
			return response;
		}

		public async Task<bool> ExistAsync(long? id)
		{
			return await _repository.ExistAsync(id);
		}
	}
}
