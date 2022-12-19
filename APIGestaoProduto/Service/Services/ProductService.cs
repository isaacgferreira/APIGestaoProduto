using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.Product;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces.Services.Produtos;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
	public class ProductService : IProductService
	{
		private readonly ISupplierService _supplierService;
		private readonly IProductRepository _repository;
		private readonly IMapper _mapper;

		public ProductService(IProductRepository repository, IMapper mapper, ISupplierService supplierService)
		{
			_repository = repository;
			_mapper = mapper;
			_supplierService = supplierService;
		}

		public async Task<BaseResponse<ProductDtoResponse>> ChangeSituation(ProductDtoSituation productDtoSituation)
		{
			var response = new BaseResponse<ProductDtoResponse>();
			var product = await _repository.SelectAsync(productDtoSituation.Id);

			if (product is null)
			{
				response.Errors = new List<Errors>() {
					new Errors()
					{
						Type = "NotFound",
						Error = "Product not found."
					}
				};
				return response;
			}

			product.Situation = productDtoSituation.Situation;
			product.UpdatedAt = DateTime.UtcNow.Date;
			var updatedProduct = await _repository.UpdateAsync(product);
			response.Data = _mapper.Map<ProductDtoResponse>(updatedProduct);

			return response;
		}

		public async Task<ProductDtoResponse> Get(long id)
		{
			var product = await _repository.SelectAsync(id);

			return _mapper.Map<ProductDtoResponse>(product);
		}

		public async Task<PaginatedListResponse<ProductDtoResponse>> GetPaginated(PaginatedListProductDto paginatedListProductDto)
		{
			var pagination = _mapper.Map<PaginatedListProductModel>(paginatedListProductDto);

			var paginated = await _repository.GetMany(pagination);

			return _mapper.Map<PaginatedListResponse<ProductDtoResponse>>(paginated);
		}

		public async Task<BaseResponse<ProductDtoResponse>> Post(ProductDtoCreate productDtoCreate)
		{
			var response = new BaseResponse<ProductDtoResponse>();
			var product = _mapper.Map<Product>(productDtoCreate);
			response.Errors = await ValidateAsync(product.FabricatedAt, product.ExpirationDate);

			if (response.HaveErrors)
				return response;

			var createdProduct = await _repository.InsertAsync(product);
			response.Data = _mapper.Map<ProductDtoResponse>(createdProduct);

			return response;
		}

		public async Task<BaseResponse<ProductDtoResponse>> Put(ProductDtoUpdate productDtoUpdate)
		{
			var response = new BaseResponse<ProductDtoResponse>();
			var productToUpdate = _mapper.Map<Product>(productDtoUpdate);
			response.Errors = await ValidateAsync(productToUpdate.FabricatedAt, productToUpdate.ExpirationDate, productDtoUpdate.SupplierId);

			if (response.HaveErrors)
				return response;

			productToUpdate.UpdatedAt = DateTime.UtcNow.Date;
			var updatedProduct = await _repository.UpdateAsync(productToUpdate);
			response.Data = _mapper.Map<ProductDtoResponse>(updatedProduct);

			return response;
		}

		private async Task<IEnumerable<Errors>> ValidateAsync(DateTime? fabricatedAt, DateTime? expirationDate, long? supplierId = null)
		{
			var errors = new List<Errors>();

			if (fabricatedAt is not null && expirationDate is not null && fabricatedAt >= expirationDate)
			{
				var error = new Errors()
				{
					Type = "FabricatedAt",
					Error = "Validation date must be greater than manufacturing date."
				};
				errors.Add(error);
			}

			var exist = await _supplierService.ExistAsync(supplierId);
			if (supplierId is not null && !exist)
			{
				var error = new Errors()
				{
					Type = "NotFound",
					Error = "Supplier not found."
				};
				errors.Add(error);
			}

			return errors.Count > 0 ? errors : default;
		}
	}
}
